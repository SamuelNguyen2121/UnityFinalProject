using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movent_Player : MonoBehaviour
{
    CharacterController controller;
    Rigidbody rb;
   

    [SerializeField]
    private float movementSpeed;

    private float diretion;

    [SerializeField]
    private float jumpHeight;

    private float gravityPull = -9.81f;
    private Vector3 velocity;
    [SerializeField]
    private Camera characterCam;
    bool onGround = true;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        Debug.Log("Started");
        

    }

    // Updat is called once per frame
    void Update()
    {



        if (Input.GetKey(KeyCode.A))
        {
            controller.Move(-transform.right * movementSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            controller.Move(transform.right * movementSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.W))
        {
            controller.Move(transform.forward * movementSpeed * Time.deltaTime);
            Run();
        }
        if (Input.GetKey(KeyCode.S))
        {
            controller.Move(-transform.forward * movementSpeed * Time.deltaTime);

        }

        Jump();

        velocity.y += gravityPull * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



    }

    private void Jump()
    {
        var ray = new Ray(transform.position, Vector3.down); // shoots raycast down always 
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.5f)) // Check if ray cast hit an object. Distance of the ray cast down is 1.5 units
        {
            onGround = true; //if the ray cast hit something than it is on the ground

        }
        else
        {
            onGround = false;// Means it's in the air

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)//read the bool value from the rayCast
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityPull);

            }
        }
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 7.5f;
            //smooth camera zoom out
            characterCam.fieldOfView = Mathf.Lerp(characterCam.fieldOfView, 80,Time.deltaTime * 5f);
            
        }
        else
        {
            movementSpeed = 5;
            //smooth camera zoom back in 
            characterCam.fieldOfView = Mathf.Lerp(characterCam.fieldOfView, 60, Time.deltaTime * 5f);
        }
       

    }

    

        /* void jump()
         {

             var ray = new Ray(transform.position, -transform.up);
             RaycastHit hit;
             if (Physics.Raycast(ray, out hit, 1.5f))
             {
                 onGround = true;
                 *//*Debug.Log("on Ground" + onGround);*//*
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     velocity.y = Mathf.Sqrt(jumpHeight * 2 * gravityPull);
                     onGround = false;

                 }
             }
             else
             {
                 onGround = false;
                 *//*Debug.Log("In AIr" + onGround);*//*
             }
     *//*        else
             {
                 onGround = true;
             }*//*

         }*/
    }
