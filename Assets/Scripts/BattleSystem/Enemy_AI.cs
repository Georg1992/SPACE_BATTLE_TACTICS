using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Enemy_AI : MonoBehaviour

{
    public Astro AstroPrefab;
    public Transform firepoint;
    public GameObject Player;
    public GameObject Enemy;
    
    public bool isBroken;
    
    private Basic_Attack_Behaviour ba_Behaviour;
    private Mirror_Shield_Behaviour mirror_Shield_Behaviour;
    private Orion_Move_Behaviour om_Behaviour;
    private Steering_Missile_Behaviour sm_Behaviour;
    private Blaster_Orb_Behaviour bo_Behaviour;
    private Teleporter_Behaviour tel_Behaviour;
    private Circle_Move_Behaviour circle_Move_Behaviour;
    private Desant_Behaviour desant_Behaviour;
    private Laser_Beam_Behaviour laser_Beam_Behaviour;
    private Invisible_Behaviour invisible_Behaviour;
    private Electric_Charge_Behaviour electric_Charge_Behaviour;
    private Revind_Behaviour revind_Behaviour;
    private Black_Hole_Behaviour black_Hole_Behaviour;
    private bool movingSkillRunning = false;
    private bool randomisingBlaster = true;
    private int blasterChance;

    bool UseZSkill = true;

   
    

    void Start()
    {
        electric_Charge_Behaviour = GetComponent<Electric_Charge_Behaviour>();
        mirror_Shield_Behaviour = GetComponent<Mirror_Shield_Behaviour>();
        ba_Behaviour = GetComponent<Basic_Attack_Behaviour>();
        sm_Behaviour = GetComponent<Steering_Missile_Behaviour>();
        om_Behaviour = GetComponent<Orion_Move_Behaviour>();
        bo_Behaviour = GetComponent<Blaster_Orb_Behaviour>();
        tel_Behaviour = GetComponent<Teleporter_Behaviour>();
        circle_Move_Behaviour = GetComponent<Circle_Move_Behaviour>();
        desant_Behaviour = GetComponent<Desant_Behaviour>();
        laser_Beam_Behaviour = GetComponent<Laser_Beam_Behaviour>();
        invisible_Behaviour = GetComponent<Invisible_Behaviour>();
        revind_Behaviour = GetComponent<Revind_Behaviour>();
        black_Hole_Behaviour = GetComponent<Black_Hole_Behaviour>();

        
    }
    
    void Update()
    {
        if(!isBroken){
            StartCoroutine(MovingSkills());
            UseSkills();
        }
        SepcialSkills();
        ScanAll();
      
    }

    
    
    public void UseSkills(){
        if(!bo_Behaviour.blasterOn){
        ba_Behaviour.Use(Enemy);
        sm_Behaviour.Use(Enemy);
        }
        if(randomisingBlaster){
            StartCoroutine(BlasterOnChance());
        }
        


        
    }

    private IEnumerator BlasterOnChance(){
        while(!bo_Behaviour.blasterOn){
            blasterChance = Random.Range(0,6);
            randomisingBlaster = false;
            yield return new WaitForSecondsRealtime(2);
            
            if(blasterChance == 3){
                bo_Behaviour.blasterOn = true;
                bo_Behaviour.Use(Enemy);
                yield return new WaitForSecondsRealtime(Random.Range(4,8));
                bo_Behaviour.BlasterOff(Enemy);
                yield return new WaitForSecondsRealtime(CreateEnemy.EnemyShip.ESkill.SkillCoolDown);
                
            }
            randomisingBlaster = true;
        }
       
    }

    private void SepcialSkills(){
        switch (CreateEnemy.EnemyShip.SpaceshipClassName){
            case "Scalpel":

            break;
            case "Warper":
            if(UseZSkill){
            StartCoroutine(invisible_Behaviour.Use(Enemy));
            UseZSkill = false;
            }
            break;
            case "Orion":

            break;

        }
    }

    private IEnumerator MovingSkills(){
       
        while(!movingSkillRunning){

            switch (Random.Range(0,3)){
            case 0:
            Skill om = new OrionMove();
            om_Behaviour.Use(Enemy);
            movingSkillRunning = true;
            yield return new WaitForSeconds(om.SkillCoolDown);
            movingSkillRunning =false;
            break;

            case 1:
            Skill tel = new Teleporter();
            tel_Behaviour.Use(Enemy);
            movingSkillRunning = true;
            yield return new WaitForSeconds(tel.SkillCoolDown);
            movingSkillRunning = false;
            break;

            case 2:
            Skill cir = new CircleMove();
            StartCoroutine(circle_Move_Behaviour.Use(Enemy));
            movingSkillRunning = true;
            yield return new WaitForSeconds(cir.SkillCoolDown);
            movingSkillRunning = false;
            break;
            }
        }

    }


    

        
    public IEnumerator UseDesant(Skill skill){
       bool cdEnd = true;
        while(cdEnd == true && !isBroken){
            
            int skill_cooldown = skill.SkillCoolDown;

            Astro Astro1= (Astro) Instantiate(AstroPrefab,firepoint.transform.position, Quaternion.identity);
            Astro Astro2 =(Astro) Instantiate(AstroPrefab,firepoint.transform.position, Quaternion.identity);
            Astro Astro3 =(Astro) Instantiate(AstroPrefab,firepoint.transform.position, Quaternion.identity);
            Astro1.PlayerShot=false;
            Astro2.PlayerShot=false;
            Astro3.PlayerShot=false;
            StartCoroutine(Astro1.Astro1(Player));
            StartCoroutine(Astro2.Astro2(Player));
            StartCoroutine(Astro3.Astro3(Player));
            cdEnd = false;
            
            
            yield return new WaitForSecondsRealtime(skill_cooldown);
            cdEnd = true;
        }
   }

   public  IEnumerator BrokenAI(int t){
       
       
    isBroken = true;
    
    yield return new WaitForSecondsRealtime(t);
    
    isBroken = false;
    
    
    }

    public void ScanAll(){
        Vector2 pos = this.transform.position;
        GameObject playerMissile = GameObject.Find("PlayerMissile");
        if(playerMissile!=null){
            Vector2 playerMissilePos = playerMissile.transform.position;
            if(Vector2.Distance(pos,playerMissilePos)<30){
                UseZSkill = true;
            }


        }
        
        
    }
}
