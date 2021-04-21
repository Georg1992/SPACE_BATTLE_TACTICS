using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem lightning = this.GetComponent<ParticleSystem>();
        lightning.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
     if(!Electric_Charge_Behaviour.ElectricChargeOn){
         Destroy(this.gameObject);
     }
        
    }


}
