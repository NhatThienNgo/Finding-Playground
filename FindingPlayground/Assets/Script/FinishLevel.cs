using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private UIManager uIManager;
    AudioManager audioManager;
    //private PlayerMovement movement;
    void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
        Animator anim = other.GetComponent<Animator>();

        if (other.CompareTag ("Player"))
        {
            uIManager.Victory();
            
            //stop movement
            if (playerMovement.isGrounded)
            {
                playerMovement.enabled = false;
                anim.SetBool("move", false);
                anim.SetBool("isGrounded", true);
                if (playerRigidbody != null)
                {
                    playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                }

            }



            audioManager.PlaySFX(audioManager.win);
        }
    }
}
