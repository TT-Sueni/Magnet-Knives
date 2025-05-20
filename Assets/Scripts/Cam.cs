using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cam : MonoBehaviour
{

    [SerializeField]private float sensX;
    [SerializeField]private float sensY;
                    
    [SerializeField]private Transform orientation;
              
    [SerializeField]private float xRotation;
    [SerializeField]private float yRotation;

    void Start()
    {
        

    }


    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensX * Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

}
