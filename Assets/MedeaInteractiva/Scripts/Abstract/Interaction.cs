using UnityEngine;

public abstract class Interaction: BaseController
{
    [SerializeField] protected Camera _mainCamera;
    [SerializeField] protected StrDropZone _dropZoneOpt_A;
    [SerializeField] protected StrDropZone _dropZoneOpt_B;
    [SerializeField] protected StrDropZone _dropZoneOpt_C;
    [SerializeField] protected RectTransform[] _spawnPoint;
    
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
        ToolBox.SetSceneTransforms(_dropZoneOpt_A, _mainCamera, _zOffset, factor);
        ToolBox.SetSceneTransforms(_dropZoneOpt_B, _mainCamera, _zOffset, factor);
        ToolBox.SetSceneTransforms(_dropZoneOpt_C, _mainCamera, _zOffset, factor);
    }

    protected void EnableColliders()
    {
        _dropZoneOpt_A.dropZoneCollider.enabled = true;
        _dropZoneOpt_B.dropZoneCollider.enabled = true;
        _dropZoneOpt_C.dropZoneCollider.enabled = true;
    }
    
    public abstract void ReportDropResult(Item item, DropZone dropZoneCategory);
}
