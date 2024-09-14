using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    bool paused;
    void Update()
    {
        if(Input.GetKeyDown("escape") && !paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            paused = true;
            Cursor.lockState = CursorLockMode.None;
        }else if (Input.GetKeyDown("escape") && paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Back()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }



}
