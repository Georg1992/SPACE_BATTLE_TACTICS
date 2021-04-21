using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class Basic_Attack_Behaviour : MonoBehaviour
{
    public BulletDirection Bullet;
    public Transform firepoint;
    
    private Skill_Handler skill_Handler;
    public bool playerShot;

    private bool cdEnd = true;
    void Start(){
        skill_Handler = GameObject.Find("Player").GetComponent<Skill_Handler>();
    }
    
    public void Use(GameObject user){
        Enemy_AI aI = GameObject.Find("Enemy").GetComponent<Enemy_AI>();
        CoolDownManager aiCDMaganger = GameObject.Find("Enemy").GetComponent<CoolDownManager>();
        Skill ba = new BasicAttack();
        if(user == GameObject.Find("Player") &&!Skill_Handler.isBroken && skill_Handler.QSlot.cdEnd && skill_Handler.state == Skill_Handler.ButtonState.qActive){
            
            playerShot = true;
            BulletDirection thisBullet = Instantiate(Bullet, firepoint.position, Quaternion.identity);
            thisBullet.gameObject.name = "PlayerBullet";

            skill_Handler.QSlot.CoolDownCounter(CreatePlayer.chosenShip.QSkill, skill_Handler.qSkillSlot);
        }

        if(user == GameObject.Find("Enemy") && !aI.isBroken && cdEnd){
            
            BulletDirection thisBullet = (BulletDirection) Instantiate(Bullet, firepoint.position, Quaternion.identity);
            thisBullet.transform.rotation = Quaternion.Euler(0,180f,0);
            thisBullet.gameObject.name = "EnemyBullet";
            thisBullet.EnemyShot();

            if(Circle_Move_Behaviour.enemyCircleMove)
                ba.SkillCoolDown = 1;
            
            StartCoroutine(SimpleCoolDown(CreateEnemy.EnemyShip.QSkill.SkillCoolDown));
        
        }
       
      
    }
    public IEnumerator SimpleCoolDown(int skill_cooldown){
        cdEnd = false;
        yield return new WaitForSecondsRealtime(skill_cooldown);
        cdEnd = true;

    }
}
