using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayTimer : MonoBehaviour
{
    [SerializeField] bool dayStarted;
    [SerializeField] float dayLength = 180f;//3 minutes
    [SerializeField] bool dayOver;

    public float timer;

    void Start()
    {
        timer = dayLength;
    }

    void Update()
    {

        if (Input.GetKeyDown("f"))
        {
            dayStarted = true;
            dayLength += Time.fixedTime;
        }

        if (dayStarted)
        {
            
            timer =  dayLength - Time.fixedTime;
        }

        if (timer <= 0)
        {
            dayOver = true;
        }

        if (dayOver)
        {
            
        }
    }
}
