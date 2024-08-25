using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] GameObject player;
    [SerializeField] Toggle carrotToggle;
    [SerializeField] Toggle meatToggle;
    [SerializeField] Toggle waterToggle;
    [SerializeField] Toggle handToggle;
    [SerializeField] Toggle potionToggle;
    [SerializeField] TMP_Text money;

    void Start()
    {
       inventory = player.GetComponent<Inventory>();
    }

    void Update()
    {
        if(inventory.carrot)
        {
            carrotToggle.isOn = true;
        }else
        {
            carrotToggle.isOn = false;
        }

        if(inventory.meat)
        {
            meatToggle.isOn = true;
        }else
        {
            meatToggle.isOn = false;
        }

        if(inventory.water)
        {
            waterToggle.isOn = true;
        }else
        {
            waterToggle.isOn = false;
        }

        if(inventory.isHolding)
        {
            handToggle.isOn = true;
        }else
        {
            handToggle.isOn = false;
        }

        if(inventory.potion1)
        {
            potionToggle.isOn = true;
        }else
        {
            potionToggle.isOn = false;
        }

        money.text = "$" + inventory.money;
    }
}
