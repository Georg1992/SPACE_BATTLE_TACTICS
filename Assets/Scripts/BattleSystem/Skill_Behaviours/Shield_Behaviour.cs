using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Behaviour : MonoBehaviour
{
    private HealthBar healthBar;
    
  
    public void Use(GameObject user){
        Skill shield = new Shield();
        

      if(user == GameObject.Find("Enemy")){
        healthBar = GameObject.Find("UICanvas/EnemyHealthBar").GetComponent<HealthBar>();
        healthBar.HoldHealth(CreateEnemy.EnemyShip.CurrentHealth);
        healthBar.shieldOn = true;
        
        
        
      }
      if(user == GameObject.Find("Player")){
        healthBar = GameObject.Find("UICanvas/HealthBar").GetComponent<HealthBar>();
        healthBar.HoldHealth(CreatePlayer.chosenShip.CurrentHealth);
        healthBar.shieldOn = true;
      }
      
    }

}
