using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private Transform transformBody;

    [SerializeField]
    public static float sensitivity = 200f;

    private float rotatXAxis = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseVertical = Input.GetAxis("Mouse Y") * sensitivity *  Time.deltaTime;

        
        
        rotatXAxis = Mathf.Clamp(rotatXAxis, -80f, 80f);
        rotatXAxis -= mouseVertical;
        transform.localRotation = Quaternion.Euler( rotatXAxis, 0f, 0f);
        transformBody.Rotate(Vector3.up * mouseHorizontal);




    }
}
