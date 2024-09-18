using System;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] protected UIState _currentState;
    protected BaseView _baseView;
    
    public virtual void Init()
    {
        if(_baseView == null)
        {
            _baseView = GetComponentInChildren<BaseView>();
        }
        _baseView.Initialize();
    }
    
    public UIState GetCurrentState()
    {
        return _currentState;
    }
    
    public CanvasGroup GetCanvasGroup()
    {
        if (_baseView != null)
        {
            return _baseView.GetCanvasGroup() == null ? null : _baseView.GetCanvasGroup();
        }
        else
        {
            return null;
        }
    }
    
    public virtual void OnStart()
    {
        
    }
}
