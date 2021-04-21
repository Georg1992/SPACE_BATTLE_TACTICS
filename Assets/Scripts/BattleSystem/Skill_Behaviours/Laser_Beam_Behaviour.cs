using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Laser_Beam_Behaviour : MonoBehaviour
{


    private Transform firepoint;
    
    public GameObject LaserPrefab;
    private LaserEndBehaviour laserEnd;
   
   
    // Start is called before the first frame update
    void Start()
    {
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
                
        
    }
    public void Use(GameObject target, GameObject user){


        firepoint = user.transform.Find("Firepoint");
        GameObject laserPrefab = (GameObject) Instantiate (LaserPrefab, firepoint.transform.position , Quaternion.identity);
        laserEnd = (LaserEndBehaviour) laserPrefab.transform.GetComponentInChildren<LaserEndBehaviour>();
        
        StartCoroutine(laserEnd.FlyState(target));
        StartCoroutine(laserEnd.CastLaser(target, user));
        
       
    }



    

    
}
