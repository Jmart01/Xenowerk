// GENERATED AUTOMATICALLY FROM 'Assets/Prefabs/Player/Inputs/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""ef9e7102-0a3e-411c-8052-d44524f9436a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""55355247-0bfa-4c6b-8f54-93ddd8cc20f8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CursorPosition"",
                    ""type"": ""Value"",
                    ""id"": ""afab1484-928d-4cc2-bbc8-e9a19619f54c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""61ae37c0-67ae-4044-ad7c-455e95076372"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapWeapons"",
                    ""type"": ""Value"",
                    ""id"": ""06f25536-c31b-49ed-9acc-6e04b922831a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4f359cb3-4943-464e-9f60-e155f1e25696"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7bbf9e91-4e80-47a5-a8d1-de752e5c8827"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d2a68b9c-035e-44fd-a1eb-40a10c434370"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""112aa8e9-c7b2-4603-acfd-42ad5739915b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8eebcc0e-bc3d-48df-a984-6d563ae30cbb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6089c428-afa0-45a3-ad23-6bbac7525661"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66a03b7a-eb8d-43f0-9fc9-360081563f54"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""415a1724-5964-4d2c-9966-053be0d4ea57"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapWeapons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""03e3bb18-5e0a-4711-be15-845599fbf8ef"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""9917e59d-f8ed-4ba5-b183-9bc7ac5771e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a857bcfe-c7d3-43c7-a5cc-463f69460826"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_CursorPosition = m_Gameplay.FindAction("CursorPosition", throwIfNotFound: true);
        m_Gameplay_Fire = m_Gameplay.FindAction("Fire", throwIfNotFound: true);
        m_Gameplay_SwapWeapons = m_Gameplay.FindAction("SwapWeapons", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_CursorPosition;
    private readonly InputAction m_Gameplay_Fire;
    private readonly InputAction m_Gameplay_SwapWeapons;
    public struct GameplayActions
    {
        private @InputActions m_Wrapper;
        public GameplayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @CursorPosition => m_Wrapper.m_Gameplay_CursorPosition;
        public InputAction @Fire => m_Wrapper.m_Gameplay_Fire;
        public InputAction @SwapWeapons => m_Wrapper.m_Gameplay_SwapWeapons;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @CursorPosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCursorPosition;
                @CursorPosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCursorPosition;
                @CursorPosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCursorPosition;
                @Fire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @SwapWeapons.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwapWeapons;
                @SwapWeapons.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwapWeapons;
                @SwapWeapons.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwapWeapons;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @CursorPosition.started += instance.OnCursorPosition;
                @CursorPosition.performed += instance.OnCursorPosition;
                @CursorPosition.canceled += instance.OnCursorPosition;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @SwapWeapons.started += instance.OnSwapWeapons;
                @SwapWeapons.performed += instance.OnSwapWeapons;
                @SwapWeapons.canceled += instance.OnSwapWeapons;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Pause;
    public struct UIActions
    {
        private @InputActions m_Wrapper;
        public UIActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCursorPosition(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSwapWeapons(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
