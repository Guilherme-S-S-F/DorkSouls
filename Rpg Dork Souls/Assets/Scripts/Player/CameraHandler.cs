using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] Transform target;
    [Range(0.1f, 30f)][SerializeField] float rotationSpeed;
    [Range(0.1f, 1f)][SerializeField] float sensitivy;

    public float RotationSpeed { get { return rotationSpeed; } set { rotationSpeed = value; } }
    public float Sensitivy { get { return sensitivy; } set { sensitivy = value; } }

    Transform myTransform;
    InputHandler inputHandler;

    private void Start()
    {
        myTransform = transform;
        inputHandler = GameObject.Find("Player").GetComponent<InputHandler>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        myTransform.position = target.position;
    }
    public void HandleCameraRotation()
    {
        // XRotation of the camera
        myTransform.rotation *= Quaternion.AngleAxis(inputHandler.mouseX * rotationSpeed * sensitivy, Vector3.up);

        // XRotation of the camera
        myTransform.rotation *= Quaternion.AngleAxis(-inputHandler.mouseY * rotationSpeed * sensitivy, Vector3.right);

        var angles = myTransform.eulerAngles;
        angles.z = 0;

        var angle = myTransform.eulerAngles.x;

        if(angle > 180 && angle < 300)
        {
            angles.x = 300;
        }
        else if(angle < 180 && angle > 60)
        {
            angles.x = 60;
        }
        myTransform.localEulerAngles = angles;
    }
}
