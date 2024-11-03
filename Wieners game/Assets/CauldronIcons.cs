using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronIcons : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject cauldron;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject imagePrefab;
    [SerializeField] private Transform worldCanvas;
    [SerializeField] private Image[] ingredient; // need just 3
    [SerializeField] private Sprite[] image; // need one for every ingredient
    bool panelised = false;
    public int numOfImg = 0;
    bool[] done = {false, false, false, false, false, false}; 
    
    //public float change;
    void Start()
    {
        inventory = player.GetComponent<Inventory>();
    }


    void Update()
    {
    

        if (inventory.c.fruitBowl || inventory.c.magmaShell || inventory.c.crystals || inventory.c.feyBlood || inventory.c.honey || inventory.c.lifeSap)
        {
            
            if (!panelised)
            {
                Instantiate(panel, cauldron.transform.position + new Vector3(-0.5f, 0.3f, 0), Quaternion.identity, worldCanvas); 
                panelised = true;
            }

            if (panelised)
        {
            GameObject clone = GameObject.Find("InCauldron(Clone)");
            clone.transform.LookAt(mainCamera.transform);
            clone.GetComponent<RectTransform>().eulerAngles = clone.transform.rotation.eulerAngles + new Vector3(100, 180, 0);
            
        }

            if (inventory.c.fruitBowl) //fruitbowl = image[0]
            {   
                if (numOfImg < 1)
                {
                    ingredient[0] = panel.transform.Find("Ingredient").GetComponent<Image>();
                    ingredient[0].sprite = image[0];

                    numOfImg++;
                    done[0] = true;
                }else if (numOfImg == 1 && !done[0])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(2,1);
                    ingredient[1] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[1].transform.localPosition = new Vector3(0.5f, 0, 0);
                    ingredient[1].sprite = image[0];

                    numOfImg++;
                    done[0] = true;
                }else if (numOfImg == 2 && !done[0])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(3,1);
                    ingredient[2] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[2].transform.localPosition = new Vector3(1, 0, 0);
                    ingredient[2].sprite = image[0];
                    done[0] = true;
                }
            }

            if (inventory.c.magmaShell) //magmashell = image[1]
            {   
                if (numOfImg < 1)
                {
                    ingredient[0] = panel.transform.Find("Ingredient").GetComponent<Image>();
                    ingredient[0].sprite = image[1];

                    numOfImg++;
                    done[1] = true;
                }else if (numOfImg == 1 && !done[1])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(2,1);
                    ingredient[1] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[1].transform.localPosition = new Vector3(0.5f, 0, 0);
                    ingredient[1].sprite = image[1];

                    numOfImg++;
                    done[1] = true;
                }else if (numOfImg == 2 && !done[1])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(3,1);
                    ingredient[2] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[2].transform.localPosition = new Vector3(1, 0, 0);
                    ingredient[2].sprite = image[1];
                    done[1] = true;
                }
            }

            if (inventory.c.crystals) //crystals = image[2]
            {   
                if (numOfImg < 1 && !done[2])
                {
                    ingredient[0] = panel.transform.Find("Ingredient").GetComponent<Image>();
                    ingredient[0].sprite = image[2];

                    numOfImg++;
                    done[2] = true;
                }else if (numOfImg == 1 && !done[2])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(2,1);
                    ingredient[1] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[1].transform.localPosition = new Vector3(0.5f, 0, 0);
                    ingredient[1].sprite = image[2];

                    numOfImg++;
                    done[2] = true;
                }else if (numOfImg == 2 && !done[2])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(3,1);
                    ingredient[2] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[2].transform.localPosition = new Vector3(1, 0, 0);
                    ingredient[2].sprite = image[2];
                    done[2] = true;
                }
            }

            if (inventory.c.feyBlood) //feyblood = image[3]
            {   
                if (numOfImg < 1)
                {
                    ingredient[0] = panel.transform.Find("Ingredient").GetComponent<Image>();
                    ingredient[0].sprite = image[3];

                    numOfImg++;
                    done[3] = true;
                }else if (numOfImg == 1 && !done[3])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(2,1);
                    ingredient[1] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[1].transform.localPosition = new Vector3(0.5f, 0, 0);
                    ingredient[1].sprite = image[3];

                    numOfImg++;
                    done[3] = true;
                }else if (numOfImg == 2 && !done[3])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(3,1);
                    ingredient[2] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[2].transform.localPosition = new Vector3(1, 0, 0);
                    ingredient[2].sprite = image[3];
                    done[3] = true;
                }
            }

            if (inventory.c.honey) //honey = image[4]
            {   
                if (numOfImg < 1)
                {
                    ingredient[0] = panel.transform.Find("Ingredient").GetComponent<Image>();
                    ingredient[0].sprite = image[4];

                    numOfImg++;
                    done[4] = true;
                }else if (numOfImg == 1 && !done[4])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(2,1);
                    ingredient[1] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[1].transform.localPosition = new Vector3(0.5f, 0, 0);
                    ingredient[1].sprite = image[4];

                    numOfImg++;
                    done[4] = true;
                }else if (numOfImg == 2 && !done[4])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(3,1);
                    ingredient[2] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[2].transform.localPosition = new Vector3(1, 0, 0);
                    ingredient[2].sprite = image[4];
                    done[4] = true;
                }
            }

            if (inventory.c.lifeSap) //lifesap = image[5]
            {   
                if (numOfImg < 1)
                {
                    ingredient[0] = panel.transform.Find("Ingredient").GetComponent<Image>();
                    ingredient[0].sprite = image[5];

                    numOfImg++;
                    done[5] = true;
                }else if (numOfImg == 1 && !done[5])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(2,1);
                    ingredient[1] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[1].transform.localPosition = new Vector3(0.5f, 0, 0);
                    ingredient[1].sprite = image[5];

                    numOfImg++;
                    done[5] = true;
                }else if (numOfImg == 2 && !done[5])
                {
                    GameObject clone = GameObject.Find("InCauldron(Clone)");
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(3,1);
                    ingredient[2] = Instantiate(imagePrefab,clone.transform.position, clone.transform.rotation, clone.transform).GetComponent<Image>();
                    ingredient[2].transform.localPosition = new Vector3(1, 0, 0);
                    ingredient[2].sprite = image[5];
                    done[5] = true;
                }
            }
        }else if (panelised)
        {
            Destroy(GameObject.Find("InCauldron(Clone)"));
            panelised = false;
            for (int i = 0; i < 6; i++)
            {
                done[i] = false;
            }
            numOfImg = 0;
        }

        
    }
}
