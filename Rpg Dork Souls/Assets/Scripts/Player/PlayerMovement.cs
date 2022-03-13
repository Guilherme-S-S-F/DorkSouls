using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0.1f, 15f)][SerializeField] float speed = 5f;
    [Range(0.1f, 20f)][SerializeField] float jumpHeight = 15f;
    [Range(0.1f, 60f)][SerializeField] float rotationSpeed = 30f;
    [Range(0.1f, 10.81f)][SerializeField] float gravity = 10.81f;

    public float Gravity { get { return gravity; } set { gravity = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public float JumpHeight { get { return jumpHeight; } set { jumpHeight = value; } }
    public float RotationSpeed { get { return rotationSpeed; } set { rotationSpeed = value; } }

    Vector3 moveDirection;

    Transform cameraObject;
    Transform myTransform;

    CharacterController characterController;
    PlayerController playerController;
    InputHandler inputHandler;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
        inputHandler = GetComponent<InputHandler>();
        cameraObject = Camera.main.transform;
        myTransform = transform;
    }

    #region Movement
    Vector3 normalVector;
    Vector3 targetPosition;
    public void HandleRotation(float delta)
    {
        Vector3 targetDir = Vector3.zero;

        targetDir = cameraObject.transform.forward * inputHandler.vertical;
        targetDir += cameraObject.transform.right * inputHandler.horizontal;

        targetDir.Normalize();
        targetDir.y = 0;

        if(targetDir == Vector3.zero)
            targetDir = myTransform.forward;

        float rs = rotationSpeed;

        Quaternion tr = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);

        myTransform.rotation = targetRotation;
    }

    public void HandleMovement(float delta)
    {
        moveDirection = myTransform.forward * Mathf.Abs(inputHandler.vertical);
        moveDirection += myTransform.forward * Mathf.Abs(inputHandler.horizontal); 
        
        moveDirection.Normalize();

        characterController.Move(moveDirection * speed * delta);

        // Adds gravity to the character controller
        Vector3 AddGravity = Vector3.up * -gravity;
        characterController.Move(AddGravity * delta);
    }
    #endregion

}