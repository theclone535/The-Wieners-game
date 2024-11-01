using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
  public GameObject mainMenu;
  public GameObject options;
  public int page = 0;
  [SerializeField] private Sprite[] tutorial;
  [SerializeField] private GameObject howToPlayOBJ;
  [SerializeField] private Image here;
  [SerializeField] private GameObject textHolder;
  [SerializeField] private TextMeshProUGUI pageCount;

  void Start()
  {
   here = howToPlayOBJ.GetComponent<Image>();
  }

  void Update()
  {
    if (page == 0)
    {
      howToPlayOBJ.SetActive(false);
      textHolder.SetActive(true);
    }else if (page == 1)
    {
      howToPlayOBJ.SetActive(true);
      textHolder.SetActive(false);
      here.sprite = tutorial[0];
    }else if (page == 2)
    {
      howToPlayOBJ.SetActive(true);
      textHolder.SetActive(false);
      here.sprite = tutorial[1];
    }else if (page == 3)
    {
      howToPlayOBJ.SetActive(true);
      textHolder.SetActive(false);
      here.sprite = tutorial[2];
    }else if (page == 4)
    {
      howToPlayOBJ.SetActive(true);
      textHolder.SetActive(false);
      here.sprite = tutorial[3];
    }else if (page == 5)
    {
      howToPlayOBJ.SetActive(true);
      textHolder.SetActive(false);
      here.sprite = tutorial[4];
    }

    pageCount.text = "Page(" + page + "/5)";
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

  public void Next ()
  {
    page++;
    if (page >= 6)
    {
      page = 0;
    }
  }
}
