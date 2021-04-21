using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desant_Behaviour : MonoBehaviour
{
   
    public GameObject firepoint;
    public GameObject firepoint2;
    public GameObject firepoint3;
    public GameObject Player;
    public GameObject Enemy;
    
    public Astro AstroPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Use(GameObject whouse){
       Astro Astro1= (Astro) Instantiate(AstroPrefab,firepoint.transform.position, Quaternion.identity);
       Astro Astro2 =(Astro) Instantiate(AstroPrefab,firepoint2.transform.position, Quaternion.identity);
       Astro Astro3 =(Astro) Instantiate(AstroPrefab,firepoint3.transform.position, Quaternion.identity);
       StartCoroutine(Astro1.Astro1(Enemy));
       StartCoroutine(Astro2.Astro2(Enemy));
       StartCoroutine(Astro3.Astro3(Enemy));
       

       

    }

}
