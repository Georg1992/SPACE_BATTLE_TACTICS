using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Linq;

public class Invisible_Behaviour : MonoBehaviour
{
    float m_Red;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public IEnumerator Use(GameObject user){
       Stopwatch stopwatch = new Stopwatch();
       user.GetComponent<Collider2D>().enabled = false;
       spriteRenderer= user.GetComponent<SpriteRenderer>();
       Color noRed = spriteRenderer.color;
       stopwatch.Start();
       while(stopwatch.Elapsed.Seconds<=5){
           noRed.a = 0;
           
           spriteRenderer.color = noRed;
           
           yield return new WaitForSeconds(0.1f);
           noRed.a = 1;
           noRed.r = 0;
           spriteRenderer.color = noRed;
           yield return new WaitForSeconds(0.1f);
       }
       noRed.r = 1;
       noRed.a = 1;
       spriteRenderer.color = noRed;
       stopwatch.Stop();
       stopwatch.Reset();
       user.GetComponent<Collider2D>().enabled = true;

    }
}
