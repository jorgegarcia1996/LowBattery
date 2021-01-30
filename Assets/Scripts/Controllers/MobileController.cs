using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileController : MonoBehaviour
{
    #region ##### VARIABLES #####
    public Text timerText;
    public float batteryTimeRemaining = 120f;

    private float timer;
    private int min, sec;

    #endregion

    #region ##### EVENTS #####
    void Start() {
        timer = batteryTimeRemaining;
        timerText.text = SetTimerText();
    }
    
    void Update() {
        CountDown();
    }
    #endregion

    #region ##### METHODS #####

    private void CountDown() {
        if (GameManager.instance.isGameOver) {
            return;
        }

        if (timer <= 0) {
            GameManager.instance.GameOver();
        }

        timer -= Time.deltaTime;
        timerText.text = SetTimerText();
    }

    private string SetTimerText() {
        min = Mathf.FloorToInt(timer) / 60;
        sec = Mathf.FloorToInt(timer) % 60;
        if (sec < 10) {
            return min.ToString() + ":0" + sec.ToString();
        } else if (sec < 1) {
            return min.ToString() + ":00";
        }
        return min.ToString() + ":" + sec.ToString();

    }
    #endregion
}
