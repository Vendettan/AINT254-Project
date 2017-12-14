using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private StateScript stateScript;

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
        Application.LoadLevel("Game_Mechanic");
    }
	
	public void LevelOneRetryButton()
    {
        Application.LoadLevel("Game_Mechanic");
    }
}
