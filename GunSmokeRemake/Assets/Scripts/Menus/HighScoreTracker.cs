using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreTracker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    private void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        highScoreText.text = "HIGH SCORE: " + GameManager.instance.highScore;
    }

}
