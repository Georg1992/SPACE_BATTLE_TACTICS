using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleHandler : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    public HealthBar PlayerHealth;
    public HealthBar EnemyHealth;
    public Text timer;
    private float timeStart = 0;

  
    
   void Start(){
       timer.text = timeStart.ToString();
       
     
       

        
      
   }
    void Update(){
        
    PlayerHealth.HealthHandler(CreatePlayer.chosenShip.CurrentHealth, Player);
    EnemyHealth.HealthHandler(CreateEnemy.EnemyShip.CurrentHealth, Enemy);
    timeStart += Time.deltaTime;
    timer.text = Mathf.Round(timeStart).ToString();
    GameOver();
   
   }

    private void GameOver(){
        if(CreatePlayer.chosenShip.CurrentHealth <= 0){
            Time.timeScale = 0;
            Debug.Log("YouLose");
        }
        if(CreateEnemy.EnemyShip.CurrentHealth <= 0){
            Time.timeScale = 0;
            Debug.Log("YouWin");
        }
    }
   
   


     
}
