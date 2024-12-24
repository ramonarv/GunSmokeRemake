using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    private TextMeshProUGUI finalScoreText;
    private TextMeshProUGUI highScoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        finalScoreText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        highScoreText = GetComponentInChildren<TextMeshProUGUI>();
        finalScoreText.text = "FINAL SCORE: " + ScoreManager.instance.score.ToString();
        StartCoroutine("RestartGame");
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2);
        if (ScoreManager.instance.score > GameManager.instance.highScore)
        {
            highScoreText.text = "NEW HIGH SCORE!";
            GameManager.instance.highScore = ScoreManager.instance.score;
        }
        GameManager.instance.playerLives = GameManager.instance.livesDefault;
        ScoreManager.instance.score = ScoreManager.instance.scoreDefault;
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("MainMenu");
    }
}
