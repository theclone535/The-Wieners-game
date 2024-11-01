using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderLogic : MonoBehaviour
{
    bool newOrder;

    [SerializeField] GameObject orderPrefab;
    [SerializeField] GameObject canvas;

    [SerializeField] Sprite[] regenerationIcons;
    [SerializeField] Sprite[] fireResistanceIcons;
    [SerializeField] Sprite[] iceResistanceIcons;
    [SerializeField] Sprite[] magicResistanceIcons;
    [SerializeField] Sprite[] potionIcons;
    [SerializeField] Sprite checkMark;

    [SerializeField] private GameObject player;
    [SerializeField] private Inventory inventory;

    public int potionRecipe;
    public GameObject clone;

    private Image ingredient1;
    private Image ingredient2;
    private Image ingredient3;
    private Image potion;

    public bool interacted = false; //controlled by customerlogic
    public bool atPoint1; //controlled by customerlogic

    void Start()
    {
        newOrder = true;
        inventory = player.GetComponent<Inventory>();

    }

    void Update()
    {
        if (inventory.noOrder == true)
        {
            newOrder = true;
            Debug.Log("New Order");
            inventory.noOrder = false;
        }

        

        if (newOrder && interacted && !clone)
        {
            newOrder = false;
            clone = Instantiate(orderPrefab, canvas.transform);

            GameObject panel;

           panel = clone.transform.Find("Panel").gameObject;//panel
           //ingredient1 = panel.transform.Find("ingredient 1").GetComponent<Image>();
           //ingredient2 = panel.transform.Find("ingredient 2").GetComponent<Image>();
           //ingredient3 = panel.transform.Find("ingredient 3").GetComponent<Image>();
           potion = panel.transform.Find("Potion").GetComponent<Image>();

            potionRecipe = Random.Range(1, 5);
            //potionRecipe = 1;//remove this in build, just for testing
        }            

        if (potionRecipe == 1)
            {
               //regeneration recipe
                /*if(inventory.c.crystals)
                {
                    ingredient1.sprite = checkMark;
                }else
                {
                    ingredient1.sprite = regenerationIcons[0];//crystals
                }
                if(inventory.c.feyBlood)
                {
                    ingredient2.sprite = checkMark;
                }else
                {
                    ingredient2.sprite = regenerationIcons[1];//feyblood
                }
                if(inventory.c.honey)
                {
                    ingredient3.sprite = checkMark;
                }else
                {
                    ingredient3.sprite = regenerationIcons[2];//honey
                }*/
                if (inventory.regenerationPotion)
                {
                    ingredient1.sprite = checkMark;
                    ingredient2.sprite = checkMark;
                    ingredient3.sprite = checkMark;
                    potion.sprite = checkMark;
                }else
                {
                    potion.sprite = potionIcons[0];
                }
            }
            else if (potionRecipe == 2)
            {
                //fire resistance recipe
               /* if(inventory.c.crystals)
                {
                    ingredient1.sprite = checkMark;
                }else
                {
                    ingredient1.sprite = fireResistanceIcons[0];//crystals
                }
                if(inventory.c.magmaShell)
                {
                    ingredient2.sprite = checkMark;
                }else
                {
                    ingredient2.sprite = fireResistanceIcons[1];//magmashell
                }
                if(inventory.c.lifeSap)
                {
                    ingredient3.sprite = checkMark;
                }else
                {
                    ingredient3.sprite = fireResistanceIcons[2];//lifesap
                }*/
                if (inventory.fireResistancePotion)
                {
                    ingredient1.sprite = checkMark;
                    ingredient2.sprite = checkMark;
                    ingredient3.sprite = checkMark;
                    potion.sprite = checkMark;
                }else
                {
                    potion.sprite = potionIcons[1];
                }
            }
            else if (potionRecipe == 3)
            {
                //ice resistance recipe
                /*if(inventory.c.crystals)
                {
                    ingredient1.sprite = checkMark;
                }else
                {
                    ingredient1.sprite = iceResistanceIcons[0];//crystals
                }
                if(inventory.c.fruitBowl)
                {
                    ingredient2.sprite = checkMark;
                }else
                {
                    ingredient2.sprite = iceResistanceIcons[1];//fruitbowl
                }
                if(inventory.c.lifeSap)
                {
                    ingredient3.sprite = checkMark;
                }else
                {
                    ingredient3.sprite = iceResistanceIcons[2];//lifesap
                }*/
                if (inventory.IceResistancePotion)
                {
                    ingredient1.sprite = checkMark;
                    ingredient2.sprite = checkMark;
                    ingredient3.sprite = checkMark;
                    potion.sprite = checkMark;
                }else
                {
                    potion.sprite = potionIcons[2];
                }
                
            }
            else if (potionRecipe == 4)
            {
                //magic resistance recipe
               /* if(inventory.c.honey)
                {
                    ingredient1.sprite = checkMark;
                }else
                {
                    ingredient1.sprite = magicResistanceIcons[0];//honey
                }
                if(inventory.c.magmaShell)
                {
                    ingredient2.sprite = checkMark;
                }else
                {
                    ingredient2.sprite = magicResistanceIcons[1];//magmashell
                }
                if(inventory.c.lifeSap)
                {
                    ingredient3.sprite = checkMark;
                }else
                {
                    ingredient3.sprite = magicResistanceIcons[2];//lifesap
                }*/
                if (inventory.magicResistancePotion)
                {
                    ingredient1.sprite = checkMark;
                    ingredient2.sprite = checkMark;
                    ingredient3.sprite = checkMark;
                    potion.sprite = checkMark;
                }else
                {
                    potion.sprite = potionIcons[3];
                }
            }
    }
}
