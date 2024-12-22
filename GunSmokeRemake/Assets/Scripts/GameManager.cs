using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerLives = 3;
    public int livesDefault = 3;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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

    IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(4);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator ContinueGame()
    {
        yield return new WaitForSecondsRealtime(4);
        SceneManager.LoadScene("LivesScreen");
    }
}
