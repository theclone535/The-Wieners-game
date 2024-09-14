using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionIcon : MonoBehaviour
{

    [SerializeField] private GameObject pressE;
    [SerializeField] private GameObject worldCanvas;
    [SerializeField] private GameObject mainCamera;
    bool done = false;
    GameObject clone;
    Quaternion angle;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Crystals") && !done)
        {
            done = true;
            clone = Instantiate(pressE, other.transform.position + new Vector3(0, 1f, 0), Quaternion.identity, worldCanvas.transform);
            clone.transform.LookAt(mainCamera.transform);
            clone.GetComponent<RectTransform>().eulerAngles = clone.transform.rotation.eulerAngles + new Vector3(mainCamera.transform.rotation.eulerAngles.x, 180, 0);
        }

        if (other.gameObject.CompareTag("FruitBowl") && !done)
        {
            done = true;
            clone = Instantiate(pressE, other.transform.position + new Vector3(0, 1f, 0), Quaternion.identity, worldCanvas.transform);
            clone.transform.LookAt(mainCamera.transform);
            clone.GetComponent<RectTransform>().eulerAngles = clone.transform.rotation.eulerAngles + new Vector3(mainCamera.transform.rotation.eulerAngles.x, 180, 0);
        }

        if (other.gameObject.CompareTag("MagmaShell") && !done)
        {
            done = true;
            clone = Instantiate(pressE, other.transform.position + new Vector3(0, 1f, 0), Quaternion.identity, worldCanvas.transform);
            clone.transform.LookAt(mainCamera.transform);
            clone.GetComponent<RectTransform>().eulerAngles = clone.transform.rotation.eulerAngles + new Vector3(mainCamera.transform.rotation.eulerAngles.x, 180, 0);
        }

        if (other.gameObject.CompareTag("FeyBlood") && !done)
        {
            done = true;
            clone = Instantiate(pressE, other.transform.position + new Vector3(0, 1f, 0), Quaternion.identity, worldCanvas.transform);
            clone.transform.LookAt(mainCamera.transform);
            clone.GetComponent<RectTransform>().eulerAngles = clone.transform.rotation.eulerAngles + new Vector3(100, 180, 0);
            //clone.GetComponent<RectTransform>().eulerAngles = clone.transform.rotation.eulerAngles + new Vector3(mainCamera.transform.rotation.eulerAngles.x, 180, 0);
        }

        if (other.gameObject.CompareTag("Honey") && !done)
        {
            done = true;
            clone = Instantiate(pressE, other.transform.position + new Vector3(0, 1f, 0), Quaternion.identity, worldCanvas.transform);
            clone.transform.LookAt(mainCamera.transform);
            clone.GetComponent<RectTransform>().eulerAngles = clone.transform.rotation.eulerAngles + new Vector3(100, 180, 0);
            //clone.GetComponent<RectTransform>().eulerAngles = clone.transform.rotation.eulerAngles + new Vector3(mainCamera.transform.rotation.eulerAngles.x, 180, 0);
        }

        if (other.gameObject.CompareTag("LifeSap") && !done)
        {
            done = true;
            clone = Instantiate(pressE, other.transform.position + new Vector3(0, 1f, 0), Quaternion.identity, worldCanvas.transform);
            clone.transform.LookAt(mainCamera.transform);
            clone.GetComponent<RectTransform>().eulerAngles = clone.transform.rotation.eulerAngles + new Vector3(100, 180, 0);
            //clone.GetComponent<RectTransform>().eulerAngles = clone.transform.rotation.eulerAngles + new Vector3(mainCamera.transform.rotation.eulerAngles.x, 180, 0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Crystals"))
        {
            Destroy(clone);
            done = false;
        }

        if(other.gameObject.CompareTag("FruitBowl"))
        {
            Destroy(clone);
            done = false;
        }

        if(other.gameObject.CompareTag("MagmaShell"))
        {
            Destroy(clone);
            done = false;
        }

        if(other.gameObject.CompareTag("FeyBlood"))
        {
            Destroy(clone);
            done = false;
        }

        if(other.gameObject.CompareTag("Honey"))
        {
            Destroy(clone);
            done = false;
        }

        if(other.gameObject.CompareTag("LifeSap"))
        {
            Destroy(clone);
            done = false;
        }
    }

}
