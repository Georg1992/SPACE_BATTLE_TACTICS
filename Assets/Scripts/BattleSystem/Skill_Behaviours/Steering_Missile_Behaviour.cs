using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering_Missile_Behaviour : MonoBehaviour
{
    public GameObject Enemy;
    public Missile MissilePrefab;
    public Transform firepoint;
    public Transform MissilePoint;
    public CoolDownManager WSlot;
    public GameObject wSkillSlot; 
    public Skill_Handler skill_Handler;
    public float speed;
    private bool cdEnd = true;
   

    public void Use(GameObject user){
        Enemy_AI aI = GameObject.Find("Enemy").GetComponent<Enemy_AI>();
        if(user == GameObject.Find("Player") && !Skill_Handler.isBroken && skill_Handler.WSlot.cdEnd && skill_Handler.state == Skill_Handler.ButtonState.wActive){
            
            Missile newMissile = (Missile) Instantiate(MissilePrefab, firepoint.position, Quaternion.identity);
            newMissile.gameObject.name = "PlayerMissile";
            StartCoroutine(newMissile.GetOutState(Enemy));
            
            skill_Handler.WSlot.CoolDownCounter(CreatePlayer.chosenShip.WSkill, skill_Handler.wSkillSlot);
            
            
        }
        if(user == GameObject.Find("Enemy") && !aI.isBroken && cdEnd){
            
            
            Skill sm = new SteeringMissile();
            Missile thisMissile = (Missile) Instantiate(MissilePrefab, MissilePoint.position, Quaternion.identity);
            thisMissile.gameObject.name = "EnemyMissile";
            thisMissile.transform.rotation = Quaternion.Euler(0,180f,0);
            thisMissile.EnemyShot();
            StartCoroutine(thisMissile.GetOutState(GameObject.Find("Player")));
            StartCoroutine(SimpleCoolDown(CreateEnemy.EnemyShip.WSkill.SkillCoolDown));
            
            
            
            
        }
        
      
    }


    public IEnumerator SimpleCoolDown(int skill_cooldown){
        cdEnd = false;
        yield return new WaitForSecondsRealtime(skill_cooldown);
        cdEnd = true;

    }

   

}
