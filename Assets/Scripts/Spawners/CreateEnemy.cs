using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateEnemy : MonoBehaviour
{
 
   public Sprite SCALPEL, WARPER, ORION;
    public SpriteRenderer SelectedCharacterSprite;
    
    public static BaseSpaceshipClass EnemyShip;
    public HealthBar EnemyHealth;
    private Animator enemyIdleAnimation;
    public static int randomEnemy;
    public GameObject Enemy;
  
   
 


public void Start()
{
  enemyIdleAnimation = GameObject.Find("Enemy").GetComponent<Animator>();
  EnemyCreation();
  

  EnemyHealth.SetMaxHealth(EnemyShip.MaxHealth);

 


  
 
}

public void EnemyCreation()
{
  randomEnemy = Random.Range(0,2);
    
  SelectedCharacterSprite = this.GetComponent<SpriteRenderer>();
   
  Transform firepoint1 = Enemy.transform.Find("Firepoint");
  Transform firpoint2 = Enemy.transform.Find("Firepoint3");
  Transform missilePoint = Enemy.transform.Find("MissilePoint");
  CapsuleCollider2D collider = Enemy.GetComponent<CapsuleCollider2D>();
        
    switch(randomEnemy){

            case 0:
            SelectedCharacterSprite.sprite = SCALPEL;
            EnemyShip = new ScalpelSpaceship();
            enemyIdleAnimation.SetInteger("ShipIndex", 1);
            firepoint1.localPosition = new Vector2(-28.5f, 10.4f);
            firpoint2.localPosition = new Vector2(-34,0);
            missilePoint.localPosition = new Vector2(-5.3f, -4.4f);
            

            
            break;
            
            
            
            case 1:
            SelectedCharacterSprite.sprite = WARPER;
            
            EnemyShip = new WarperSpaceship();
            enemyIdleAnimation.SetInteger("ShipIndex", 2);
            firepoint1.localPosition = new Vector2(-28.5f, 10.4f);
            firpoint2.localPosition = new Vector2(-34,0);
            missilePoint.localPosition = new Vector2(-5.3f, -4.4f);
            
            break;
            
            case 2:
            SelectedCharacterSprite.sprite = ORION;
            EnemyShip = new OrionSpaceship();
            enemyIdleAnimation.SetInteger("ShipIndex", 0);
            firepoint1.localPosition = new Vector2(-28.5f, 10.4f);
            firpoint2.localPosition = new Vector2(-34,0);
            missilePoint.localPosition = new Vector2(-5.3f, -4.4f);
            
           break;
           
            
        }

        
    
       
       
  }





}
        


