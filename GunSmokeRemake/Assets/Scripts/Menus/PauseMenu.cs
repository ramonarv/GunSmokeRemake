using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUi;


    // Update is called once per frame
    void Update()
    {

        if (!PlayerStatus.instance.isPlayerDead && Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void QuitGame()
    {
        GameManager.instance.playerLives = GameManager.instance.livesDefault;
        ScoreManager.instance.score = ScoreManager.instance.scoreDefault;
        Time.timeScale = 1.0f;
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }


}
