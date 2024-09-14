using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLogic : MonoBehaviour
{
    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;
    [SerializeField] private GameObject[] customers;
    [SerializeField] private GameObject player;
    [SerializeField] private Inventory inventory;
    [SerializeField] private float speed;
    GameObject clone;

    void Start()
    {
        inventory = player.GetComponent<Inventory>();
    }
    void Update()
    {
        if (Input.GetKeyDown("c"))//inventory.newOrder
        {
            clone = Instantiate(customers[0], point1.transform.position, Quaternion.identity);//Random.Range(0, 6)
        }
        if (clone)
        {
            clone.transform.position = Vector3.MoveTowards(clone.transform.position, point2.transform.position, speed * Time.deltaTime);
        }
        
    }
}
