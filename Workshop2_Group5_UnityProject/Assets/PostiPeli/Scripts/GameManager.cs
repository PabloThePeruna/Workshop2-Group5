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
    public float spawnRate = 3.0f;
    private int score;
    private int mistakes;
    public List<GameObject> targets;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;

        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);

        mistakes = 0;
        UpdateMistakes(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            Debug.Log("Toimii");
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

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
