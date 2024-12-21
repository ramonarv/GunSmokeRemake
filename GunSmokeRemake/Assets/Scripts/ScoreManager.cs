using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;

    int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void AddPoint(int pointValue)
    {
        score += pointValue;
        scoreText.text = "SCORE: " + score.ToString();
    }
}
