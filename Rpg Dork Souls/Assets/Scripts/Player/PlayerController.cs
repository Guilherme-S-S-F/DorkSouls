using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    InputHandler inputHandler;
    public PlayerMovement playerMovement;    
    public AnimatorHandler animatorHandler;
    [SerializeField]CameraHandler cameraHandler;

    public float dashCooldown = 2f;
    [HideInInspector] public float dashTimer = 0f;

    [Header("Players Flags")]
    public bool isInteracting;
    public bool isSpriting;
    public bool sprintFlag;
    public bool dashFlag;
    public bool canDash;
    public bool isDashCooldown;
    public bool heavyAttackFlag;
    public bool lightAttackFlag;


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
        playerMovement.HandleRolling(delta);
        playerMovement.HandleAttack(delta);

        isInteracting = animatorHandler.anim.GetBool("isInteracting");
        sprintFlag = false;
        dashFlag = false;

        isSpriting = inputHandler.b_input;

        animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0, isSpriting);        

        if (animatorHandler.canRotate)
        {
            playerMovement.HandleRotation(delta);
        }

        if (isDashCooldown)
        {
            dashTimer -= 1 * Time.deltaTime;

            if(dashTimer <= 0)
            {
                dashTimer = 0;
                isDashCooldown = false;
            }
        }
    }        
   
}
