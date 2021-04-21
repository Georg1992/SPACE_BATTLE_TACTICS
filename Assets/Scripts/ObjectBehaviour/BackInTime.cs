using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackInTime : MonoBehaviour
{
    public static bool ReWinding = false;
    public List <PointInTime> pointsInTime;
   
    Rigidbody2D rb;
    public float slowDownFactor = 1;
    public bool Slowed = false;

    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(ReWinding == true && !Slowed){
            StartCoroutine(ScaleTime(2));
            
            
        }
        if(ReWinding == true && Slowed)
        ReWind();

        else{
            Record();
        }
        
            
        
    }

    void ReWind(){
        Time.timeScale =1;
        if(pointsInTime.Count > 0){
            
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
            
        }
    }
     IEnumerator ScaleTime(float time) {
     
     float lastTime = Time.realtimeSinceStartup;
     float timer = 0.0f;
     
     while (timer < time) {
         Time.timeScale = Mathf.Lerp (1, 0, timer / time);
         timer += (Time.realtimeSinceStartup - lastTime);
         lastTime = Time.realtimeSinceStartup;
         yield return null;
     }

     
     Time.timeScale = 0;
     Slowed = true;
     

    }

    void Record(){
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        if(pointsInTime.Count>5000){
            pointsInTime.RemoveAt(pointsInTime.Count-1);
        }
    }

    
}
