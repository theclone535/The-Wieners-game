using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] GameObject player;
    [SerializeField] Toggle crystalsToggle;
    [SerializeField] Toggle magmaShellToggle;
    [SerializeField] Toggle fruitBowlToggle;
    [SerializeField] Toggle honeyToggle;
    [SerializeField] Toggle lifeSapToggle;
    [SerializeField] Toggle feyBloodToggle;

    [SerializeField] Toggle regenerationToggle;
    [SerializeField] Toggle fireResistanceToggle;
    [SerializeField] Toggle iceResistanceToggle;
    [SerializeField] Toggle magicResistanceToggle;
    [SerializeField] TMP_Text money;

    void Start()
    {
       inventory = player.GetComponent<Inventory>();
    }

    void Update()
    {
        if(inventory.p.fruitBowl || inventory.c.fruitBowl)
        {
            fruitBowlToggle.isOn = true;
        }else
        {
            fruitBowlToggle.isOn = false;
        }

        if(inventory.p.magmaShell || inventory.c.magmaShell)
        {
            magmaShellToggle.isOn = true;
        }else
        {
            magmaShellToggle.isOn = false;
        }

        if(inventory.p.crystals || inventory.c.crystals)
        {
            crystalsToggle.isOn = true;
        }else
        {
            crystalsToggle.isOn = false;
        }

        if (inventory.p.honey || inventory.c.honey)
        {
            honeyToggle.isOn = true;
        }
        else
        {
            honeyToggle.isOn = false;
        }

        if (inventory.p.lifeSap || inventory.c.lifeSap)
        {
            lifeSapToggle.isOn = true;
        }
        else
        {
            lifeSapToggle.isOn = false;
        }

        if (inventory.p.feyBlood || inventory.c.feyBlood)
        {
            feyBloodToggle.isOn = true;
        }
        else
        {
            feyBloodToggle.isOn = false;
        }

        //potions 
        if (inventory.regenerationPotion)
        {
            regenerationToggle.isOn = true;
        }else
        {
            regenerationToggle.isOn = false;
        }

        if (inventory.fireResistancePotion)
        {
            fireResistanceToggle.isOn = true;
        }
        else
        {
            fireResistanceToggle.isOn = false;
        }

        if (inventory.IceResistancePotion)
        {
            iceResistanceToggle.isOn = true;
        }
        else
        {
            iceResistanceToggle.isOn = false;
        }

        if (inventory.magicResistancePotion)
        {
            magicResistanceToggle.isOn = true;
        }
        else
        {
            magicResistanceToggle.isOn = false;
        }

        money.text = "$" + inventory.money;
    }
}
