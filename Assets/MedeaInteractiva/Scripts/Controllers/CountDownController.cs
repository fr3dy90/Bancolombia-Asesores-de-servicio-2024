using UnityEngine;

public class CountDownController : BaseController
{
    [SerializeField] private CountDownView _view;
    
    public override void Init()
    {
        base.Init();
        _view = GetComponentInChildren<CountDownView>();
    }
    
    public override void OnStart()
    {
        base.OnStart();
        _view.InitCountDown();
    }
}