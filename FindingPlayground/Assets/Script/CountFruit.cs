using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountFruit : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public Text scoreText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text =score.ToString();
    }

    
}
