using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMove : MonoBehaviour
{
    private float t;
    private float speed;
    private Vector2 initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void Moving(){
        t += Time.deltaTime;
        float x = Mathf.Cos(t);
        float y = Mathf.Sin(t);
        transform.position =initPos + new Vector2(x,y) * 5;
    }
}
