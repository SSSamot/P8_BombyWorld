using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool gamePause = false;

    public GameObject pauseMenu;
    public GameObject gameUI;

    public static UIManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance de 'UIManager' dans la scène");
            return;
        }

        instance = this;
    }

    /*void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePause)
            {
                Pause();
            }
        }
    }*/

    public void Pause()
    {
        gamePause = true;
        Time.timeScale = 0;
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        gamePause = false;
        Time.timeScale = 1;
        gameUI.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Restart(string nameScene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nameScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
