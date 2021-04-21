using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Slider ShieldSlider;
    public float shieldValue = 80;
    public float storedHealth;
    public bool shieldOn = false;
    private bool storedHealthForShield = false;
    private bool timerOff = false;
    
   
    public void SetMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
        ShieldSlider.maxValue = health;
        ShieldSlider.value = 0;

    }


    public float HoldHealth(float health){
        if(!storedHealthForShield){
            storedHealth = health;
            storedHealthForShield = true;
            StartCoroutine(shieldTimer());
        }
        return storedHealth;

    }
    public void HealthHandler(float health, GameObject user){
        if(shieldOn){
            
            ShieldSlider.value = health+shieldValue;
            slider.value = storedHealth;
            if((ShieldSlider.value <= slider.value) || timerOff){
                ShieldOff(user);
            }
            
        }
        else{
            slider.value = health;
        }
    }

     
   public IEnumerator shieldTimer(){
       yield return new WaitForSecondsRealtime (5);
       if(shieldOn)
       timerOff = true;
   }


    public void ShieldOff(GameObject user){
        shieldOn = false;
        ShieldSlider.value = 0;
        storedHealthForShield = false;
        timerOff = false;
        if(user == GameObject.Find("Player")){
            CreatePlayer.chosenShip.CurrentHealth = storedHealth;
        }
        if(user == GameObject.Find("Enemy")){
            CreateEnemy.EnemyShip.CurrentHealth = storedHealth;
        }
        
        
        
    }
}
