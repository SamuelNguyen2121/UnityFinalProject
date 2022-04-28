using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movent_Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
   

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float jumpHeight;

    private Vector3 velocity;
    [SerializeField]
    private Camera characterCam;
    bool onGround = true;

    [SerializeField]
    float runFOV;

    public static float startFOV = 90f;

    [SerializeField]
    private CapsuleCollider playerCollider;

    PlayerShooter shooter;
    private Transform initialTransform;

    // Start is called before the first frame update
    void Start()
    {        
        Debug.Log("Started");

          characterCam.fieldOfView = startFOV;
        initialTransform = GetComponent<Transform>();

    }

    // Updat is called once per frame
    void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(inputX, 0, inputY)  * Time.deltaTime * movementSpeed);
        if(inputY > 0) 
        {
            Run();

        }


        Debug.DrawRay(playerCollider.transform.position, new Vector3(0f,-0.2f,0f),Color.yellow);


        /*if (Input.GetKey(KeyCode.A))
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

        if (Input.GetKeyDown(KeyCode.N))
        {
           transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }*/

        Jump();

      //  velocity.y += gravityPull * Time.deltaTime;
       // controller.Move(velocity * Time.deltaTime);


       



    }

    private void Jump()
    {
        var ray = new Ray(playerCollider.transform.position, Vector3.down); // shoots raycast down always 
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2)) // Check if ray cast hit an object. Distance of the ray cast down is 1.5 units
        {
            onGround = true; //if the ray cast hit something than it is on the ground

        }
        else
        {
            onGround = false;// Character is in the air

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround )//read the bool value from the rayCast
            {
                rb = GetComponent<Rigidbody>();
                 rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

/*                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityPull);
                movementSpeed /= 1.5f;*/

            }
        }
    }

    void Run()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 7.5f;
            //smooth camera zoom out
            characterCam.fieldOfView = Mathf.Lerp(characterCam.fieldOfView, runFOV ,Time.deltaTime * 5f);
            
        }
        else
        {
            movementSpeed = 5;
            //smooth camera zoom back in 
            characterCam.fieldOfView = Mathf.Lerp(characterCam.fieldOfView, startFOV , Time.deltaTime * 5f);
        }
    }


   

    
}
