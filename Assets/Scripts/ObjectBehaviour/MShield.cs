using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MShield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shield());
    }

    // Update is called once per frame
    public IEnumerator Shield(){
        
        yield return new WaitForSecondsRealtime(4);
        Destroy(this.gameObject);
        StopCoroutine(Shield());
    }

    void OnTriggerEnter2D(Collider2D hitObject){
        

    }
}
