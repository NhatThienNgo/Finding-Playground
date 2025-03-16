using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject VictoryScreen;
    [SerializeField] private GameObject Dialogue;
    [SerializeField] private GameObject EndDialogue;
    [SerializeField] private GameObject NPC;
    [SerializeField] private GameObject Player;



    public void Awake()
    {
        GameOverScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        EndDialogue.SetActive(false);
        Dialogue.SetActive(true);
    }
    
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void Victory()
    {
        VictoryScreen.SetActive(true);
    }

    public void FinishDialogue()
    {
        Dialogue.SetActive(false);
        NPC.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowEndDialogue()
    {
        EndDialogue.SetActive(true);
    }

    public void FinishEndDialogue()
    { 
        EndDialogue.SetActive(false);
        Victory();

    }
}
