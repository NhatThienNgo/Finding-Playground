using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    public bool isGrounded;
    public CountFruit countFruit;
    AudioManager audioManager;
    private UIManager uiMan;
    public GameObject Dialogue2;
    private EndDialogue EndDialogue;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrounded = false;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }



    private void Update()
    {
        float horizonatlInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizonatlInput * speed, body.velocity.y);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (horizonatlInput > 0.01f)
            spriteRenderer.flipX = false;
        else if (horizonatlInput < -0.01f)
            spriteRenderer.flipX = true;

        if (Input.GetKey(KeyCode.Space) && isGrounded)
            Jump();

        anim.SetBool("move", horizonatlInput != 0);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        audioManager.PlaySFX(audioManager.jump);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Grounded");
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("EndPoint"))
        {
            EndDialogue = Dialogue2.GetComponent<EndDialogue>();
            uiMan = FindObjectOfType<UIManager>();
            Dialogue2.SetActive(true);
            EndDialogue.StartDialogue();
            anim.SetBool("move", false);
            anim.SetBool("isGrounded", true);


        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            audioManager.PlaySFX(audioManager.collect);
            countFruit.score++;
            Destroy(other.gameObject);
        }
    }


}