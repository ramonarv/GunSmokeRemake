using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;

    public int score = 0;
    public int scoreDefault = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else { Destroy(gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE: " + score.ToString();
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void AddPoint(int pointValue)
    {
        score += pointValue;
        scoreText.text = "SCORE: " + score.ToString();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject canvas = GameObject.Find("Canvas");

        TextMeshProUGUI textObject = canvas.transform.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();

        if (textObject != null)
        {
            scoreText = textObject;
            scoreText.text = "SCORE: " + score.ToString();
        }
    }
}
