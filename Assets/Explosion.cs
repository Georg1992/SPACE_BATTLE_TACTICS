using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject expl;
    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = this.transform.position;
        
    }

    void OnDestroy(){
        
       GameObject explosion = Instantiate(expl ,pos, Quaternion.identity);
       Destroy(explosion, 1);
        
    }
    
}
