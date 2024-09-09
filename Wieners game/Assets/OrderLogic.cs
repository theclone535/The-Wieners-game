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

    [SerializeField] private GameObject player;
    [SerializeField] private Inventory inventory;

    public int potionRecipe;
    public GameObject clone;

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

        if (newOrder)
        {
            newOrder = false;
            clone = Instantiate(orderPrefab, canvas.transform);

            GameObject panel;
            Image ingredient1;
            Image ingredient2;
            Image ingredient3;
            Image potion;

           panel = clone.transform.Find("Panel").gameObject;
           ingredient1 = panel.transform.Find("ingredient 1").GetComponent<Image>();
           ingredient2 = panel.transform.Find("ingredient 2").GetComponent<Image>();
           ingredient3 = panel.transform.Find("ingredient 3").GetComponent<Image>();
           potion = panel.transform.Find("Potion").GetComponent<Image>();

            //potionRecipe = Random.Range(1, 4);
            potionRecipe = 1;
            
            if (potionRecipe == 1)
            {
               //regeneration recipe
               ingredient1.sprite = regenerationIcons[0];
               ingredient2.sprite = regenerationIcons[1];
               ingredient3.sprite = regenerationIcons[2];
                potion.sprite = potionIcons[0];
            }
            else if (potionRecipe == 2)
            {
                //fire resistance recipe
                ingredient1.sprite = fireResistanceIcons[0];
                ingredient2.sprite = fireResistanceIcons[1];
                ingredient3.sprite = fireResistanceIcons[2];
                potion.sprite = potionIcons[1];
            }
            else if (potionRecipe == 3)
            {
                //ice resistance recipe
                ingredient1.sprite = iceResistanceIcons[0];
                ingredient2.sprite = iceResistanceIcons[1];
                ingredient3.sprite = iceResistanceIcons[2];
                potion.sprite = potionIcons[2];
            }
            else if (potionRecipe == 4)
            {
                //magic resistance recipe
                ingredient1.sprite = magicResistanceIcons[0];
                ingredient2.sprite = magicResistanceIcons[1];
                ingredient3.sprite = magicResistanceIcons[2];
                potion.sprite = potionIcons[3];
            }


        

        }
    }
}
