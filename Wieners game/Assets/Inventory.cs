using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private bool carrot;
    [SerializeField] private bool meat;
    [SerializeField] private bool water;
    [SerializeField] private bool brewing;
    [SerializeField] private bool potion1;
    [SerializeField] private float money;

    void Update()
        {
            if (brewing)
            {
                Potions();
            }

            
        }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Cauldron"))
       {
            brewing = true;
       }

       if (other.gameObject.CompareTag("Carrot"))
       {
            carrot = true;
       }

       if (other.gameObject.CompareTag("Meat"))
       {
            meat = true;
       }

       if (other.gameObject.CompareTag("Water"))
       {
            water = true;
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

    void Selling()
        {
            if (potion1)
            {
                potion1 = false;
                money += 100;
            }
        }

}

