using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerLives = 3;
    public int livesDefault = 3;
    public int highScore = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScore();
        }
        else { Destroy(gameObject); }
    }
    public void EndGame()
    {
        if (playerLives >= 0)
        {
            StartCoroutine("ContinueGame");
        }
        else
        {
            StartCoroutine("GameOver");
        }
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    public void LoadHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
    }


    private void OnApplicationQuit()
    {
        SaveHighScore();
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator ContinueGame()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("LivesScreen");
    }
}
