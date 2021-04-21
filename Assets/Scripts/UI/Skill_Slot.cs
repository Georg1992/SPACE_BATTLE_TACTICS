using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Slot : MonoBehaviour
{
   //public Skill SignedSkill;
   private Image qImg;
   private Image wImg;
   private Image eImg;
   private Image aImg;
   private Image sImg;
   private Image dImg;
   private Image zImg;
   private Image xImg;
   private Image cImg;

   
   
    public GameObject qSkillSlot;  
    public GameObject wSkillSlot;
    public GameObject eSkillSlot;
    public GameObject aSkillSlot;  
    public GameObject sSkillSlot;
    public GameObject dSkillSlot;
    public GameObject zSkillSlot;  
    public GameObject xSkillSlot;
    public GameObject cSkillSlot;
    
 
    
  

  



   public void CreateSkillSlots()
   {
      
      qImg = qSkillSlot.GetComponent<Image>();
      wImg = wSkillSlot.GetComponent<Image>();
      eImg = eSkillSlot.GetComponent<Image>();
      aImg = aSkillSlot.GetComponent<Image>();
      sImg = sSkillSlot.GetComponent<Image>();
      dImg = dSkillSlot.GetComponent<Image>();
      zImg = zSkillSlot.GetComponent<Image>();
      xImg = xSkillSlot.GetComponent<Image>();
      cImg = cSkillSlot.GetComponent<Image>();

      qImg.sprite = Resources.Load<Sprite>("Target");
      wImg.sprite = Resources.Load<Sprite>("rocket");
      eImg.sprite = Resources.Load<Sprite>("lazer");
      aImg.sprite = Resources.Load<Sprite>("moveskill");
      sImg.sprite = Resources.Load<Sprite>("teleport");
      dImg.sprite = Resources.Load<Sprite>("goRound");
      
      
      if(CreatePlayer.chosenShip.SpaceshipClassName == "Warper"){
         zImg.sprite = Resources.Load<Sprite>("invisible");
         xImg.sprite = Resources.Load<Sprite>("thunder");
         //cImg.sprite = Resources.Load<Sprite>("");


      }
        
      
        
        
        
   
   }
}

