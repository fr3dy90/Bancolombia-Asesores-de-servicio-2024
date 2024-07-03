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
        OnStart();
    }
    
    public UIState GetCurrentState()
    {
        return _currentState;
    }
    
    public CanvasGroup GetCanvasGroup()
    {
        return _baseView.GetCanvasGroup();
    }
    
    protected virtual void OnStart()
    {
        
    }
}
