using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public bool carrot;
    [SerializeField] public bool meat;
    [SerializeField] public bool water;
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
       }

       if (other.gameObject.CompareTag("Carrot") && !isHolding && interact)
       {
            carrot = true;
            isHolding = true;
       }

       if (other.gameObject.CompareTag("Meat") && !isHolding && interact)
       {
            meat = true;
            isHolding = true;
        }

       if (other.gameObject.CompareTag("Water") && !isHolding && interact)
       {
            water = true;
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

