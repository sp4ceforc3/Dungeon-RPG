//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/BattleSystem/BattleControls.inputactions
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

public partial class @BattleControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @BattleControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BattleControls"",
    ""maps"": [
        {
            ""name"": ""Battle"",
            ""id"": ""1a8ee643-13ca-4a4e-b3da-1462d2e65dae"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""18e6529e-62f0-4e7a-917d-0c79102380e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Heal"",
                    ""type"": ""Button"",
                    ""id"": ""c51baa69-6ec6-4fa8-b605-7be118f1f9f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Defend"",
                    ""type"": ""Button"",
                    ""id"": ""d8bb2650-41cd-45c1-9769-5d776f9cf25b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""be5b7961-0133-4e2c-bc12-623ad2430506"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Godmode"",
                    ""type"": ""Button"",
                    ""id"": ""9c482f99-aaf2-4bc6-9a06-2bcdc7c1bec4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""354316c1-6f52-4780-a5c5-885967c42d8f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2faf9718-7203-45cf-821e-2d89780708da"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""765186ea-c9b2-4a16-93c2-4beef45ac76d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Defend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""227407d0-f5c9-406e-909f-65bcfd112cc4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b3f49aa-7f52-4ac4-b57d-b46a6ea9592a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""805a4eb2-c173-4be8-8359-8cd3ff71ba50"",
                    ""path"": ""<Keyboard>/pageUp"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Godmode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""168559fc-cb5e-44c5-bb71-cdbec56bee31"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Godmode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Battle
        m_Battle = asset.FindActionMap("Battle", throwIfNotFound: true);
        m_Battle_Attack = m_Battle.FindAction("Attack", throwIfNotFound: true);
        m_Battle_Heal = m_Battle.FindAction("Heal", throwIfNotFound: true);
        m_Battle_Defend = m_Battle.FindAction("Defend", throwIfNotFound: true);
        m_Battle_Run = m_Battle.FindAction("Run", throwIfNotFound: true);
        m_Battle_Godmode = m_Battle.FindAction("Godmode", throwIfNotFound: true);
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

    // Battle
    private readonly InputActionMap m_Battle;
    private List<IBattleActions> m_BattleActionsCallbackInterfaces = new List<IBattleActions>();
    private readonly InputAction m_Battle_Attack;
    private readonly InputAction m_Battle_Heal;
    private readonly InputAction m_Battle_Defend;
    private readonly InputAction m_Battle_Run;
    private readonly InputAction m_Battle_Godmode;
    public struct BattleActions
    {
        private @BattleControls m_Wrapper;
        public BattleActions(@BattleControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Battle_Attack;
        public InputAction @Heal => m_Wrapper.m_Battle_Heal;
        public InputAction @Defend => m_Wrapper.m_Battle_Defend;
        public InputAction @Run => m_Wrapper.m_Battle_Run;
        public InputAction @Godmode => m_Wrapper.m_Battle_Godmode;
        public InputActionMap Get() { return m_Wrapper.m_Battle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BattleActions set) { return set.Get(); }
        public void AddCallbacks(IBattleActions instance)
        {
            if (instance == null || m_Wrapper.m_BattleActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BattleActionsCallbackInterfaces.Add(instance);
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Heal.started += instance.OnHeal;
            @Heal.performed += instance.OnHeal;
            @Heal.canceled += instance.OnHeal;
            @Defend.started += instance.OnDefend;
            @Defend.performed += instance.OnDefend;
            @Defend.canceled += instance.OnDefend;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
            @Godmode.started += instance.OnGodmode;
            @Godmode.performed += instance.OnGodmode;
            @Godmode.canceled += instance.OnGodmode;
        }

        private void UnregisterCallbacks(IBattleActions instance)
        {
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Heal.started -= instance.OnHeal;
            @Heal.performed -= instance.OnHeal;
            @Heal.canceled -= instance.OnHeal;
            @Defend.started -= instance.OnDefend;
            @Defend.performed -= instance.OnDefend;
            @Defend.canceled -= instance.OnDefend;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
            @Godmode.started -= instance.OnGodmode;
            @Godmode.performed -= instance.OnGodmode;
            @Godmode.canceled -= instance.OnGodmode;
        }

        public void RemoveCallbacks(IBattleActions instance)
        {
            if (m_Wrapper.m_BattleActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBattleActions instance)
        {
            foreach (var item in m_Wrapper.m_BattleActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BattleActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BattleActions @Battle => new BattleActions(this);
    public interface IBattleActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnHeal(InputAction.CallbackContext context);
        void OnDefend(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnGodmode(InputAction.CallbackContext context);
    }
}
