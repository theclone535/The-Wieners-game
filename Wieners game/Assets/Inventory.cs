using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private bool brewing;
    [SerializeField] public bool regenerationPotion;
    [SerializeField] public bool fireResistancePotion;
    [SerializeField] public bool IceResistancePotion;
    [SerializeField] public bool magicResistancePotion;
    
    [SerializeField] public float money;
    public bool isHolding;
    [SerializeField] private bool interact = false;
    [SerializeField] private GameObject orderHandler;
    [SerializeField] private OrderLogic orderLogic;
    [SerializeField] private int potionRecipe;
    public bool noOrder;

    [SerializeField] private AudioSource moneyAudio;
    [SerializeField] private AudioSource cauldronAudio;

    public struct IngredientList
    {
    public bool fruitBowl;
    public bool magmaShell;
    public bool crystals;
    public bool feyBlood;
    public bool honey;
    public bool lifeSap; 
    }
    public IngredientList c; // for cauldron
    public IngredientList p; // for player
    bool interacted;
    void Start()
    {
        orderLogic = orderHandler.GetComponent<OrderLogic>();
        
    }


    void Update()
        {
            // this hold the logic for which order is happening and detecting and converting ingredients
            #region potionType
            potionRecipe = orderLogic.potionRecipe;
            if (brewing) //triggers when the play interats with the cauldron
            {
                brewing = false;
                if (potionRecipe == 1)
                {
                    if (p.honey || p.feyBlood || p.crystals)
                    {
                        if (p.honey)
                        {
                            p.honey = false;
                            c.honey = true;
                        }else if (p.feyBlood)
                        {
                            p.feyBlood = false;
                            c.feyBlood = true;
                        }else if (p.crystals)
                        {
                            p.crystals = false;
                            c.crystals = true;
                        }
                        Potions();
                        cauldronAudio.Play();
                    }else
                    {
                        p.fruitBowl = false;
                        p.magmaShell = false;
                        p.lifeSap = false;
                        Debug.Log("Wrong ingredient");
                        // incorrect ingredient audio goes here
                    }
                }else if (potionRecipe == 2)
                {
                    if (p.crystals || p.magmaShell || p.lifeSap)
                    {
                        if (p.crystals)
                        {
                            p.crystals = false;
                            c.crystals = true;
                        }else if (p.magmaShell)
                        {
                            p.magmaShell = false;
                            c.magmaShell = true;
                        }else if (p.lifeSap)
                        {
                            p.lifeSap = false;
                            c.lifeSap = true;
                        }
                         Potions();
                         cauldronAudio.Play();
                    }else
                    {
                        p.fruitBowl = false;
                        p.feyBlood = false;
                        p.honey = false;
                        Debug.Log("Wrong ingredient");
                    }
                }else if (potionRecipe == 3)
                {
                    if (p.crystals || p.fruitBowl || p.lifeSap)
                    {
                        if (p.crystals)
                        {
                            p.crystals = false;
                            c.crystals = true;
                        }else if (p.fruitBowl)
                        {
                            p.fruitBowl = false;
                            c.fruitBowl = true;
                        }else if (p.lifeSap)
                        {
                            p.lifeSap = false;
                            c.lifeSap = true;
                        }
                        Potions();
                        cauldronAudio.Play();
                    }else
                    {
                        p.feyBlood = false;
                        p.magmaShell = false;
                        p.honey = false;
                        Debug.Log("Wrong ingredient");
                    }
                }else if (potionRecipe == 4)
                {
                    if (p.magmaShell || p.fruitBowl || p.lifeSap)
                    {
                        if (p.magmaShell)
                        {
                            p.magmaShell = false;
                            c.magmaShell = true;
                        }else if (p.fruitBowl)
                        {
                            p.fruitBowl = false;
                            c.fruitBowl = true;
                        }else if (p.lifeSap)
                        {
                            p.lifeSap = false;
                            c.lifeSap = true;
                        }
                        Potions();
                        cauldronAudio.Play();
                    }else
                    {
                        p.crystals = false;
                        p.feyBlood = false;
                        p.honey = false;
                        Debug.Log("Wrong ingredient");
                    }
                }else
                {
                    Debug.Log("How did you get here?");
                }
                #endregion

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
                interacted = false;
            } 
        
        }
    // detects collision with ingredient triggers, bench, cauldron, etc
    void OnTriggerStay(Collider other)
    {
        
       if (other.gameObject.CompareTag("Cauldron") && interact && !interacted)
       {
            brewing = true;
            interacted = true;
            
       }

       if (other.gameObject.CompareTag("FruitBowl") && !isHolding && interact)
       {
            p.fruitBowl = true;
            isHolding = true;
       }

       if (other.gameObject.CompareTag("MagmaShell") && !isHolding && interact)
       {
            p.magmaShell = true;
            isHolding = true;
        }

       if (other.gameObject.CompareTag("Crystals") && !isHolding && interact)
       {
            p.crystals = true;
            isHolding = true;
        }

       if (other.gameObject.CompareTag("Bench") && interact)
       {
            Selling();
       }

        if (other.gameObject.CompareTag("FeyBlood") && !isHolding && interact)
        {
            p.feyBlood = true;
            isHolding = true;
        }

        if (other.gameObject.CompareTag("Honey") && !isHolding && interact)
        {
            p.honey = true;
            isHolding = true;
        }

        if (other.gameObject.CompareTag("LifeSap") && !isHolding && interact)
        {
            p.lifeSap = true;
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
        
        if (c.honey && c.feyBlood && c.crystals)
        {
            regenerationPotion = true;
            c.feyBlood = false;
            c.honey = false;
            c.crystals = false;
        }

        if (c.crystals && c.magmaShell && c.lifeSap)
        {
            fireResistancePotion = true;
            c.crystals = false;
            c.magmaShell = false;
           c.lifeSap = false;
        }

        if (c.crystals && c.fruitBowl && c.lifeSap)
        {
            IceResistancePotion = true;
            c.crystals = false;
            c.fruitBowl = false;
            c.lifeSap = false;
        }

        if (c.magmaShell && c.lifeSap && c.fruitBowl)
        {
            magicResistancePotion = true;
            c.magmaShell = false;
            c.lifeSap = false;
            c.fruitBowl = false;
        }

    }
    //selling mechanics for potions
    void Selling()
    {
            if (regenerationPotion)
            {
                regenerationPotion = false;
                money += 3.5f;

                Destroy(orderLogic.clone);
                noOrder = true;

                moneyAudio.Play();
            }

            if (fireResistancePotion)
            {
                fireResistancePotion = false;
                money += 12.8f;

                Destroy(orderLogic.clone);
                noOrder = true;

                moneyAudio.Play();
            }

            if (IceResistancePotion)
            {
                IceResistancePotion = false;
                money += 12f;

                Destroy(orderLogic.clone);
                noOrder = true;

                moneyAudio.Play();
            }

            if (magicResistancePotion)
            {
                magicResistancePotion = false;
                money += 30f;

                Destroy(orderLogic.clone);
                noOrder = true;

                moneyAudio.Play();
            }
            
    }

}

