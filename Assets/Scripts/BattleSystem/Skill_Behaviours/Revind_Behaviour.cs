using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revind_Behaviour : MonoBehaviour
{
    public Skill_Handler skill_Handler;
    public Enemy_AI aI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Use(){
        BackInTime.ReWinding = true;
       
        yield return new WaitForSecondsRealtime(6);
        BackInTime.ReWinding = false;
        
    }
}
