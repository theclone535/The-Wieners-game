using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DayTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textTimer;
    [SerializeField] bool dayStarted;
    [SerializeField] float dayLength = 180;//3 minutes
    [SerializeField] bool dayOver;
    [SerializeField] bool starting;

    public float timer;

    void Start()
    {
        timer = dayLength;
        starting = true;
        Time.timeScale = 30;
        
    }

    void Update()
    {
        
        if (starting)
        {
            starting = false;
            dayStarted = true;
            dayLength += Time.fixedTime;
        }

        if (dayStarted)
        {
            timer =  dayLength - Time.fixedTime;
            textTimer.text = "Time Left:" + (int)timer + "s";

        }

        if (timer <= 0)
        {
            dayOver = true;
        }

        if (dayOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
