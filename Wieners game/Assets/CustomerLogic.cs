using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerLogic : MonoBehaviour
{
    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;
    [SerializeField] private GameObject[] customers;
    [SerializeField] private GameObject player;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject orderHandler;
    [SerializeField] private OrderLogic orderlogic;
    [SerializeField] private float speed;
    GameObject clone;
    bool spawn;
    public bool bench;
    public bool reached;
    
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject imageOfSpeechOBJ;
    [SerializeField] private Image imageOfSpeech;
    [SerializeField] private Image speechBubbleImage;
    [SerializeField] private Sprite[] potionIcons;
    [SerializeField] private Sprite[] timerState;//6
    [SerializeField] private Sprite plain;
    bool once;
    public bool endSpeech;
    private int increment = 0;
    //private bool customerLeave;

    void Start()
    {
        inventory = player.GetComponent<Inventory>();
        orderlogic = orderHandler.GetComponent<OrderLogic>();
        imageOfSpeech = imageOfSpeechOBJ.GetComponent<Image>();
        speechBubbleImage = speechBubble.GetComponent<Image>();
        spawn = true;
    }
    void Update()
    {
        if (inventory.newCustomer)
        {
            inventory.newCustomer = false;
            spawn = true;
        }

        if (spawn && clone)
        {
            Destroy(clone);
        }

        if (spawn)//inventory.newOrder
        {
            spawn = false;

            clone = Instantiate(customers[Random.Range(0, 3)], point1.transform.position, Quaternion.identity);//Random.Range(0, 6)
        }

        if (clone)
        {
            clone.transform.position = Vector3.MoveTowards(clone.transform.position, point2.transform.position, speed * Time.deltaTime); 
        }

        
        if (clone.transform.position == point2.transform.position)
        {
            reached = true;
        }
        else
        {
            reached = false;
        }


        if (bench && reached && Input.GetKey("e"))
        {
            orderlogic.interacted = true;
        }else
        {
            orderlogic.interacted = false;
        }

       if (orderlogic.potionRecipe == 1 && !once)
       {
            if (reached)
            {
                once = true;
                speechBubbleImage.sprite = plain;
                speechBubble.SetActive(true);
                imageOfSpeechOBJ.SetActive(true);
                imageOfSpeech.sprite = potionIcons[0];//regen
                //wait for a sec or half adn switch to timer
                InvokeRepeating("TimerProgression", 1.0f, 3.5f);
            }
        } else if (orderlogic.potionRecipe == 2 && !once)
        {
            if (reached)
            {
                once = true;
                speechBubbleImage.sprite = plain;
                speechBubble.SetActive(true);
                imageOfSpeechOBJ.SetActive(true);
                imageOfSpeech.sprite = potionIcons[1];//fire resistance
                //wait for a sec or half adn switch to timer
                InvokeRepeating("TimerProgression", 1.0f, 3.5f);;
            }
            
        }else if (orderlogic.potionRecipe == 3 && !once)
        {
            if (reached)
            {
                once = true;
                speechBubbleImage.sprite = plain;
                speechBubble.SetActive(true);
                imageOfSpeechOBJ.SetActive(true);
                imageOfSpeech.sprite = potionIcons[2];//ice resistance
                //wait for a sec or half adn switch to timer
                InvokeRepeating("TimerProgression", 1.0f, 3.5f);
            }
            
        }else if (orderlogic.potionRecipe == 4 && !once)
        {
            if (reached)
            {
                once = true;
                speechBubbleImage.sprite = plain;
                speechBubble.SetActive(true);
                imageOfSpeechOBJ.SetActive(true);
                imageOfSpeech.sprite = potionIcons[3];//magic resistance
                //wait for a sec or half adn switch to timer
                InvokeRepeating("TimerProgression", 1.0f, 3.5f);
            }
            
        }


       if (endSpeech)
       {
        CancelInvoke();
        increment = 0;
        endSpeech = false;
        once = false;
        speechBubble.SetActive(false);


       }
        
    }

    void TimerProgression()
    {
        imageOfSpeechOBJ.SetActive(false);
        if (increment > 0)
        {
            increment++;
        }
        if (increment == 6)
        {
            FailOrder();
        }
        speechBubbleImage.sprite = timerState[increment];  
        if (increment == 0)
        {
            increment++;
        }
    }

    void FailOrder()
    {
        //reset speech
        endSpeech = true;
        //clear cauldron contents
        inventory.c.crystals = false;
        inventory.c.magmaShell = false;
        inventory.c.honey = false;
        inventory.c.feyBlood = false;
        inventory.c.lifeSap = false;
        inventory.c.fruitBowl = false;
        //clear potions
        inventory.regenerationPotion = false;
        inventory.fireResistancePotion = false;
        inventory.IceResistancePotion = false;
        inventory.magicResistancePotion = false;
        if (inventory.potionClone)
        {
            Destroy(inventory.potionClone);
        }
        //make customer leave and make new one appaear
        Destroy(orderlogic.clone); //replace with leaving code when you have it
        inventory.noOrder = true;
        inventory.newCustomer = true;
        orderlogic.potionRecipe = 0;
        //prehaps display a big X on the cauldron or sumting
     //Debug.Log("fail");
        
    }

    /*void CustomerLeaving()
    {
        customerLeave = true;
        while (clone.transform.position != point1.transform.position)
        {
           clone.transform.position = Vector3.MoveTowards(clone.transform.position, point1.transform.position, speed * Time.deltaTime);
        }
        if (clone.transform.position == point1.transform.position)
        {
            //customerLeave = false;
            //inventory.newCustomer = true;
        }
        
    }*/

    
}
