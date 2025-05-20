
using UnityEngine;


public class playerRotation : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 10f;
    float mouseX = 0;
    float mouseY = 0;
    Rigidbody rb;
    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        float x = Input.GetAxis("Mouse X") * rotationSpeed;
        float y = Input.GetAxis("Mouse Y") * rotationSpeed;

       

        mouseX += x;
        mouseY -= y;

        mouseY = Mathf.Clamp(mouseY, 0f, 0f);
        mouseX = Mathf.Clamp(mouseY, -70f, 50f);




        transform.rotation = Quaternion.Euler( mouseY, mouseX, 0);
        


    }

}
