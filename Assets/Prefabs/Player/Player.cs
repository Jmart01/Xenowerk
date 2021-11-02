using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private MovementComponent MovementComp;

    private InputActions inputActions;
    private Animator animator;
    private int UpperBodyIndex;

    private void Awake()
    {
        inputActions = new InputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        MovementComp = GetComponent<MovementComponent>();
        animator = GetComponent<Animator>();
        UpperBodyIndex = animator.GetLayerIndex("UpperBody");
        inputActions.Gameplay.Movement.performed += MovementOnperformed;
        inputActions.Gameplay.Movement.canceled += MovementOncanceled;
        inputActions.Gameplay.CursorPosition.performed += CursorPositionOnperformed;
        inputActions.Gameplay.Fire.performed += Fire;
        inputActions.Gameplay.Fire.canceled += StopFire;
    }

    private void StopFire(InputAction.CallbackContext ctx)
    {
        animator.SetLayerWeight(UpperBodyIndex, 0);
    }

    private void Fire(InputAction.CallbackContext ctx)
    {
        animator.SetLayerWeight(UpperBodyIndex, 1);
    }

    private void CursorPositionOnperformed(InputAction.CallbackContext obj)
    {
        MovementComp.SetCursorPosition(obj.ReadValue<Vector2>());
    }

    private void MovementOncanceled(InputAction.CallbackContext ctx)
    {
        MovementComp.SetMovementInput(ctx.ReadValue<Vector2>());
    }

    private void MovementOnperformed(InputAction.CallbackContext ctx)
    {
        MovementComp.SetMovementInput(ctx.ReadValue<Vector2>());
    }

    void UpdateAnimationParameters()
    {
        Vector3 PlayerFacingDirection = MovementComp.GetPlayerDesiredLookDir();
        Vector3 PlayerMoveDir = MovementComp.GetPlayerDesiredMoveDir();
        Vector3 PlayerRight = transform.right;
        float ForwardDistribution = Vector3.Dot(PlayerFacingDirection, PlayerMoveDir);
        float RightDistribution = Vector3.Dot(PlayerRight, PlayerMoveDir);
        animator.SetFloat("MoveForward", ForwardDistribution);
        animator.SetFloat("MoveLeft", RightDistribution);
        
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAnimationParameters();
    }

    public void FireTimePoint()
    {
        GetComponentInChildren<Weapon>().Fire();
    }
}
