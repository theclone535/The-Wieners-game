using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public bool fruitBowl;
    [SerializeField] public bool magmaShell;
    [SerializeField] public bool crystals;
    [SerializeField] public bool feyBlood;
    [SerializeField] public bool honey;
    [SerializeField] public bool lifeSap;

    private bool brewing;
    [SerializeField] public bool regenerationPotion;
    [SerializeField] public bool fireResistancePotion;
    [SerializeField] public bool IceResistancePotion;
    [SerializeField] public bool magicResistancePotion;
    
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

        if (other.gameObject.CompareTag("FeyBlood") && !isHolding && interact)
        {
            feyBlood = true;
            isHolding = true;
        }

        if (other.gameObject.CompareTag("Honey") && !isHolding && interact)
        {
            honey = true;
            isHolding = true;
        }

        if (other.gameObject.CompareTag("LifeSap") && !isHolding && interact)
        {
            lifeSap = true;
            isHolding = true;
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
        if (honey && feyBlood && crystals)
        {
            regenerationPotion = true;
            feyBlood = false;
            honey = false;
            crystals = false;
        }

        if (crystals && magmaShell && lifeSap)
        {
            fireResistancePotion = true;
            crystals = false;
            magmaShell = false;
            lifeSap = false;
        }

        if (crystals && fruitBowl && lifeSap)
        {
            IceResistancePotion = true;
            crystals = false;
            fruitBowl = false;
            lifeSap = false;
        }

        if (magmaShell && lifeSap && fruitBowl)
        {
            magicResistancePotion = true;
            magmaShell = false;
            lifeSap = false;
            fruitBowl = false;
        }

    }
    //selling mechanics for potions
    void Selling()
    {
            if (regenerationPotion)
            {
                regenerationPotion = false;
                money += 3.5f;
            }

            if (fireResistancePotion)
            {
                fireResistancePotion = false;
                money += 12.8f;
            }

            if (IceResistancePotion)
            {
                IceResistancePotion = false;
                money += 12f;
            }

            if (magicResistancePotion)
            {
                magicResistancePotion = false;
                money += 30f;
            }
            
    }

}

