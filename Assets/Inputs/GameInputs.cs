//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs/GameInputs.inputactions
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

public partial class @GameInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Board"",
            ""id"": ""fde276f4-a751-430d-91f2-f7c1951d053f"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""5c2c3354-0418-4d1d-b0ce-d0e7aa83550c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ViewCards"",
                    ""type"": ""Button"",
                    ""id"": ""0b1f5b05-331f-4155-8e50-290076fe0250"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""042831ae-c076-4dd8-b960-729f517542c5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""707a228f-0784-49df-8ae7-90cbb1dfab3a"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewCards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Board
        m_Board = asset.FindActionMap("Board", throwIfNotFound: true);
        m_Board_Select = m_Board.FindAction("Select", throwIfNotFound: true);
        m_Board_ViewCards = m_Board.FindAction("ViewCards", throwIfNotFound: true);
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

    // Board
    private readonly InputActionMap m_Board;
    private List<IBoardActions> m_BoardActionsCallbackInterfaces = new List<IBoardActions>();
    private readonly InputAction m_Board_Select;
    private readonly InputAction m_Board_ViewCards;
    public struct BoardActions
    {
        private @GameInputs m_Wrapper;
        public BoardActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Board_Select;
        public InputAction @ViewCards => m_Wrapper.m_Board_ViewCards;
        public InputActionMap Get() { return m_Wrapper.m_Board; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BoardActions set) { return set.Get(); }
        public void AddCallbacks(IBoardActions instance)
        {
            if (instance == null || m_Wrapper.m_BoardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BoardActionsCallbackInterfaces.Add(instance);
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
            @ViewCards.started += instance.OnViewCards;
            @ViewCards.performed += instance.OnViewCards;
            @ViewCards.canceled += instance.OnViewCards;
        }

        private void UnregisterCallbacks(IBoardActions instance)
        {
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
            @ViewCards.started -= instance.OnViewCards;
            @ViewCards.performed -= instance.OnViewCards;
            @ViewCards.canceled -= instance.OnViewCards;
        }

        public void RemoveCallbacks(IBoardActions instance)
        {
            if (m_Wrapper.m_BoardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBoardActions instance)
        {
            foreach (var item in m_Wrapper.m_BoardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BoardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BoardActions @Board => new BoardActions(this);
    public interface IBoardActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnViewCards(InputAction.CallbackContext context);
    }
}
