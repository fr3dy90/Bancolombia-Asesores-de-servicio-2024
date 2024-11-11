using UnityEngine;

public abstract class Interaction: BaseController
{
    [SerializeField] protected Camera _mainCamera;
    [SerializeField] protected StrDropZone _dropZoneOpt_A;
    [SerializeField] protected StrDropZone _dropZoneOpt_B;
    [SerializeField] protected StrDropZone _dropZoneOpt_C;
    [SerializeField] protected RectTransform[] _spawnPoint;

    public bool isClasifica = false;
    [Range(.5f, 5f)] public float _zOffset = 5f;
    [Range(100f, 2000)] public float factor;
    public bool test;

    public override void Init()
    {
        base.Init();
    }
    
    public override void OnStart()
    {
        base.OnStart();
        SetColliders();
    }
    
    protected virtual void SetColliders()
    {
        ToolBox.SetSceneTransforms(_dropZoneOpt_A, _mainCamera, _zOffset, factor, isClasifica);
        ToolBox.SetSceneTransforms(_dropZoneOpt_B, _mainCamera, _zOffset, factor, isClasifica);
        ToolBox.SetSceneTransforms(_dropZoneOpt_C, _mainCamera, _zOffset, factor, isClasifica);
        
        _dropZoneOpt_A.dropZoneCollider.GetComponent<DropZone>()._itemTarget =
            ToolBox.SetItemPosition(_dropZoneOpt_A.targetItem, _mainCamera, _zOffset);
        _dropZoneOpt_B.dropZoneCollider.GetComponent<DropZone>()._itemTarget =
            ToolBox.SetItemPosition(_dropZoneOpt_B.targetItem, _mainCamera, _zOffset);
        _dropZoneOpt_C.dropZoneCollider.GetComponent<DropZone>()._itemTarget =
            ToolBox.SetItemPosition(_dropZoneOpt_C.targetItem, _mainCamera, _zOffset);
    }

    protected void EnableColliders()
    {
        _dropZoneOpt_A.dropZoneCollider.enabled = true;
        _dropZoneOpt_B.dropZoneCollider.enabled = true;
        _dropZoneOpt_C.dropZoneCollider.enabled = true;
    }
    
    public abstract void ReportDropResult(Item item, DropZone dropZoneCategory);
}
