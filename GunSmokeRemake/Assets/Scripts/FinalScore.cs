using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    private TextMeshProUGUI finalScoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        finalScoreText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        finalScoreText.text = "FINAL SCORE: " + ScoreManager.instance.score.ToString();
        StartCoroutine("RestartGame");
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2);
        GameManager.instance.playerLives = GameManager.instance.livesDefault;
        ScoreManager.instance.score = ScoreManager.instance.scoreDefault;
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("MainMenu");
    }
}
