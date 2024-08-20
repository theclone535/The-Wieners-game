using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private ThirdPersonMovement movement;
    [SerializeField] private bool moving;
    [SerializeField] private Transform anchor;
    [SerializeField] private float towardSpeed;
    [SerializeField] private float delayAmount = 5f;
    [SerializeField] private float delay;
    void Start()
    {
        movement = player.GetComponent<ThirdPersonMovement>();
        delay = delayAmount;
    }

    void Update()
    {
        moving = movement.isMoving;
        Vector3 pp = player.transform.position;
        Vector3 playerAnchor = new Vector3(pp.x, pp.y + 3, pp.z - 2);
        

        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerAnchor, towardSpeed * Time.deltaTime);
            delay = delayAmount;

        }else
        {
            if (delay <= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, anchor.position, 5 * Time.deltaTime);
            }
            delay -= Time.deltaTime;
            if (delay <= -1)
            {
                delay = -1;
            }
        }
    }
    
}
