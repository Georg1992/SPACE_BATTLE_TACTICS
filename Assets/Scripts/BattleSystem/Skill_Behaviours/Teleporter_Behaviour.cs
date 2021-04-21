using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleporter_Behaviour : MonoBehaviour
{
    
   private float x;
   private float y;
   private float init;
   private float time = 1f;
   private float timeCofix = 0.9f;
 
    void Start(){
        
    }
    void Update(){
        
       

    }

    public void Use(GameObject whouse){
        init = whouse.transform.position.y;
        StartCoroutine(Teleport(whouse));
        
        

        
    }    

   
    
    public IEnumerator Teleport(GameObject user){
        
        
        x = user.transform.position.x;
        y = Random.Range(-70,70);

        
        user.transform.position = new Vector2(x,y);
        for(int i=0; i<25; i++){
        time = time * timeCofix;
        yield return new WaitForSeconds(time);
        y = Random.Range(-70,70);
        while(user.transform.localScale.x > 0){
            user.transform.localScale -= new Vector3(0.1f,0.1f,0);
            yield return null;
        }    
        user.transform.position = new Vector2(x,y);
            user.transform.localScale = new Vector3(1,1,1);

        }
        
        
        user.transform.position = new Vector2(x,init);
        time = 1.2f;
        

        

    }
}
