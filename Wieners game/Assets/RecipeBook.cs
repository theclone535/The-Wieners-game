using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    [SerializeField] private GameObject recipeBook;
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("tab") && !paused)
        {
            recipeBook.SetActive(true);
            Time.timeScale = 0;
            paused = true;
            Cursor.lockState = CursorLockMode.None;
        }else if (Input.GetKeyDown("tab") && paused)
        {
            recipeBook.SetActive(false);
            Time.timeScale = 1;
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
        
    public void Back()
    {
        recipeBook.SetActive(false);
        paused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
