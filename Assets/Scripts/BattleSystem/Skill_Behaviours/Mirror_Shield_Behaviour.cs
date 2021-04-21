using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Shield_Behaviour : MonoBehaviour
{
    public MShield SpherePrefab;
    
 

    public void Use(GameObject whouse){
        Vector2 pos = new Vector2(whouse.transform.position.x, whouse.transform.position.y);
        var thisShpere = Instantiate(SpherePrefab, pos, Quaternion.identity);
        thisShpere.transform.parent = whouse.transform;
        
    }

    
}
