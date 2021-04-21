using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHole : MonoBehaviour
{
    private Collider2D[] colliders;
    private BulletDirection thisBullet;
    private Missile thisMissile;
    private bool PlayerShot = true;
    private bool holeDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
      
      StartCoroutine(WaitAndDestroy());

      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        Gravitate();
       
       
    }

    public void Gravitate(){
        
        
        colliders = Physics2D.OverlapCircleAll(this.transform.position,100);

        foreach(Collider2D hit in colliders){
            
            switch (PlayerShot){
                case true:
                if(hit.gameObject.name == "EnemyBullet"){
                    thisBullet = hit.GetComponent<BulletDirection>();
                    if(holeDestroyed)thisBullet.DestroyWithHole();
                    thisBullet.lighningOnce = true; // prevent Electric Charge hit
                    applyForce(thisBullet.gameObject);
                    
                    
                }
                
                if(hit.gameObject.name == "EnemyMissile"){
                    thisMissile = hit.GetComponent<Missile>();
                    thisMissile.lighningOnce = true; 
                    if(holeDestroyed)thisMissile.DestroyWithHole(); 
                    applyForce(thisMissile.gameObject);
                    
                }
                break;

                case false:
                if(hit.gameObject.name == "PlayerBullet"){
                    thisBullet = hit.GetComponent<BulletDirection>();
                    if(holeDestroyed)thisBullet.DestroyWithHole();
                    thisBullet.lighningOnce = true;  
                    applyForce(thisBullet.gameObject);
                    
                }

                if(hit.gameObject.name == "PlayerMissile"){
                    thisMissile = hit.GetComponent<Missile>();
                    thisMissile.lighningOnce = true; 
                    if(holeDestroyed)thisMissile.DestroyWithHole(); 
                    applyForce(thisMissile.gameObject);
                    
                   

                    
                }
                break;

            }
            
                

                
                   


                
               
                
            }

        }
    

    private IEnumerator WaitAndDestroy(){
        yield return new WaitForSecondsRealtime(6);
        holeDestroyed = true;
        Destroy(gameObject, 0.1f);
    }

    public void EnemyShot(){
        PlayerShot = false;
    }


    private void applyForce(GameObject obj){
         foreach(Collider2D hit in colliders){
            
            if(hit.gameObject.name != "Player" && hit.gameObject.name != "Enemy" ){
                if(hit.gameObject == obj && hit.gameObject != null ){
                    hit.attachedRigidbody.drag = 1;
                    hit.attachedRigidbody.AddForce((this.transform.position - hit.transform.position).normalized * 80);

                    if(hit.transform.localScale.x > 0.01) hit.transform.localScale -= new Vector3(0.002f,0.002f);
                }

                
               
                
            }

        }
    }


}
