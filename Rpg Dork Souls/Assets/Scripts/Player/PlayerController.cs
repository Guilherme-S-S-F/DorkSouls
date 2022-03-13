using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    InputHandler inputHandler;
    PlayerMovement playerMovement;    
    AnimatorHandler animatorHandler;
    [SerializeField]CameraHandler cameraHandler;
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

        animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0);

        if (animatorHandler.canRotate)
        {
            playerMovement.HandleRotation(delta);
        }
    }

    
}
