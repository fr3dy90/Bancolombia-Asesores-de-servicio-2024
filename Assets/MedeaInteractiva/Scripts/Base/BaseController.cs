using UnityEngine;

public class BaseController : MonoBehaviour
{
    private UIState _currentState;
    private BaseView _baseView;
    
    public virtual void Init()
    {
        _baseView.Initialize();   
    }
    
    public UIState GetCurrentState()
    {
        return _currentState;
    }
    
    public CanvasGroup GetCanvasGroup()
    {
        return _baseView.GetCanvasGroup();
    }
}
