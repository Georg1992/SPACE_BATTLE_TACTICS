using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class LaserEndBehaviour : MonoBehaviour
{

    
   
    public float speed;
    public bool playerHit = false;
    public bool enemyHit = false;
    private bool playerShot = true;
 
    private RaycastHit2D hit;
    
   private GameObject userFirepoint;
   private GameObject targetFirepoint;
   private LineRenderer lineRenderer;

   private GameObject LaserParrent;
   
  

    
  
   
    
    
    
    void Start()
    {
       
       userFirepoint = GameObject.Find("Player").transform.GetChild(0).gameObject;
       LaserParrent = transform.parent.gameObject;
       lineRenderer = transform.parent.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(LaserCast());
     
        if(playerHit){
            CreatePlayer.chosenShip.CurrentHealth -=0.3f;
            transform.position = Vector2.MoveTowards(transform.position, targetFirepoint.transform.position , speed*Time.deltaTime);

        }
        if(enemyHit){
            
            CreateEnemy.EnemyShip.CurrentHealth -= 0.3f;
            
        
         
         transform.position = Vector2.MoveTowards(transform.position, targetFirepoint.transform.position , speed*Time.deltaTime);
    
        }

       
        
        
    }



    public IEnumerator LaserCast(){
        
       
       
       if(LaserParrent != null){
       hit = Physics2D.Linecast(userFirepoint.transform.position, this.transform.position);
       yield return new WaitForFixedUpdate();
       }

       
        
       

 
         
    }

    void OnTriggerEnter2D (Collider2D hitCollider){
        string enemy = hitCollider.gameObject.name;
        
        
        
   
        if(enemy == "Enemy" && playerShot==true)
        {
           
           enemyHit = true;
           state = State.stop;
           
           speed=400;
         
         
           
           
        }
         if(enemy == "Player" && playerShot==false){
            playerHit = true;
            
        }
        
    }
    public void EnemyShot(){

        playerShot = false;

    }


    private enum State {
       
        FlyToTarget,
        stop
       
       
    }
 
    private State state;
 
   
 
    public IEnumerator FlyState (GameObject target) {
        state = State.FlyToTarget;
        
        targetFirepoint = target.transform.GetChild(1).gameObject;
        while (state == State.FlyToTarget) {
           
           
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position , speed*Time.deltaTime);
            
            
        yield return new WaitForEndOfFrame();
    
        }
        
        

    }



    public IEnumerator CastLaser(GameObject target, GameObject user){
        
        Stopwatch stopwatch = new Stopwatch();
        
        
       
        
        stopwatch.Start();
        userFirepoint = GameObject.Find("Player").transform.GetChild(0).gameObject;
       
        lineRenderer = transform.parent.GetComponent<LineRenderer>();
        ParticleSystem system = this.GetComponent<ParticleSystem>();
        lineRenderer.enabled = true;
        system.Play();
      

        while(stopwatch.Elapsed.TotalSeconds<5){
            
            
            lineRenderer.SetPosition(0, userFirepoint.transform.position);
            lineRenderer.SetPosition(1, this.transform.position);
            yield return new WaitForEndOfFrame();
        }

        stopwatch.Stop();
        stopwatch.Reset();
        
        lineRenderer.enabled = false;
        playerHit = false;
        enemyHit = false;
        Destroy(LaserParrent);
        
       
    }

   
}
