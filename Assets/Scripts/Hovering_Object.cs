using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hovering_Object : MonoBehaviour
{
      public float verticalSpeed;
      public float Amplitude;
      Vector2 tempPosition;
    // Start is called before the first frame update
    void Start()
    {
        tempPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempPosition.y = tempPosition.y + (Mathf.Sin(Time.realtimeSinceStartup*verticalSpeed)*Amplitude);
        transform.position = tempPosition;
    }
}
