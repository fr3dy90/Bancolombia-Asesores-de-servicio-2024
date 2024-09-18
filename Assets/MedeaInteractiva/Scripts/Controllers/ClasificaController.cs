using System;
using UnityEngine;

public class ClasificaController : BaseController
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private StrDropZone _dropZoneDispositivos;
    [SerializeField] private StrDropZone _dropZoneSeguridad;
    [SerializeField] private StrDropZone _dropZonePapeleria;
    [SerializeField] private RectTransform _spawnPoint;
    
    [SerializeField] private ClasificaView _view;
    [SerializeField] private int _currentIndex;
    [SerializeField] private float _currentTime;
    [SerializeField] private bool _isTimer = false;
    
    [Range(.5f, 5f)] public float _zOffset = 5f;
    [Range(100f, 2000)] public float factor;
    public bool test;
    
    [SerializeField] private float _dispositivosCounter;
    [SerializeField] private float _seguridadCounter;
    [SerializeField] private float _papeleriaCounter;
    
    private const float DISPOSITIVOS_MAX = 5;
    private const float SEGURIDAD_MAX = 7;
    private const float PAPELERIA_MAX = 12;
    private const float PERCENTAGE = 0.8f;

    private const int MAX_STARTS = 12;
    private const float MAX_TIME = 120;
        
    public override void Init()
    {
        base.Init();
        _view = GetComponentInChildren<ClasificaView>();
       ObjectManager.Instance.HandleObjects(false);
       _view.SetTimer("00", "00", "00");
       _view.SetName("");
    }

    public override void OnStart()
    {
        base.OnStart();
        ToolBox.SetSceneTransforms(_dropZoneDispositivos, _mainCamera, _zOffset, factor);
        ToolBox.SetSceneTransforms(_dropZoneSeguridad, _mainCamera, _zOffset, factor);
        ToolBox.SetSceneTransforms(_dropZonePapeleria, _mainCamera, _zOffset, factor);

        _dispositivosCounter = 0;
        _seguridadCounter = 0;
        _papeleriaCounter = 0;
        
        _currentIndex = 0;
        ObjectManager.Instance.MixObjects();
        ActiveCurrentObject();
        SetFillers();
        _currentTime = 0;
        _isTimer = true;
    }

    private void ActiveCurrentObject()
    {
        if (_currentIndex < ObjectManager.Instance.GetObjsCount())
        {
            Item curretnItem = ObjectManager.Instance.GetItem(_currentIndex);
            _view.SetName(curretnItem.name);
            curretnItem.InitItem(ToolBox.SetItemPosition(_spawnPoint, _mainCamera, _zOffset), _mainCamera, this);
            curretnItem.gameObject.SetActive(true);
            _currentIndex++;
        }
        else
        {
            _isTimer = false;
            SetResult();
        }
    }

    private void Update()
    {
        if (_isTimer)
        {
            _currentTime += Time.deltaTime;
            TimeSpan timer = TimeSpan.FromSeconds(_currentTime);
            _view.SetTimer(timer.Hours.ToString("D2"), timer.Minutes.ToString("D2"), timer.Seconds.ToString("D2") );
        }
        
        if(!test) return;
        
        ToolBox.SetSceneTransforms(_dropZoneDispositivos, _mainCamera, _zOffset, factor);
        ToolBox.SetSceneTransforms(_dropZoneSeguridad, _mainCamera, _zOffset, factor);
        ToolBox.SetSceneTransforms(_dropZonePapeleria, _mainCamera, _zOffset, factor);
    }

    public void ReportDropResult(Item item, bool isMatch, Category dropZoneCategory)
    {
        if (isMatch)
        {
            switch (dropZoneCategory)
            {
                case Category.Dispositivos:
                    _dispositivosCounter++;
                    break;
                case Category.Seguridad:
                    _seguridadCounter++;
                    break;
                case Category.Papeleria:
                    _papeleriaCounter++;
                    break;
            }
        }
        SetFillers();
        ActiveCurrentObject();
    }

    private void SetFillers()
    {
        _view.SetFillers(_dispositivosCounter / DISPOSITIVOS_MAX, _seguridadCounter / SEGURIDAD_MAX, _papeleriaCounter / PAPELERIA_MAX);
    }

    private void SetResult()
    {
        float total = _dispositivosCounter + _seguridadCounter + _papeleriaCounter;
        float totalEvaluate = (float)total * PERCENTAGE;

        if (totalEvaluate >= MAX_STARTS && _currentTime <= MAX_TIME)
        {
            RetroalimentationController.SelectedRetro = 2;
        }
        else if(totalEvaluate >= MAX_STARTS && _currentTime > MAX_TIME)
        {
            RetroalimentationController.SelectedRetro = 1;
        }
        else
        {
            RetroalimentationController.SelectedRetro = 0;
        }

        BaseSceneController.Instance.ChangeState(UIState.Retroalimentation);
    }
}