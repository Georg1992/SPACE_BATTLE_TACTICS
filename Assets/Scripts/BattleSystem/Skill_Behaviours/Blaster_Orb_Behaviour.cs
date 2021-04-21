using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster_Orb_Behaviour : MonoBehaviour
{
    
    private ParticleSystem blaster;
    private Skill_Handler skill_Handler;
    public bool blasterOn;
    private Enemy_AI aI;
    private bool runCD;

   
    // Start is called before the first frame update
    void Start()
    {
        
        skill_Handler = GameObject.Find("Player").GetComponent<Skill_Handler>();
        aI = GameObject.Find("Enemy").GetComponent<Enemy_AI>();
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
   
        ParticleSystem PlayersBlaster = GameObject.Find("Player/Firepoint3/Blaster").GetComponent<ParticleSystem>();
        
        if(skill_Handler.state != Skill_Handler.ButtonState.eActive && PlayersBlaster.isEmitting){
            runCD = true;
            PlayersBlaster.Stop();
            
            }

        else if(runCD){
            skill_Handler.ESlot.CoolDownCounter(CreatePlayer.chosenShip.ESkill, skill_Handler.eSkillSlot);
            runCD = false;
        }

        
       
        
      
    }
    public void BlasterOff(GameObject user){
        blaster = user.transform.Find("Firepoint3").transform.Find("Blaster").GetComponent<ParticleSystem>();
        blaster.Stop();
        blasterOn =false;

    }
   

    public void Use(GameObject user){
        
        if(user == GameObject.Find("Player") && !Skill_Handler.isBroken){
           
            blaster = user.transform.Find("Firepoint3/Blaster").GetComponent<ParticleSystem>();
            if(skill_Handler.state == Skill_Handler.ButtonState.eActive && blasterOn && !Skill_Handler.isBroken && skill_Handler.ESlot.cdEnd){
              
                blaster.Play();
                blasterOn = false;
            }
        }


        if(user == GameObject.Find("Enemy") && !aI.isBroken){
            
            blaster = user.transform.Find("Firepoint3/Blaster").GetComponent<ParticleSystem>();
            OrbDirection particles = user.transform.Find("Firepoint3/Blaster").GetComponent<OrbDirection>();
            particles.EnemyShot();
            if(blasterOn){
              
                blaster.Play();
                
            }
        }
        

    }
        
      
}


    




