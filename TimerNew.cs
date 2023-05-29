using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerNew : MonoBehaviour
{

    public float time;
    public bool CountingTime = true;
    private float minutes;
    private float seconds;
    public TextMeshProUGUI text;
    private string niceTime;

   

    void Update()
    {
        if (CountingTime)
        {
            time += Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time - minutes * 60);
            niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            text.text = niceTime;
        }
    }

    public void StopTimerAndSendNewScore()
    {
        CountingTime = false;
        GameManager.Instance.SetNewScore(time, niceTime);
    }


    
}