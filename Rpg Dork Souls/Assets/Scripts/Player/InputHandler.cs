using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{    
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    public bool b_input;
    public bool y_input;
    public bool x_input;

    public float rollInput;
    public float rollInputTimer;

    PlayerInput inputActions;
    PlayerController playerController;

    Vector2 movementInput;
    Vector2 cameraInput;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new PlayerInput();
            inputActions.PlayerMovement.Move.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
        HandleRollInput(delta);
        HandleHeavyAttack();
        HandleLightAttack();
    }

    private void MoveInput(float delta)
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }
    private void HandleRollInput(float delta)
    {
        b_input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Performed;

        if (b_input)
        {
            rollInputTimer += delta;
            playerController.sprintFlag = true;
        }
        else
        {
            if(rollInputTimer > 0 && rollInputTimer < 0.5f)
            {
                playerController.sprintFlag = false;
                playerController.dashFlag = true;
            }
            rollInputTimer = 0;
        }
    }
    private void HandleLightAttack()
    {
        y_input = inputActions.PlayerActions.LightAttack.phase == UnityEngine.InputSystem.InputActionPhase.Performed;

        if (y_input)
        {
            playerController.lightAttackFlag = true;
        }
        else
        {
            playerController.lightAttackFlag = false;
        }
    }
    private void HandleHeavyAttack()
    {
        x_input = inputActions.PlayerActions.HeavyAttack.phase == UnityEngine.InputSystem.InputActionPhase.Performed;

        if (x_input)
        {
            playerController.heavyAttackFlag = true;
        }
        else
        {
            playerController.heavyAttackFlag = false;
        }
    }
}
