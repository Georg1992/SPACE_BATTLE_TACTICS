using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirForceCall_Behaviour : MonoBehaviour
{
   public GameObject prefab;
   private List <Vector2> enemyForcePositions;
   private List <Vector2> playerForcePositions;
   void Start(){
      enemyForcePositions = new List<Vector2>();
      playerForcePositions = new List<Vector2>();
      playerForcePositions.Add(new Vector2(-300,65));
      playerForcePositions.Add(new Vector2(-300,-65));
      enemyForcePositions.Add(new Vector2(300,65));
      enemyForcePositions.Add(new Vector2(300,-65));


   }

   public void Use(GameObject user){
      
         if(user == GameObject.Find("Enemy")){
            foreach(Vector2 pos in enemyForcePositions){
               AirForceObject thisPrefab = prefab.transform.GetComponent<AirForceObject>();

               Instantiate(prefab, pos, Quaternion.Euler(0,180,0));
               thisPrefab.EnemyShot();


            }

         }
         if(user == GameObject.Find("Player")){
            foreach(Vector2 pos in playerForcePositions){
               Instantiate(prefab, pos, Quaternion.identity);
            }

         }
      

   }
}
