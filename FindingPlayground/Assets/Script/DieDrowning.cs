using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieDrowning : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        //PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

        if (health != null)
        {

            health.DieDrowning();

        }

    }
}
