using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//fixed camera position
public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    [SerializeField] GameObject mainCamera;
    public bool isMoving;

    public float speed = 6f;
    float gravity = -9.81f;
    private float startRotation;

    public Transform groundCheck;
    public float groundDistance = 1.1f;
    public LayerMask groundMask;

    public float turnSmoothTime = 0.1f;
    Vector3 velocity;
    float turnSmoothVelocity;
    bool isGrounded;

    void Start()
    {
        startRotation = mainCamera.GetComponent<Camera>().transform.rotation.y;
    }


    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

         velocity.y += gravity * Time.deltaTime;

         controller.Move(velocity * Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle + startRotation + 90f, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle + startRotation, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
    }
}
