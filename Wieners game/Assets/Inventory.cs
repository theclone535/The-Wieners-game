using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private bool brewing;
    [SerializeField] public bool regenerationPotion;
    [SerializeField] public bool fireResistancePotion;
    [SerializeField] public bool IceResistancePotion;
    [SerializeField] public bool magicResistancePotion;
    
    [SerializeField] public float money;
    public bool isHolding;
    public bool interact = false;
    [SerializeField] private GameObject orderHandler;
    [SerializeField] private OrderLogic orderLogic;
    [SerializeField] private GameObject customerHolder;
    [SerializeField] private CustomerLogic customerLogic;
    [SerializeField] private int potionRecipe;
    [SerializeField] private GameObject[] ingredientPrefab;
    [SerializeField] private GameObject holdingPos;
    [SerializeField] private GameObject potionPrefab;
    [SerializeField] private TextMeshProUGUI moneyText;
    public bool noOrder = false;
    public bool newCustomer;

    [SerializeField] private AudioSource moneyAudio;
    [SerializeField] private AudioSource cauldronAudio;

    public struct IngredientList
    {
    public bool fruitBowl;
    public bool magmaShell;
    public bool crystals;
    public bool feyBlood;
    public bool honey;
    public bool lifeSap; // ice heart
    }
    public IngredientList c; // for cauldron
    public IngredientList p; // for player
    bool interacted;
    bool done = false;
    GameObject clone;
    public GameObject potionClone;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        orderLogic = orderHandler.GetComponent<OrderLogic>();
        customerLogic = customerHolder.GetComponent<CustomerLogic>();
        
    }


    void Update()
        {
            // this hold the logic for which order is happening and detecting and converting ingredients
            #region potionType
            potionRecipe = orderLogic.potionRecipe;
            if (brewing) //triggers when the play interacts with the cauldron
            {
                brewing = false;
                done = false;
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
                    if (p.crystals || p.fruitBowl || p.feyBlood)
                    {
                        if (p.crystals)
                        {
                            p.crystals = false;
                            c.crystals = true;
                        }else if (p.fruitBowl)
                        {
                            p.fruitBowl = false;
                            c.fruitBowl = true;
                        }else if (p.feyBlood)
                        {
                            p.feyBlood = false;
                            c.feyBlood = true;
                        }
                        Potions();
                        cauldronAudio.Play();
                    }else
                    {
                        p.lifeSap = false;
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
                p.crystals = false;
                p.feyBlood = false;
                p.honey = false;
                p.magmaShell = false;
                p.lifeSap = false;
                p.fruitBowl = false;
                Debug.Log("Wrong Ingredient");
                }
                #endregion

                if (isHolding)
                {
                    isHolding = false;
                }
                
            }

            //updates money text
            moneyText.text = "$" + money;

            if(!done && clone)
            {
                Destroy(clone);
            }

            if (Input.GetKey("e"))
            {
                interact = true;
            }else
            {
                interact = false;
                interacted = false;
            } 
            //instantiates ingredients that the witch is holding
            #region InstantiateIngredients
            if(p.crystals && !done)
            {
                clone = Instantiate(ingredientPrefab[0], transform.position + new Vector3(-0.2f, 0.6f, 0), Quaternion.identity, transform);
                clone.transform.rotation = transform.rotation; clone.transform.localPosition = new Vector3(-0.2f, 0.6f, 0);
                done = true;
            }

            if(p.magmaShell && !done)
            {
                clone = Instantiate(ingredientPrefab[1], transform.position + new Vector3(0.2f, 0.6f, 0), Quaternion.Euler(0, 0, 0), transform);
                clone.transform.rotation = transform.rotation; clone.transform.localPosition = new Vector3(-0.2f, 0.6f, 0);
            done = true;
            }

            if(p.feyBlood && !done)
            {
                clone = Instantiate(ingredientPrefab[2], transform.position + new Vector3(0.2f, 0.6f, 0), Quaternion.Euler(0, 0, 0),transform); //(0.175f, -0.3f, -3)
            
            done = true;
            }

            if(p.fruitBowl && !done)
            {
                clone = Instantiate(ingredientPrefab[3], transform.position + new Vector3(0.2f, 0.6f, 0), Quaternion.identity,transform);
                clone.transform.rotation = transform.rotation; clone.transform.localPosition = new Vector3(-0.45f, 0.6f, 0);
            done = true;
            }

            if(p.honey && !done)
            {
                clone = Instantiate(ingredientPrefab[4], transform.position + new Vector3(0.3f, 0.6f, 0), Quaternion.identity,transform); 
                done = true;
            }

            if(p.lifeSap && !done)
            {
                clone = Instantiate(ingredientPrefab[5], transform.position + new Vector3(0.2f, 0.6f, 0), Quaternion.identity,transform);
                clone.transform.rotation = transform.rotation;clone.transform.Rotate(new Vector3(0, 0, -90), Space.Self) ; clone.transform.localPosition = new Vector3(-0.2f, 0.6f, 0);
            done = true;
            }
            #endregion
        
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

        if (other.gameObject.CompareTag("Bench") && interact && !interacted && customerLogic.reached)
        {
            customerLogic.bench = true;
            interacted = true;
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

            if (other.gameObject.CompareTag("Bench"))
            {
                customerLogic.bench = false;
                
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
            PotionInstan();
        }

        if (c.crystals && c.magmaShell && c.lifeSap)
        {
            fireResistancePotion = true;
            c.crystals = false;
            c.magmaShell = false;
           c.lifeSap = false;
           PotionInstan();
        }

        if (c.crystals && c.fruitBowl && c.feyBlood)
        {
            IceResistancePotion = true;
            c.crystals = false;
            c.fruitBowl = false;
            c.feyBlood = false;
            PotionInstan();
        }

        if (c.magmaShell && c.lifeSap && c.fruitBowl)
        {
            magicResistancePotion = true;
            c.magmaShell = false;
            c.lifeSap = false;
            c.fruitBowl = false;
            PotionInstan();
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
                Destroy(potionClone);
                noOrder = true;
                newCustomer = true;
                orderLogic.potionRecipe = 0;
                customerLogic.endSpeech = true;

                moneyAudio.Play();
            }

            if (fireResistancePotion)
            {
                fireResistancePotion = false;
                money += 12.8f;

                Destroy(orderLogic.clone);
                Destroy(potionClone);
                noOrder = true;
                newCustomer = true;
                orderLogic.potionRecipe = 0;
                customerLogic.endSpeech = true;

            moneyAudio.Play();
            }

            if (IceResistancePotion)
            {
                IceResistancePotion = false;
                money += 12f;

                Destroy(orderLogic.clone);
                Destroy(potionClone);
                noOrder = true;
                newCustomer = true;
                orderLogic.potionRecipe = 0;
                customerLogic.endSpeech = true;

            moneyAudio.Play();
            }

            if (magicResistancePotion)
            {
                magicResistancePotion = false;
                money += 30f;

                Destroy(orderLogic.clone);
                Destroy(potionClone);
                noOrder = true;
                newCustomer = true;
                orderLogic.potionRecipe = 0;
                customerLogic.endSpeech = true;

                moneyAudio.Play();
            }
            
    }

    void PotionInstan()
    {
                potionClone = Instantiate(potionPrefab, transform.position + new Vector3(-0.2f, 0f, 0), Quaternion.identity, transform);
                potionClone.transform.rotation = transform.rotation; potionClone.transform.localPosition = new Vector3(-0.2f, 0.35f, 0);
    }

}

