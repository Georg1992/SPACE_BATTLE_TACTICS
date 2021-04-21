using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreatePlayer : MonoBehaviour
{
 

    public Sprite SCALPEL, WARPER, ORION;
    public SpriteRenderer SelectedCharacterSprite;
    public Skill_Slot newSkillslot;

    private readonly string SelectedCharacter;
    
    public static BaseSpaceshipClass chosenShip;
    public HealthBar PlayerHealth;
    private Animator playerIdleAnimation;
    public GameObject Player;
    public static int getCharacter;
   
 


public void Start()
{
    playerIdleAnimation = Player.GetComponent<Animator>();
    PlayerCreation();
    newSkillslot.CreateSkillSlots();
    PlayerHealth.SetMaxHealth(chosenShip.MaxHealth);
    


 
}

public void PlayerCreation()
{
    SelectedCharacterSprite = this.GetComponent<SpriteRenderer>();
    getCharacter = PlayerPrefs.GetInt(SelectedCharacter);
    //BasePlayerClass Player = new BasePlayerClass(chosenShip);
    Transform firepoint1 = Player.transform.Find("Firepoint");
    Transform firpoint2 = Player.transform.Find("Firepoint3");
    Transform missilePoint = Player.transform.Find("MissilePoint");
        
        switch(getCharacter){

            case 0:
            SelectedCharacterSprite.sprite = SCALPEL;
            chosenShip = new ScalpelSpaceship();
            playerIdleAnimation.SetInteger("ShipIndex", 0);
            firepoint1.localPosition = new Vector2(28.5f, 10.4f);
            firpoint2.localPosition = new Vector2(34,0);
            missilePoint.localPosition = new Vector2(5.3f, -4.4f);
            
            break;
            
            
            
            case 1:
            SelectedCharacterSprite.sprite = WARPER;
            chosenShip = new WarperSpaceship();
            playerIdleAnimation.SetInteger("ShipIndex", 2);
            firepoint1.localPosition = new Vector2(6.7f, 14.8f);
            firpoint2.localPosition = new Vector2(34,0);
            missilePoint.localPosition = new Vector2(5.3f, -4.4f);
            
            break;
            
            case 2:
            SelectedCharacterSprite.sprite = ORION;
            chosenShip = new OrionSpaceship();
            playerIdleAnimation.SetInteger("ShipIndex", 1);
            firepoint1.localPosition = new Vector2(28.5f, 10.4f);
            firpoint2.localPosition = new Vector2(34, 0);
            missilePoint.localPosition = new Vector2(5.3f, -4.4f);
          
            break;
           
            
        }
        //return Player.SpaceshipClass;
        
    
       
       
}


}
    
  

  

