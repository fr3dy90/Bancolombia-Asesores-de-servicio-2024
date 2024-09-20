using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Item : MonoBehaviour
{
    [SerializeField] private ItemInfo _info;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Interaction _controller;
    [SerializeField] private DragAndDropManager _dragAndDropManager;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private LayerMask _colLayerMask;
    public Option _currentOprion { private set; get;}


    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    public void InitItem(Vector3 startPosition, Camera camera, Interaction controller)
    {
        _controller = controller;
        _startPosition = startPosition;
        SetStartPosition();
    }
    
    public string GetName()
    {
        return _info.itemName;
    }

    public Category GetCategory()
    {
        return _info.actualCategory;
    }

    public string GetItemInfo()
    {
        if (string.IsNullOrEmpty(_info.itemDescriptionConecta) ||
            string.IsNullOrWhiteSpace(_info.itemDescriptionConecta))
        {
            return _info.itemDescription;
        }
        else
        {
            return _info.itemDescriptionConecta;
        }
    }

    public void SetStartPosition()
    {
        transform.position = _startPosition;
    }

    private void OnMouseDown()
    {
        _dragAndDropManager.DragItem(this);
    }

    private void OnSuccessfullDrop(DropZone dropZoneCategory)
    {
        _controller.ReportDropResult(this, dropZoneCategory);
    }
    
    public void Released()
    {
        Vector3 worldCenter = _boxCollider.transform.TransformPoint(_boxCollider.center);
        Vector3 worldHalfExtends = Vector3.Scale(_boxCollider.size, _boxCollider.transform.lossyScale) / 2;
        Quaternion worldRotation = _boxCollider.transform.rotation;
        Collider[] colliders = Physics.OverlapBox(worldCenter, worldHalfExtends, worldRotation, _colLayerMask);

        foreach (Collider col in colliders)
        {
            if(col.GetComponent<DropZone>() != null)
            {
                OnSuccessfullDrop(col.GetComponent<DropZone>());
                return;
            }
        }
        
        SetStartPosition();
    }

    public void SetOption(Option selectedOption)
    {
        _currentOprion = selectedOption;
    }
}
