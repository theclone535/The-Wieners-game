using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private bool carrot;
    [SerializeField] private bool meat;
    [SerializeField] private bool water;
    private bool brewing;
    [SerializeField] private bool potion1;
    [SerializeField] private float money;
    private bool isHolding;

    void Update()
        {
            if (brewing) //triggers when the play interats with the cauldron
            {
                Potions();

                if (isHolding)
                {
                    isHolding = false;
                }
        }

            
        }
    // detects collision with ingredient triggers, bench, cauldron, etc
    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Cauldron"))
       {
            brewing = true;
       }

       if (other.gameObject.CompareTag("Carrot") && !isHolding)
       {
            carrot = true;
            isHolding = true;
       }

       if (other.gameObject.CompareTag("Meat") && !isHolding)
       {
            meat = true;
            isHolding = true;
        }

       if (other.gameObject.CompareTag("Water") && !isHolding)
       {
            water = true;
            isHolding = true;
        }

       if (other.gameObject.CompareTag("Bench"))
       {
            Selling();


       }

      
       
    }

    void OnTriggerExit(Collider other)
    {
       {
            if (other.gameObject.CompareTag("Cauldron"))
            {
                brewing = false;
            }
       }

    }
    //ingredients required for each potion
    void Potions()
    {
        if (carrot && meat && water)
        {
            potion1 = true;
            carrot = false;
            meat = false;
            water = false;
        }
    }
    //selling mechanics for potions
    void Selling()
        {
            if (potion1)
            {
                potion1 = false;
                money += 100;
            }

            
        }

}

