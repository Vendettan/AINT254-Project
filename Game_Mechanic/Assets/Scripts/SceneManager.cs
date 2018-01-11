using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private StateScript stateScript;

    [SerializeField]
    private Canvas pauseCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PlayButton()
    {
        Application.LoadLevel("Level_Select");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        Application.LoadLevel("Start_Menu");
    }

    public void LevelOnePlayButton()
    {
        Application.LoadLevel("Game_Mechanic_Lvl_2");
    }
	
	public void LevelOneRetryButton()
    {
        Application.LoadLevel("Game_Mechanic_Lvl_2");
    }

    public void LevelTwoPlayButton()
    {
        Application.LoadLevel("Game_Mechanic");
    }

    public void LevelTwoRetryButton()
    {
        Application.LoadLevel("Game_Mechanic");
    }

    public void ContinueButton()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        if (pauseCanvas.gameObject.activeInHierarchy == false)
        {
            Time.timeScale = 0;
            pauseCanvas.gameObject.SetActive(true);            
        }
        else
        {
            Time.timeScale = 1;
            pauseCanvas.gameObject.SetActive(false);
        }
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        MenuButton();
    }
    
}
