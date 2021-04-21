using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orion_Move_Behaviour : MonoBehaviour
{
    
    private Vector3 initPos;
    private Vector3 checkpoint1;
    private Vector3 checkpoint2;
    private float t;
    private Missile[] allMissiles;
    private GameObject thisUser;
    private bool orionMoving;
    

    void Start(){

    }

    void Update(){
        allMissiles = FindObjectsOfType<Missile>();
        if(thisUser == GameObject.Find("Player")){
            foreach(Missile boostedMissile in allMissiles){
                if(boostedMissile.name == "PlayerMissile" && orionMoving &&!boostedMissile.Boosted){
                    boostedMissile.speed = 120;
                    boostedMissile.Boosted = true;
                }
                
                
            }
        }
        if(thisUser == GameObject.Find("Enemy")){
            foreach(Missile boostedMissile in allMissiles){
                if(boostedMissile.name == "EnemyMissile" && orionMoving &&!boostedMissile.Boosted){
                    boostedMissile.speed = 120;
                    boostedMissile.Boosted = true;
                }
                
                
            }

        }

    }

    public void Use(GameObject user){
        thisUser = user;
        initPos = user.transform.position; 
        checkpoint1 = new Vector3 (user.transform.GetChild(5).position.x,user.transform.GetChild(5).position.y);
        checkpoint2 = new Vector3 (user.transform.GetChild(4).position.x,user.transform.GetChild(4).position.y);
        StartCoroutine(OrionMove(user));
    
    }

    

    private IEnumerator OrionMove(GameObject user){
        orionMoving = true;
        
        while(user.transform.position != checkpoint1){
        t+=Time.deltaTime/2;
        user.transform.position = Vector2.Lerp(initPos, checkpoint1, t);
        
        yield return new WaitForEndOfFrame();
        }
        t=0;

        for(int i =0; i<2; i++){
            while(user.transform.position != checkpoint2){
                t+=Time.deltaTime/2;
                user.transform.position = Vector2.Lerp(checkpoint1, checkpoint2, t);
                yield return new WaitForEndOfFrame();
            }
            t=0;

            while(user.transform.position != checkpoint1){
                t+=Time.deltaTime/2;
                user.transform.position = Vector2.Lerp(checkpoint2, checkpoint1, t);
                yield return new WaitForEndOfFrame();
            }
            t=0;
        }
        
      

        
        while(user.transform.position != initPos){
            t+=Time.deltaTime/2;
            user.transform.position = Vector2.Lerp(checkpoint1, initPos, t);
            yield return new WaitForEndOfFrame();
        }
        orionMoving = false;
        t=0;
    
    }

}