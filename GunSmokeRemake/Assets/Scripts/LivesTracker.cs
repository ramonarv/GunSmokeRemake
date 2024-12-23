using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesTracker : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "LIVES : "+ GameManager.instance.playerLives.ToString();
        StartCoroutine(ContinueGame());
    }


    IEnumerator ContinueGame()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("Level1");
    }
}
