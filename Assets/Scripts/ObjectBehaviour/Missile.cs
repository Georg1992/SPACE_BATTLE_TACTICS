using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    
    private Rigidbody2D rbMissile;
    private Animator animator;

    public float speed = 80f;
    private float distanceToTarget;

    private float t;
    private bool PlayerShot = true;
    private bool StoppedByHole = false;


    public bool lighningOnce = false;
    private bool reverse = false;
    public bool Boosted = false;
    
    
   
    
    
   
    
    
    
    void Start()
    {
       
        rbMissile = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
        if (rbMissile.position.x > 300 || rbMissile.position.x < -300){
            Destroy(gameObject);
        }

        

        if(!lighningOnce){
            StartCoroutine(LightningDestroy());
           
       }
       if(reverse&&PlayerShot){
           StartCoroutine(FlyState(GameObject.Find("Enemy")));
       }
       if(reverse&&!PlayerShot){
           StartCoroutine(FlyState(GameObject.Find("Player")));
       }

       if(StoppedByHole){
           Destroy(gameObject);
       }
       
    }

    
    
    
    
    
    
    void OnTriggerEnter2D (Collider2D hitCollider){
        string enemy = hitCollider.name;
    
   
        if(enemy == "Enemy" && PlayerShot)
        {
           CreateEnemy.EnemyShip.CurrentHealth -= CreatePlayer.chosenShip.Base_attack *4;
            speed = 0;
            ZeroVelocity();
            animator.SetBool("Explode", true);
           
        }else if(enemy == "Player" && !PlayerShot){
            CreatePlayer.chosenShip.CurrentHealth -= CreateEnemy.EnemyShip.Base_attack * 4;
            speed = 0;
            ZeroVelocity();
            animator.SetBool("Explode", true);
       
       
        }else if (enemy == "PlayerMissile" || enemy == "EnemyMissile"){
            ZeroVelocity();
            speed = 0;
            animator.SetBool("Explode", true);

            
        }else if (enemy =="MirrorShield(Clone)" && PlayerShot == false){   //WORKS BAD!
             Vector3 rot = gameObject.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x,rot.y+180,rot.z);
            gameObject.transform.rotation = Quaternion.Euler(rot);
            StartCoroutine(FlyState(GameObject.Find("Enemy")));
            
        }
        
    }
    public void EnemyShot(){

        PlayerShot = false;

    }

   
   

    
    public void DestroyWithHole(){
        StoppedByHole = true;

    }

  

   


    private enum State {
        GetOut,
        FlyToTarget,
        ContinueMoving,
        stop
       
    }
 
    private State state;
 
    public IEnumerator GetOutState (GameObject target) {
        rbMissile = this.GetComponent<Rigidbody2D>();
        state = State.GetOut;
        
        if (state == State.GetOut&& rbMissile != null)  {
            this.GetComponent<BoxCollider2D>().enabled = false;
            rbMissile.velocity = -transform.up * speed;
            
            yield return new WaitForSecondsRealtime(0.3f);
            
            if(rbMissile != null){
            rbMissile.velocity = Vector2.zero;
            StartCoroutine(FlyState(target));
            yield return new WaitForSecondsRealtime(1);
            this.GetComponent<BoxCollider2D>().enabled = true;
            }
        
            
            
            
        }
        
    }
    

    public void ZeroVelocity(){
        rbMissile.velocity = Vector2.zero;
    }
 
    public IEnumerator FlyState (GameObject target) {
        
        state = State.FlyToTarget;
        
        while (state == State.FlyToTarget && rbMissile != null) {
           distanceToTarget = Mathf.Abs(target.transform.position.x - this.transform.position.x);
           t = Time.deltaTime;
           
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position , speed*t);
           
            
            yield return new WaitForEndOfFrame();
    
            
            if(distanceToTarget < 60){
                StopCoroutine(FlyState(target));
                StartCoroutine(ContinueMovingState(target));
            }
        reverse = false;
            
        }
        

        
        

    }

   public IEnumerator ContinueMovingState(GameObject target){
       state = State.ContinueMoving;
       Vector3 targetDirection = (target.transform.position - transform.position);  

       while (state == State.ContinueMoving && rbMissile != null){
            
            transform.position += targetDirection.normalized * speed * Time.deltaTime;
           
           yield return new WaitForEndOfFrame();
       }

        
   }


   private IEnumerator LightningDestroy(){
        if(Electric_Charge_Behaviour.ElectricChargeOn){
            
           
           if(PlayerShot == false){
            
            
            lighningOnce = true;
                
                
                while(speed > 0){
                
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(180, 0, 0), speed*5 * Time.deltaTime);
                speed = speed - 0.5f;
                yield return new WaitForEndOfFrame();
                
                }
                PlayerShot = true;
                state = State.stop;
                t=0;
                speed = 80f;
                reverse = true;
                StopAllCoroutines();
           }
           if(PlayerShot == true){
               lighningOnce = true;
                
                
                while(speed > 0){
                
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 180), speed*5 * Time.deltaTime);
                speed = speed - 0.5f;
                yield return new WaitForEndOfFrame();
                
                }
                PlayerShot = false;
                state = State.stop;
                t=0;
                speed = 80f;
                reverse = true;
                StopAllCoroutines();

           }
                
                
        }
           
            
    }

    public IEnumerator WaitAndDestroy(){
        yield return new WaitForSecondsRealtime(6);
        Destroy(gameObject);
    }
}

    

