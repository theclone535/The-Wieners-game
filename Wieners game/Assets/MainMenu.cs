using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public GameObject mainMenu;
  public GameObject options;
  void Update()
  {

  }
  public void PlayGame ()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void Options ()
  {
    mainMenu.SetActive(false);
    options.SetActive(true);
  }

  public void Back ()
  {
    options.SetActive(false);
    mainMenu.SetActive(true);
  }

  public void ExitGame ()
  {
    Debug.Log("QUIT!");
    Application.Quit();
  }
}
