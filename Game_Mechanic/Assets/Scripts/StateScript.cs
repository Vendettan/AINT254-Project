using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScript : MonoBehaviour
{
    public Transform levelComplete;
    public Transform retryCanvas; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            ShowRetry();
        }

        if (other.CompareTag("Win"))
        {
            ShowComplete();
            Invoke("playerWin", 2.0f);
        }

        if (other.CompareTag("DeathZone"))
        {
            ShowRetry();
        }
    }

    public void playerWin()
    {        
        Application.LoadLevel("Level_Select");
    }

    public void playerLose()
    {
        Application.LoadLevel("Game_Over");
    }

    public void ShowComplete()
    {
        if (levelComplete.gameObject.activeInHierarchy == false)
        {
            levelComplete.gameObject.SetActive(true);
            Invoke("HideComplete", 2.0f);
        }
    }

    public void HideComplete()
    {
        if (levelComplete.gameObject.activeInHierarchy == true)
        {
            levelComplete.gameObject.SetActive(false);
        }
    }

    public void ShowRetry()
    {
        if (retryCanvas.gameObject.activeInHierarchy == false)
        {
            retryCanvas.gameObject.SetActive(true);
            Invoke("HideRetry", 5.0f);
            Invoke("playerLose", 5.0f);
        }
    }

    public void HideRetry()
    {
        if (retryCanvas.gameObject.activeInHierarchy == true)
        {
            retryCanvas.gameObject.SetActive(false);
        }
    }
}
