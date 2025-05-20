using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [SerializeField] Transform orientation;
    [SerializeField] Transform lookAt;
    [SerializeField] Transform player;
    [SerializeField] Transform playerobj;
    [SerializeField] Rigidbody rb;
    [SerializeField] float rotationSpeed;

    public CameraStyle style;
    public enum CameraStyle
    {
        Basic,
        Combat,
    };
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {

        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        if (style == CameraStyle.Basic)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
            if (inputDir != Vector3.zero)
            {
                playerobj.forward = Vector3.Slerp(playerobj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);

            }

        }
        else if (style == CameraStyle.Combat)
        {

            Vector3 lookAtDir = lookAt.position - new Vector3(transform.position.x, lookAt.position.y, transform.position.z);
            orientation.forward = lookAtDir.normalized;
            playerobj.forward = lookAtDir.normalized;
        }
    }
}
