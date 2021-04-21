using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class Skill_Handler : MonoBehaviour
{
    public static bool isBroken = false;
    public ButtonState state;
    
    public GameObject Player;
    public GameObject Enemy;
    public GameObject qSkillSlot;  
    public GameObject wSkillSlot;
    public GameObject eSkillSlot;
    public GameObject aSkillSlot;  
    public GameObject sSkillSlot;
    public GameObject dSkillSlot;
    public GameObject zSkillSlot;  
    public GameObject xSkillSlot;
    public GameObject cSkillSlot;

    public CoolDownManager QSlot;
    public CoolDownManager WSlot;
    public CoolDownManager ESlot;
    public CoolDownManager ASlot;
    public CoolDownManager SSlot;
    public CoolDownManager DSlot;
    public CoolDownManager ZSlot;
    public CoolDownManager XSlot;
    public CoolDownManager CSlot;
    

    public Basic_Attack_Behaviour ba_Behaviour;
    public Mirror_Shield_Behaviour mirror_Shield_Behaviour;
    public Orion_Move_Behaviour om_Behaviour;
    public Steering_Missile_Behaviour sm_Behaviour;
    public Blaster_Orb_Behaviour bo_Behaviour;
    public Teleporter_Behaviour tel_Behaviour;
    public Circle_Move_Behaviour circle_Move_Behaviour;
    public Desant_Behaviour desant_Behaviour;
    public Laser_Beam_Behaviour laser_Beam_Behaviour;
    public Invisible_Behaviour invisible_Behaviour;
    public Electric_Charge_Behaviour electric_Charge_Behaviour;
    public Revind_Behaviour revind_Behaviour;
    public Black_Hole_Behaviour black_Hole_Behaviour;
    public Shield_Behaviour shield_Behaviour;
    public AirForceCall_Behaviour airForceCall_Behaviour;
    
    
    
    private Image cantUse1;
    private Image cantUse2;
    private Image cantUse3;

    public List<CoolDownManager> AllSlotsCD;

    private Image ActiveImageQ;
    private Image ActiveImageW;
    private Image ActiveImageE;

    int counter = 0;

    

 
    void Start()
    {
       

        state = ButtonState.allOff;    
        
            cantUse1 = aSkillSlot.transform.GetChild(1).GetComponent<Image>();
            cantUse2 = sSkillSlot.transform.GetChild(1).GetComponent<Image>();
            cantUse3 = dSkillSlot.transform.GetChild(1).GetComponent<Image>();
            ActiveImageQ = qSkillSlot.transform.GetChild(1).GetComponent<Image>();
            ActiveImageW = wSkillSlot.transform.GetChild(1).GetComponent<Image>();
            ActiveImageE = eSkillSlot.transform.GetChild(1).GetComponent<Image>();
            AllSlotsCD = new List <CoolDownManager>(){QSlot,WSlot,ESlot,ASlot,SSlot,DSlot,ZSlot,XSlot,CSlot};
            
        

            
        Vector2 checkpoint = new Vector2(104,170);


        
        
            
    }
   


   
    void Update()
    {

       
        CantUse(cantUse1,cantUse2,cantUse3);
        
       
        
        
        
        if(Input.GetKeyDown(KeyCode.Q)){
            if(counter != 1)
            counter++;
            if(counter ==1 && state == ButtonState.qActive)
            counter--;
            if(counter ==1 && state != ButtonState.qActive)
            state = ButtonState.qActive;
                
            }
        if(Input.GetKeyDown(KeyCode.W)){
            if(counter != 1)
            counter++;
            if(counter ==1 && state == ButtonState.wActive)
            counter--;
            if(counter ==1 && state != ButtonState.wActive)
            state = ButtonState.wActive;
                
            }

        if(Input.GetKeyDown(KeyCode.E)){
            if(counter != 1)
            counter++;
            if(counter ==1 && state == ButtonState.eActive)
            counter--;
            if(counter ==1 && state != ButtonState.eActive)
            state = ButtonState.eActive;
            bo_Behaviour.blasterOn = true;
            }

        if(counter == 0){
            state = ButtonState.allOff;
        }

        
        

        switch(state){
            case ButtonState.qActive:
            ActiveImageQ.enabled = true;
            ActiveImageW.enabled = false;
            ActiveImageE.enabled = false;
            QSkill(CreatePlayer.chosenShip.QSkill.SkillIndex);
            break;

            case ButtonState.wActive:
            ActiveImageQ.enabled = false;
            ActiveImageW.enabled = true;
            ActiveImageE.enabled = false;
            WSkill(CreatePlayer.chosenShip.WSkill.SkillIndex);
            break;

            case ButtonState.eActive:
            ActiveImageQ.enabled = false;
            ActiveImageW.enabled = false;
            ActiveImageE.enabled = true;
            ESkill(CreatePlayer.chosenShip.ESkill.SkillIndex);
            break;

            case ButtonState.allOff:
            ActiveImageQ.enabled = false;
            ActiveImageW.enabled = false;
            ActiveImageE.enabled = false;
            break;

        }

        

        

        if(Input.GetKeyDown(KeyCode.A) && ASlot.cdEnd&&SSlot.cdEnd&&DSlot.cdEnd){
            ASkill(CreatePlayer.chosenShip.ASkill.SkillIndex);
               
            }
            
        if(Input.GetKeyDown(KeyCode.S) && SSlot.cdEnd&&ASlot.cdEnd&&DSlot.cdEnd){
            SSkill(CreatePlayer.chosenShip.SSkill.SkillIndex);
        }
        if(Input.GetKeyDown(KeyCode.D)&&DSlot.cdEnd&&ASlot.cdEnd&&SSlot.cdEnd){
            DSkill(CreatePlayer.chosenShip.DSkill.SkillIndex);
        }
        if(Input.GetKeyDown(KeyCode.Z) && ZSlot.cdEnd && !isBroken){
            ZSkill(CreatePlayer.chosenShip.ZSkill.SkillIndex);
        }
        if(Input.GetKeyDown(KeyCode.X) && XSlot.cdEnd && !isBroken){
            XSkill(CreatePlayer.chosenShip.XSkill.SkillIndex);
                
        }
        if(Input.GetKeyDown(KeyCode.C) && CSlot.cdEnd && !isBroken){
            CSkill(CreatePlayer.chosenShip.CSkill.SkillIndex);
           
        }
    
    }

    public enum ButtonState{
        
        qActive,
        allOff,
        wActive,
        
        eActive,
        

    }
    
    
    public void CantUse(Image cantUse1, Image cantUse2, Image cantUse3){
        if(ASlot.cdEnd==false){
            cantUse2.enabled = true;
            cantUse3.enabled = true;
        }else if(SSlot.cdEnd == false){
            cantUse1.enabled = true;
            cantUse3.enabled = true;
            
        }else if(DSlot.cdEnd == false){
            cantUse1.enabled = true;
            cantUse2.enabled = true;
        }else{
            cantUse1.enabled = false;
            cantUse2.enabled = false;
            cantUse3.enabled = false;
        }

    }


   
    
    public void QSkill(int skillIndex)
    {
        ba_Behaviour.Use(Player);
            
           
        
        
    }



    public void WSkill(int skillIndex)
    {

         
        sm_Behaviour.Use(Player);
            
         
    }

        
    public void ESkill(int skillIndex)
    {

         
        bo_Behaviour.Use(Player);
        
        
    }
    
    
    public void ASkill(int skillIndex)
    {

        
        om_Behaviour.Use(Player);
        
        ASlot.CoolDownCounter(CreatePlayer.chosenShip.ASkill, aSkillSlot);
    }

    public void SSkill(int skillIndex)
    {

        
        tel_Behaviour.Use(Player);
        
        SSlot.CoolDownCounter(CreatePlayer.chosenShip.SSkill, sSkillSlot);
    }

    public void DSkill(int skillIndex)
    {

         
        StartCoroutine(circle_Move_Behaviour.Use(Player));
        
        DSlot.CoolDownCounter(CreatePlayer.chosenShip.DSkill, dSkillSlot);
    }

    public void ZSkill(int skillIndex)
    {

         switch(skillIndex){
            case 6:
            mirror_Shield_Behaviour.Use(Player);
            break;
            case 10:
            StartCoroutine(invisible_Behaviour.Use(Player));
            break;
            case 14:
            shield_Behaviour.Use(Player);
            break;
         }
        ZSlot.CoolDownCounter(CreatePlayer.chosenShip.ZSkill, zSkillSlot);
    }

    public void XSkill(int skillIndex)
    {

         switch(skillIndex){
            case 8:
            desant_Behaviour.Use(Player);
            break;
            case 11:
            StartCoroutine(electric_Charge_Behaviour.Use(Player,Enemy));
            break;
            case 15:
            airForceCall_Behaviour.Use(Player);

            break;
         }
        XSlot.CoolDownCounter(CreatePlayer.chosenShip.XSkill, xSkillSlot);
        
        
    }

    public void CSkill(int skillIndex)
    {
        

         switch(skillIndex){
            case 9:
            laser_Beam_Behaviour.Use(Enemy, Player);
            break;
            case 12:
            StartCoroutine(revind_Behaviour.Use());
            break;
            case 13:
            StartCoroutine(black_Hole_Behaviour.Use(Player));
            break;
         }
        CSlot.CoolDownCounter(CreatePlayer.chosenShip.CSkill, cSkillSlot);
        
        
    }



    public void Broken(int t){

      
       
        
        
        foreach (CoolDownManager manager in AllSlotsCD)
        {
            
            isBroken = true;
            

            //cantUse1.enabled = true;
            //cantUse2.enabled = true;
           // cantUse3.enabled = true;
            

            manager.GlobalCounter(t,manager.gameObject);
        
        }
    }

    
}
