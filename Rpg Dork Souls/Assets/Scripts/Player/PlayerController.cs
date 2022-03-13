using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    InputHandler inputHandler;
    PlayerMovement playerMovement;    
    AnimatorHandler animatorHandler;
    [SerializeField]CameraHandler cameraHandler;

    [Header("Players Flags")]
    public bool isInteracting;
    public bool isSpriting;
    public bool sprintFlag;
    public bool rollFlag;

    private void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        playerMovement = GetComponent<PlayerMovement>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();        
    }
    private void Update()
    {
        float delta = Time.deltaTime;

        inputHandler.TickInput(delta);        
        animatorHandler.Initialize();       
        playerMovement.HandleMovement(delta);
        cameraHandler.HandleCameraRotation();

        isInteracting = animatorHandler.anim.GetBool("isInteracting");
        sprintFlag = false;
        rollFlag = false;

        isSpriting = inputHandler.b_input;
        

        animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0, isSpriting);

        if (animatorHandler.canRotate)
        {
            playerMovement.HandleRotation(delta);
        }
    }

    
}
