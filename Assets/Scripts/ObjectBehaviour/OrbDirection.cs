using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDirection : MonoBehaviour
{
 


    private bool playerShot = true;
 
    
    
    void Start()
    {
        
        
    }
    void Update(){
        
       
    }


    void OnParticleCollision (GameObject hit){
       
        if(hit == GameObject.Find("Player") && playerShot == false){
            CreatePlayer.chosenShip.CurrentHealth -= 0.5f;
            

        }
        if(hit == GameObject.Find("Enemy") && playerShot == true){
            CreateEnemy.EnemyShip.CurrentHealth -= 0.5f;
            

        }
        
    }
 
    public void EnemyShot(){

        playerShot = false;

    }

}
