using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class BsseSceneController : MonoBehaviour
{
    public static BsseSceneController Instance;
   [SerializeField] private UIState _currentState;
   [SerializeField] private BaseController[] _controllers;
   [SerializeField] private Dictionary<UIState, BaseController> _controllerStates = new Dictionary<UIState,BaseController>();
   [SerializeField] private CanvasGroup _canvasGroup;
   public MainMenu _currentMenuState;

   private void Awake()
   {
       if (Instance == null)
       {
           Instance = this;
       }
       else
       {
           Destroy(gameObject);
       }
       
       foreach (BaseController controller in _controllers)
       {
           controller.Init();
           _controllerStates[controller.GetCurrentState()] = controller;
       }
   }

   private async void Start()
   {
       BaseController controller = _controllerStates[_currentState];
       await ToolBox.SimpleTransition(GetCanvasGroup(), 0, controller.GetCanvasGroup(), 0, .5f, 1f, null);
       controller.OnStart();
   }

   public async UniTask ChangeState(UIState state, Action onComplete = null)
    {
    
         UIStateTransition stateFrom = new UIStateTransition {uiState = _currentState, canvasGroupAlpha = 1};
         UIStateTransition stateTo = new UIStateTransition {uiState = state, canvasGroupAlpha = 0};
         await MakeTransition(stateFrom, stateTo, () =>
         {
              _currentState = state;
              onComplete?.Invoke();
              OnInit(_currentState);
         });
    }

    public async UniTask MakeTransition(UIStateTransition stateFrom, UIStateTransition stateTo, Action onComplete = null)
    {
       BaseController controllerFrom = _controllerStates[stateFrom.uiState];
       BaseController controllerTo = _controllerStates[stateTo.uiState];
       ToolBox.SimpleTransition(controllerFrom.GetCanvasGroup() , stateFrom.canvasGroupAlpha, controllerTo.GetCanvasGroup(), stateTo.canvasGroupAlpha, .5f, 1, onComplete);
    }
    
    public CanvasGroup GetCanvasGroup()
    {
        return _canvasGroup;
    }

    void OnInit(UIState newState)
    {
        BaseController controller = _controllerStates[newState];
        controller.OnStart();
    }
}

public enum UIState
{
    Welcome,
    Menu,
    ModalIntro
}

public enum MainMenu
{
    Conoce,
    Clasifica,
    Conecta
}

public struct UIStateTransition
{
    public UIState uiState;
    public float canvasGroupAlpha;
}






