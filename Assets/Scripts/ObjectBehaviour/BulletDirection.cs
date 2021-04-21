using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class BulletDirection : MonoBehaviour
{
    
    [SerializeField] private float speed;
    private bool PlayerShot = true;
    public bool lighningOnce = false;
    private bool StoppedByHole = false;
    
    

   
   
    public Rigidbody2D rbBullet;
    
    void Start()
    {
        SpriteRenderer spriteRenderer= this.GetComponent<SpriteRenderer>();
        Color noRed = spriteRenderer.color;


        rbBullet.velocity = transform.right * speed;
        noRed.r = 1;
        noRed.b = 0;
        noRed.g = 0;
        
    }
    void Update(){
        if (rbBullet.position.x > 400|| rbBullet.position.x < -400 || transform.localScale.x < 0.01) 
        Destroy(gameObject);
        

        if(!lighningOnce){
           StartCoroutine(LightningDestroy());
           
           }

        if(StoppedByHole){
           Destroy(gameObject);
        }
        
        
    }


//BULLET BASIC ATTACK FUNCTION
   void OnTriggerEnter2D (Collider2D hitCollider){
    string enemy = hitCollider.name;
   

        if(enemy == "Enemy"&&PlayerShot==true)
        {
            CreateEnemy.EnemyShip.CurrentHealth -= CreatePlayer.chosenShip.Base_attack;
            Destroy(gameObject);
           
        }
        if(enemy == "Player"&&PlayerShot == false)
        {
            CreatePlayer.chosenShip.CurrentHealth -= CreateEnemy.EnemyShip.Base_attack;
            Destroy(gameObject);
            
        }else if (enemy =="MirrorShield(Clone)" && PlayerShot == false){
             
            rbBullet.velocity = -transform.right * speed;
        }
        if(enemy == "Astronaut(Clone)"){
            Destroy(hitCollider.gameObject);

        }

        

    }
    public void EnemyShot(){

        PlayerShot = false;

    }
    public void DestroyWithHole(){
        StoppedByHole = true;

    }

    private IEnumerator LightningDestroy(){
        if(Electric_Charge_Behaviour.ElectricChargeOn){
            
        
            
            
                
                while(rbBullet.velocity!=Vector2.zero){
                    rbBullet.velocity = transform.right * speed;
                    speed -=2;
                
                    SpriteRenderer spriteRenderer= this.GetComponent<SpriteRenderer>();
                    Color noRed = spriteRenderer.color;
                    noRed.r -= 0.01f;
                    noRed.g +=0.003f;
                    noRed.b += 0.01f;
                    spriteRenderer.color = noRed;
                
                    yield return new WaitForSeconds(0.5f);
                }
               
                
               
            yield return new WaitForSeconds(1);
            rbBullet.AddForce(Physics2D.gravity = new Vector2(0,-200));
                
            lighningOnce = true;

                
                
            
        }
           
            
    }

   

    

        
}

    

