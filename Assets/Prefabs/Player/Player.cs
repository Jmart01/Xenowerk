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
    [SerializeField] private Weapon[] startWeaponPrefabs;
    [SerializeField] private Transform weaponSocket;
    private HealthComponent _playerHealth;
    
    private List<Weapon> Weapons;
    private int CurrentActiveWeaponIndex = 0;
    private Weapon currentActiveWeapon;
    private AnimatorOverrideController OverrideController;
    private InGameUI _inGameUI;
    
    
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
        OverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = OverrideController;

        _playerHealth = GetComponent<HealthComponent>();
        _playerHealth._onDamageTaken += PlayerTookDmg;
        
        UpperBodyIndex = animator.GetLayerIndex("UpperBody");
        Weapons = new List<Weapon>();
        
        inputActions.Gameplay.Movement.performed += MovementOnperformed;
        inputActions.Gameplay.Movement.canceled += MovementOncanceled;
        inputActions.Gameplay.CursorPosition.performed += CursorPositionOnperformed;
        inputActions.Gameplay.Fire.performed += Fire;
        inputActions.Gameplay.Fire.canceled += StopFire;
        inputActions.Gameplay.SwapWeapons.performed += SwapWeapon;
        inputActions.UI.Pause.performed += TogglePause;
        InitializeWeapons();
        if (_inGameUI == null)
        {
            _inGameUI = FindObjectOfType<InGameUI>();
        }
        _inGameUI.SetPlayerHealth(_playerHealth.GetMaxHitpoints(),10,_playerHealth.GetMaxHitpoints());
    }

    private void PlayerTookDmg(int newamt, int oldamt, GameObject instigator)
    {
        _inGameUI.SetPlayerHealth(newamt, oldamt, _playerHealth.GetMaxHitpoints());
    }


    private void TogglePause(InputAction.CallbackContext obj)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            if (_inGameUI != null)
            {
                _inGameUI.SwitchToInGamePanel();
            }
        }
        else
        {
            Time.timeScale = 0;
            if(_inGameUI)
            {
                _inGameUI.SwitchToPausePanel();
                inputActions.Gameplay.Disable();
            }
        }
    }

    private void SwapWeapon(InputAction.CallbackContext ctx)
    {
        int IndexDelta = ctx.ReadValue<Vector2>().y > 0 ? 1 : -1;
        CurrentActiveWeaponIndex += IndexDelta;
        if (CurrentActiveWeaponIndex >= Weapons.Count)
        {
            CurrentActiveWeaponIndex = 0;
        }

        if (CurrentActiveWeaponIndex < 0)
        {
            CurrentActiveWeaponIndex = Weapons.Count - 1;
        }
        EquipWeapon(CurrentActiveWeaponIndex);
    }
    void InitializeWeapons()
    {
        foreach (Weapon weapon in startWeaponPrefabs)
        {
            Weapon newWeapon = Instantiate(weapon, weaponSocket);
            newWeapon.transform.position = weaponSocket.position;
            newWeapon.transform.rotation = weaponSocket.rotation;
            newWeapon.transform.parent = weaponSocket;
            newWeapon.SetActive(false);
            Weapons.Add(newWeapon);
        }
        EquipWeapon(0);
    }

    void EquipWeapon(int weaponIndex)
    {
        if (weaponIndex > Weapons.Count || Weapons[weaponIndex] == currentActiveWeapon)
        {
            return;
        }
        if (currentActiveWeapon != null)
        {
            currentActiveWeapon.SetActive(false);
        }

        CurrentActiveWeaponIndex = weaponIndex;
        currentActiveWeapon = Weapons[CurrentActiveWeaponIndex];
        currentActiveWeapon.SetActive(true);
        OverrideController["Firing"] = currentActiveWeapon.GetFireAnimation();
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
        currentActiveWeapon.Fire();
    }
}
