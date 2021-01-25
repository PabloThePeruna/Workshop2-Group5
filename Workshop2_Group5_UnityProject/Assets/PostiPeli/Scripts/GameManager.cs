using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI mistakesText;
    public bool isGameActive;
    public float spawnRate = 3.0f;
    private int score;
    private int mistakes;
    public List<GameObject> targets;
    public GameObject titleScreen;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //luo satunnaisia posteja
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
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

    //Aloittaa pelin
    public void StartGame()
    {
        isGameActive = true;

        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);

        mistakes = 0;
        UpdateMistakes(0);

        titleScreen.gameObject.SetActive(false);
    }

    //Avaa GameOver valikon
    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
    }

    //Tuo takaisin valikkoon
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Sammuttaa pelin
    public void QuitGame()
    {
        Application.Quit();
    }
}
