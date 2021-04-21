using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class Circle_Move_Behaviour : MonoBehaviour
{
   // float speed=(2*Mathf.PI)/5;//5 seconds to complete a circle
    
    private float t;
    private Stopwatch stopwatch;
 
    private float radius = 58;
    public static bool enemyCircleMove = false;
    private Vector3 initPos;
    
    
    
    

   
    public IEnumerator Use(GameObject whoUse){
      
      stopwatch = new Stopwatch();
      stopwatch.Start();
      initPos = whoUse.transform.position;
      
      
    
      

    while(stopwatch.Elapsed.Seconds<10){
            
        t += Time.deltaTime*1.2f;
        float x = Mathf.Cos(-t)/2-0.5f;  //To start at 0 and -t to start going up
        float y = Mathf.Sin(-t); 

        if(whoUse == GameObject.Find("Player")){
            CreatePlayer.chosenShip.QSkill.SkillCoolDown = 1;
            Vector3 offset = new Vector3(x,y)* (-radius) + initPos; // (-radius) to go rightside from your initpos
            whoUse.transform.position = offset;
        }
        if(whoUse == GameObject.Find("Enemy")){
            enemyCircleMove = true;
            Vector3 offset = new Vector3(x,y)* radius + initPos; // (-radius) to go rightside from your initpos
            whoUse.transform.position = offset;
        }

        
           
        yield return new WaitForEndOfFrame();
           
    }
        stopwatch.Stop();
        stopwatch.Reset();
        t=0;
        Vector3 getPos = whoUse.transform.position;

        while(whoUse.transform.position != initPos){
            t+=Time.deltaTime*1.2f;
            whoUse.transform.position = Vector2.Lerp(getPos,initPos,t);
            yield return new WaitForEndOfFrame();
            
        }
        enemyCircleMove = false;
        CreatePlayer.chosenShip.QSkill.SkillCoolDown = 2;
        t=0;
        
    }
}
