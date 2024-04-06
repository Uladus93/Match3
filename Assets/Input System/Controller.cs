//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input System/Controller.inputactions
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

public partial class @Controller: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""PlayMode"",
            ""id"": ""10eff6ae-4d66-4c46-9cb5-72c9bf4b11d5"",
            ""actions"": [
                {
                    ""name"": ""TokenInterpretator"",
                    ""type"": ""Value"",
                    ""id"": ""a213e088-8d5c-4d4b-aa3a-5df09c73ecfe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""638797a6-5963-4ed2-aa8d-e86a30c93d1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d1b1b6c3-07be-4f64-a993-0b97c13dad8e"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""TokenInterpretator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca987c6f-6dfc-4447-ae38-9bab2d161526"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""TokenInterpretator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b459d708-d2a6-44eb-942f-371ebd9fa368"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50289893-4cad-48cf-a84a-b947d28700db"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""TouchScreen"",
            ""bindingGroup"": ""TouchScreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayMode
        m_PlayMode = asset.FindActionMap("PlayMode", throwIfNotFound: true);
        m_PlayMode_TokenInterpretator = m_PlayMode.FindAction("TokenInterpretator", throwIfNotFound: true);
        m_PlayMode_Press = m_PlayMode.FindAction("Press", throwIfNotFound: true);
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

    // PlayMode
    private readonly InputActionMap m_PlayMode;
    private List<IPlayModeActions> m_PlayModeActionsCallbackInterfaces = new List<IPlayModeActions>();
    private readonly InputAction m_PlayMode_TokenInterpretator;
    private readonly InputAction m_PlayMode_Press;
    public struct PlayModeActions
    {
        private @Controller m_Wrapper;
        public PlayModeActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @TokenInterpretator => m_Wrapper.m_PlayMode_TokenInterpretator;
        public InputAction @Press => m_Wrapper.m_PlayMode_Press;
        public InputActionMap Get() { return m_Wrapper.m_PlayMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayModeActions set) { return set.Get(); }
        public void AddCallbacks(IPlayModeActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayModeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayModeActionsCallbackInterfaces.Add(instance);
            @TokenInterpretator.started += instance.OnTokenInterpretator;
            @TokenInterpretator.performed += instance.OnTokenInterpretator;
            @TokenInterpretator.canceled += instance.OnTokenInterpretator;
            @Press.started += instance.OnPress;
            @Press.performed += instance.OnPress;
            @Press.canceled += instance.OnPress;
        }

        private void UnregisterCallbacks(IPlayModeActions instance)
        {
            @TokenInterpretator.started -= instance.OnTokenInterpretator;
            @TokenInterpretator.performed -= instance.OnTokenInterpretator;
            @TokenInterpretator.canceled -= instance.OnTokenInterpretator;
            @Press.started -= instance.OnPress;
            @Press.performed -= instance.OnPress;
            @Press.canceled -= instance.OnPress;
        }

        public void RemoveCallbacks(IPlayModeActions instance)
        {
            if (m_Wrapper.m_PlayModeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayModeActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayModeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayModeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayModeActions @PlayMode => new PlayModeActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    private int m_TouchScreenSchemeIndex = -1;
    public InputControlScheme TouchScreenScheme
    {
        get
        {
            if (m_TouchScreenSchemeIndex == -1) m_TouchScreenSchemeIndex = asset.FindControlSchemeIndex("TouchScreen");
            return asset.controlSchemes[m_TouchScreenSchemeIndex];
        }
    }
    public interface IPlayModeActions
    {
        void OnTokenInterpretator(InputAction.CallbackContext context);
        void OnPress(InputAction.CallbackContext context);
    }
}
