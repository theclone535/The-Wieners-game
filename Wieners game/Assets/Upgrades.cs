using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Upgrades : MonoBehaviour
{
    


    [SerializeField] private GameObject[] menus;
    [SerializeField] private Button[] button;

    static private bool[] upgradesUnlocked = new bool[5]; // 0 - Additional Cauldron , 1 - Faster Brewing, 2 - Pockets, 3 - cat snacks, 4 - magic fridge
    static public int currentDay;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

        
    }

    public void UpgradeButton()
    {
        menus[0].SetActive(true);
        menus[1].SetActive(false);
    }

    public void Stock()
    {
        menus[0].SetActive(false);
        menus[1].SetActive(true);
    }

    public void NextDay()
    {
        //interact with the timer script
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void AdditionalCauldron()
    {
        if (!upgradesUnlocked[0])//add cost later
        {
            upgradesUnlocked[0] = true;
            button[0].interactable = false;
            //add functionality and cost
        }
    }

    public void FasterBrewing()
    {
        if (!upgradesUnlocked[1])//add cost later
        {
            upgradesUnlocked[1] = true;
            button[1].interactable = false;
            //add functionality and cost
        }
    }

    public void Pockets()
    {
        if (!upgradesUnlocked[2])//add cost later
        {
            upgradesUnlocked[2] = true;
            button[2].interactable = false;
            //add functionality and cost
        }
    }

    public void CatSnacks()
    {
        if (!upgradesUnlocked[3])//add cost later
        {
            upgradesUnlocked[3] = true;
            button[3].interactable = false;
            //add functionality and cost
        }
    }

    public void MagicFridge()
    {
        if (!upgradesUnlocked[4])//add cost later
        {
            upgradesUnlocked[4] = true;
            button[4].interactable = false;
            //add functionality and cost
        }
    }
}
