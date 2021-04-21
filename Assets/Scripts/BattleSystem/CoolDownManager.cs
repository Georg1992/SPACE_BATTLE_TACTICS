using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;


public class CoolDownManager : MonoBehaviour
{
   
    public Skill signedSkill;
    public Stopwatch cooldown;
    public Stopwatch glcooldown;
    public bool cdEnd;
    public bool GlobalCD;
    private Image fillImage;
    private int skillCoolDown;
    public GameObject usedSlot;  
 
  
    

  void Start()
  {
      
   cdEnd = true;   
     
  }
    
  

    

public void CoolDownCounter(Skill usedSkill, GameObject slot)
{
  signedSkill = usedSkill;
  usedSlot = slot;

  fillImage = usedSlot.transform.GetChild(0).gameObject.GetComponent<Image>();
  fillImage.fillAmount = 1;
  cooldown = new Stopwatch();
  cooldown.Start();
  cdEnd = false;
  StartCoroutine(CoolDownAnimation());
}


private IEnumerator CoolDownAnimation(){
  while(!Skill_Handler.isBroken && cooldown.IsRunning && cooldown.Elapsed.TotalSeconds < signedSkill.SkillCoolDown){
    fillImage.fillAmount = ((float)cooldown.Elapsed.TotalSeconds / signedSkill.SkillCoolDown);
    yield return null; 
  }

  fillImage.fillAmount = 0;
  cooldown.Stop();
  cdEnd = true;
  cooldown.Reset();

}



public void GlobalCounter(int cd, GameObject slot)
{
  usedSlot = slot;
  fillImage = usedSlot.transform.GetChild(0).gameObject.GetComponent<Image>();
  fillImage.fillAmount = 1;
  glcooldown = new Stopwatch();
  glcooldown.Start();
  cdEnd = false;
  StartCoroutine(GlobalAnimation(cd));

}




private IEnumerator GlobalAnimation(int cd){
  while(glcooldown.IsRunning && glcooldown.Elapsed.TotalSeconds < cd){
  fillImage.fillAmount = ((float)glcooldown.Elapsed.TotalSeconds / cd);
  yield return null; 
  }

fillImage.fillAmount = 0;
glcooldown.Stop();
cdEnd = true;
Skill_Handler.isBroken= false;
glcooldown.Reset();


}






public IEnumerator SimpleCoolDown(int skill_cooldown){
  cdEnd = false;
  yield return new WaitForSecondsRealtime(skill_cooldown);
  cdEnd = true;

}
   

  
    
}
