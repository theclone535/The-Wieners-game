using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeryImportantScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject imageOBJ;
    Image image;

    void Start()
    {
        imageOBJ.GetComponent<Image>();
    }

    void OnTriggerEnter()
    {
        //play audio and breifly display image and teleport back
        player.SetActive(false);
        player.transform.position = new Vector3(20, 4, 3);
        player.SetActive(true);

        audioSource.Play();

        imageOBJ.SetActive(true);
        StartCoroutine(ImageFlash());

        

    }

    IEnumerator ImageFlash()
    {
        yield return new WaitForSeconds(2f);
        imageOBJ.SetActive(false);
    }

}
