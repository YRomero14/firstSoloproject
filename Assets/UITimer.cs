using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    public AudioSource losesound;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {  if (timeText == null) return;
     GameObject gameObject = GameObject.Find("player");
     Controller controller = gameObject.GetComponent<Controller>();
        if (timerIsRunning)
        {
            if (controller.IsWinner())
            { 
                timerIsRunning = false;
                timeText.text = "";
            }
            else if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeText.text = "Game Over";
                timeRemaining = 0;
                timerIsRunning = false;
                losesound.Play();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    { if (timeText == null) return;
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}