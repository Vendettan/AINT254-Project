using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

	public void PlayButton()
    {
        Application.LoadLevel("Game_Mechanic");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
	
	
}
