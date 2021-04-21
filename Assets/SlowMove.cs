using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMove : MonoBehaviour
{
    private Transform[] transforms;
    private float[] speeds;
    private Vector2[] directions;
    private float speed;
  
    // Start is called before the first frame update
    void Start()

    {
      Vector2 left = new Vector2(-200, 0);
      Vector2 right = new Vector2 (200,0);
      Vector2 comet = new Vector2(-400, -300 );
      transforms = this.transform.GetComponentsInChildren<Transform>();
      speeds = new float[] {0, 0, 0, 5 ,0};
      directions = new Vector2[] {this.transform.position,left,right,comet,right};
      
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<= 4; i++){
            
            BackgroundMove(speeds[i], directions[i], transforms[i]);
        }
    }


    public void BackgroundMove(float speed, Vector2 direction, Transform element){
        float t = Time.deltaTime * speed;
        
        element.position= Vector2.MoveTowards(element.position, direction,t);

    }
}
