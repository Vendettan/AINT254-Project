using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private Image timerImage;
    private float timeToCount = 5;    
    private float time;
    [SerializeField]
    private Text countdownText;

    private void Start()
    {
        timerImage = this.GetComponent<Image>();
        time = timeToCount;
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timerImage.fillAmount = time / timeToCount;
            countdownText.text = time.ToString("N0");
        }
        if (time <=0)
        {
            Application.LoadLevel("Game_Over");
        }
    }


}
