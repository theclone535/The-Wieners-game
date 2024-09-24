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
    [SerializeField] private GameObject orderHandler;
    [SerializeField] private OrderLogic orderlogic;
    [SerializeField] private float speed;
    GameObject clone;
    bool spawn;
    public bool bench;
    public bool reached;
    


    void Start()
    {
        inventory = player.GetComponent<Inventory>();
        orderlogic = orderHandler.GetComponent<OrderLogic>();
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

            clone = Instantiate(customers[0], point1.transform.position, Quaternion.identity);//Random.Range(0, 6)
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

        if (clone.transform.position == point1.transform.position)
        {
            orderlogic.atPoint1 = true;
        }

        if (bench && reached && Input.GetKey("e"))
        {
            orderlogic.interacted = true;
        }else
        {
            orderlogic.interacted = false;
        }

        
    }

    
}
