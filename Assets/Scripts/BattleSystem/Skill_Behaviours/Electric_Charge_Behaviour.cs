using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric_Charge_Behaviour : MonoBehaviour
{
    public ParticleSystem LightningPrefab;
    public static bool ElectricChargeOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Use(GameObject user, GameObject target){
        if(user == GameObject.Find("Player")){
        var myLightning = Instantiate(LightningPrefab,user.transform.position, Quaternion.AngleAxis(90,Vector3.up));
        myLightning.transform.parent = GameObject.Find("Player").transform;
        }
        if(user == GameObject.Find("Enemy")){
        var myLightning = Instantiate(LightningPrefab,user.transform.position, Quaternion.AngleAxis(-90,Vector3.up));
        myLightning.transform.parent = GameObject.Find("Enemy").transform;
        }

        ElectricChargeOn = true;
        yield return new WaitForSecondsRealtime(3);
        ElectricChargeOn = false;
        
        
    }

   
   
  
    
}
