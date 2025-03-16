using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrallax : MonoBehaviour
{
    private float startingPos, length;
    public GameObject cam;
    public float parallax;

    
    void Start()
    {
        startingPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        //StartingPosZ = transform.position.z;
    }

    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallax;
        float movement = cam.transform.position.x *(1- parallax);

        transform.position = new Vector3(startingPos + distance, transform.position.y, transform.position.z );

        if (movement > startingPos + length)
        {
            startingPos += length;
        }
        else if (movement < startingPos - length)
        {
            startingPos -= length;
        }
    }
}