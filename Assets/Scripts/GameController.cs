using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Transform player;
    int score;
    [SerializeField]
    TextMeshProUGUI scoreTMP;
    [SerializeField]
    TextMeshProUGUI highscoreTMP;

    private void Start()
    {
        CheckHighscore();
    }

    void Update()
    {
        if (player.position.y < -25f)
            GameOver();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void GameOver()
    {
        CheckHighscore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ScoreUp()
    {
        score++;
        scoreTMP.text = "Score: " + score;
        CheckHighscore();
    }

    void CheckHighscore()
    {
        if (score > PlayerPrefs.GetInt("Score", 0))
            PlayerPrefs.SetInt("Score", score);

        highscoreTMP.text = "High Score: " + PlayerPrefs.GetInt("Score", 0);
    }
}
