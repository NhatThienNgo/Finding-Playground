using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndDialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] sentences;
    public float textSpeed;
    private int index;
    private UIManager uiMan;
    private PlayerMovement playerMovement;
    private Animator anim;


    void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.enabled = false;
        uiMan = FindObjectOfType<UIManager>();
        text.text = string.Empty;
    }
   

    void Update()
    {
        //two ways to continue the dialogue
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (text.text == sentences[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = sentences[index];
            }
        }
    }


    public void StartDialogue()
    {
        playerMovement.enabled = false;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            uiMan.FinishEndDialogue();
            playerMovement.enabled = false;

        }
    }
}