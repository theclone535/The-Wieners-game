using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public bool fruitBowl;
    [SerializeField] public bool magmaShell;
    [SerializeField] public bool crystals;
    private bool brewing;
    [SerializeField] public bool potion1;
    [SerializeField] public float money;
    public bool isHolding;
    [SerializeField] private bool interact = false;

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
            if (Input.GetKey("e"))
            {
                interact = true;
            }else
            {
                interact = false;
            }

            
        }
    // detects collision with ingredient triggers, bench, cauldron, etc
    void OnTriggerStay(Collider other)
    {
       if (other.gameObject.CompareTag("Cauldron") && interact)
       {
            brewing = true;
            //audio


       }

       if (other.gameObject.CompareTag("FruitBowl") && !isHolding && interact)
       {
            fruitBowl = true;
            isHolding = true;
       }

       if (other.gameObject.CompareTag("MagmaShell") && !isHolding && interact)
       {
            magmaShell = true;
            isHolding = true;
        }

       if (other.gameObject.CompareTag("Crystals") && !isHolding && interact)
       {
            crystals = true;
            isHolding = true;
        }

       if (other.gameObject.CompareTag("Bench") && interact)
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
        if (fruitBowl && magmaShell && crystals)
        {
            potion1 = true;
            fruitBowl = false;
            magmaShell = false;
            crystals = false;
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

