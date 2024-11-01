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

    [SerializeField] GameObject player;
    Inventory inventory;
    [SerializeField] GameObject endOfDayScreen;
    [SerializeField] TextMeshProUGUI moneyGained;
    [SerializeField] TextMeshProUGUI rentPaid;
    [SerializeField] TextMeshProUGUI total;
    public float totalmoney;

    void Start()
    {
        timer = dayLength;
        starting = true;
        //Time.timeScale = 30;
        inventory = player.GetComponent<Inventory>();
    }

    void Update()
    {
        totalmoney = (inventory.money - 40);
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
            endOfDayScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            moneyGained.text = "Money Gained: $" + inventory.money;
            rentPaid.text = "Rent Paid: -$40";
            total.text = "Total: $" + totalmoney;
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
