using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRoted : MonoBehaviour
{

    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput*speed*Time.deltaTime);
    }
}
