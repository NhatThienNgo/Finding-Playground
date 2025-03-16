using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float fallDmg = 8f;
    public float HealthCurrent { get; private set; }
    private Animator anim;
    private Rigidbody2D body;
    private bool dead;
    Vector2 startPos;
    private UIManager uiMan;
    private float lastY;
    AudioManager audioManager;


    private void Awake()
    {
        startPos = transform.position;
        HealthCurrent = startingHealth;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        uiMan = FindObjectOfType<UIManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        lastY = transform.position.y;   
        
    }

    public void takeDmg(float dmg)
    {
        HealthCurrent = Mathf.Clamp(HealthCurrent - dmg, 0, startingHealth);
        if (HealthCurrent > 0)
        {
            anim.SetTrigger("hurt");            
        }
        else
        {
            Die();
        }
    }

    private void Update()
    {
        //for testing only 
        if (Input.GetKeyDown(KeyCode.R))
        {
            takeDmg(1);
        }


        if (lastY-transform.position.y > fallDmg)
        {
            takeDmg(1);
        }

        lastY = transform.position.y;
    }



    public void Die()
    {
        HealthCurrent = 0;
        anim.SetTrigger("die");
        audioManager.PlaySFX(audioManager.lose);
        //stop player movement
        GetComponent<PlayerMovement>().enabled = false;
        uiMan.GameOver();
    }

    public void DieDrowning()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();  
        anim.SetTrigger("drown");
        //stop player movement
        HealthCurrent = 0;  
        audioManager.PlaySFX(audioManager.lose);
        playerMovement.enabled = false;
        uiMan.GameOver();
        StartCoroutine(FloatAfterDelay(2f));
    }

    private GameObject NearestSurface()
    {
        GameObject[] surfaces = GameObject.FindGameObjectsWithTag("Surface");
        GameObject nearestSurface = null;
        float minDis = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (GameObject surface in surfaces)
        {
            float dist = Vector3.Distance(surface.transform.position, currentPos);
            if (dist < minDis)
            {
                minDis = dist;
                nearestSurface = surface;
            }
        }

        return nearestSurface;
    }

    private IEnumerator FloatAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject nearestSurface = NearestSurface();
        StartCoroutine(Float(new Vector2(transform.position.x, nearestSurface.transform.position.y), 1f));
    }

    public IEnumerator Float(Vector2 targetPos, float duration)
    {
        Vector2 currentPos = transform.position;
        float time = 0f;

        while (time < 1)
        {
            transform.position = Vector2.Lerp(currentPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        //disable gravity
        //issue: character is not blocking by the ground
        body.simulated = false;
    }
}


