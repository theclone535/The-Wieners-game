using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderLogic : MonoBehaviour
{
    bool newOrder;

    [SerializeField] GameObject orderPrefab;
    [SerializeField] GameObject canvas;

    [SerializeField] Sprite recipeIcon;

    void Start()
    {
        newOrder = true;
    }

    void Update()
    {
        
        if (newOrder)
        {
            newOrder = false;
            GameObject clone;
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

            

            int PotionRecipe;
            //potionRecipe = Random.Range(1, 4);
            PotionRecipe = 1;

            if (PotionRecipe == 1)
            {
                //regeneration recipe
                ingredient1.sprite = recipeIcon;
                ingredient2.sprite = recipeIcon;
                ingredient3.sprite = recipeIcon;
            }
            else if (PotionRecipe == 2)
            {
                //fire resistance recipe
            }else if (PotionRecipe == 3)
            {
                //ice resistance recipe
            }else if (PotionRecipe == 4)
            {
                //magic resistance recipe
            }



            
        }
    }
}
