//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Input/GameInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputAction"",
    ""maps"": [
        {
            ""name"": ""Base Action Map"",
            ""id"": ""635be0df-a417-4e8b-8bb5-f6aa39f3e0c8"",
            ""actions"": [
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""883b9e9a-dbd6-423a-b7d8-f6f97b7fb5f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Directional Movement"",
                    ""type"": ""Value"",
                    ""id"": ""7edcd013-8a27-47ec-85b5-63e5cda9eaa7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Directional Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""c82ec101-d477-4450-885b-c71e6fbda3ac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""04a7e4d4-2239-4dcc-b56e-b1e97d0d0dce"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""1316429b-ca7d-4504-bc7a-bf41079d040d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bf6fb694-813a-4499-9fc9-b9410c9b9687"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9a482a3d-bbe5-4922-bf6a-c0a0f6b84ef4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ed1d5185-bc4e-4095-b4da-2794e425e02b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""de9b734c-eb77-4ce9-8388-bd23c8a67148"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse Movement"",
                    ""id"": ""67669c61-a287-438f-a3f1-e18014f34b2f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""3d3aa537-bd21-4923-9c3a-86d73ae99585"",
                    ""path"": ""<Mouse>/delta/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""c6790505-e698-4b3a-9066-817e07f66c6e"",
                    ""path"": ""<Mouse>/delta/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""956586b1-5d3e-4561-ad61-7ed844b90184"",
                    ""path"": ""<Mouse>/delta/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""de674777-9f01-43b2-af9c-d1aa6fc1969c"",
                    ""path"": ""<Mouse>/delta/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Base Action Map
        m_BaseActionMap = asset.FindActionMap("Base Action Map", throwIfNotFound: true);
        m_BaseActionMap_Escape = m_BaseActionMap.FindAction("Escape", throwIfNotFound: true);
        m_BaseActionMap_DirectionalMovement = m_BaseActionMap.FindAction("Directional Movement", throwIfNotFound: true);
        m_BaseActionMap_DirectionalRotation = m_BaseActionMap.FindAction("Directional Rotation", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Base Action Map
    private readonly InputActionMap m_BaseActionMap;
    private List<IBaseActionMapActions> m_BaseActionMapActionsCallbackInterfaces = new List<IBaseActionMapActions>();
    private readonly InputAction m_BaseActionMap_Escape;
    private readonly InputAction m_BaseActionMap_DirectionalMovement;
    private readonly InputAction m_BaseActionMap_DirectionalRotation;
    public struct BaseActionMapActions
    {
        private @GameInputAction m_Wrapper;
        public BaseActionMapActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Escape => m_Wrapper.m_BaseActionMap_Escape;
        public InputAction @DirectionalMovement => m_Wrapper.m_BaseActionMap_DirectionalMovement;
        public InputAction @DirectionalRotation => m_Wrapper.m_BaseActionMap_DirectionalRotation;
        public InputActionMap Get() { return m_Wrapper.m_BaseActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IBaseActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Add(instance);
            @Escape.started += instance.OnEscape;
            @Escape.performed += instance.OnEscape;
            @Escape.canceled += instance.OnEscape;
            @DirectionalMovement.started += instance.OnDirectionalMovement;
            @DirectionalMovement.performed += instance.OnDirectionalMovement;
            @DirectionalMovement.canceled += instance.OnDirectionalMovement;
            @DirectionalRotation.started += instance.OnDirectionalRotation;
            @DirectionalRotation.performed += instance.OnDirectionalRotation;
            @DirectionalRotation.canceled += instance.OnDirectionalRotation;
        }

        private void UnregisterCallbacks(IBaseActionMapActions instance)
        {
            @Escape.started -= instance.OnEscape;
            @Escape.performed -= instance.OnEscape;
            @Escape.canceled -= instance.OnEscape;
            @DirectionalMovement.started -= instance.OnDirectionalMovement;
            @DirectionalMovement.performed -= instance.OnDirectionalMovement;
            @DirectionalMovement.canceled -= instance.OnDirectionalMovement;
            @DirectionalRotation.started -= instance.OnDirectionalRotation;
            @DirectionalRotation.performed -= instance.OnDirectionalRotation;
            @DirectionalRotation.canceled -= instance.OnDirectionalRotation;
        }

        public void RemoveCallbacks(IBaseActionMapActions instance)
        {
            if (m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBaseActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_BaseActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BaseActionMapActions @BaseActionMap => new BaseActionMapActions(this);
    public interface IBaseActionMapActions
    {
        void OnEscape(InputAction.CallbackContext context);
        void OnDirectionalMovement(InputAction.CallbackContext context);
        void OnDirectionalRotation(InputAction.CallbackContext context);
    }
}
