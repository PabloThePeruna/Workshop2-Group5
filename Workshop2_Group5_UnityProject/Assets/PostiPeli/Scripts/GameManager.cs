using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI mistakesText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    private int score;
    private int mistakes;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        
        score = 0;
        UpdateScore(0);

        mistakes = 0;
        UpdateMistakes(0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //päivittää pisteet
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Pisteet: " + score;
    }

    // päivitää virheet
    public void UpdateMistakes(int mistakesToAdd)
    {
        mistakes += mistakesToAdd;
        mistakesText.text = "Virheet: " + mistakes + " / 3";
        if (mistakes == 3)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
