using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Item : MonoBehaviour
{
    [SerializeField] public ItemInfo _info;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] public Interaction _controller;
    [SerializeField] public DragAndDropManager _dragAndDropManager;
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private LayerMask _colLayerMask;
    [SerializeField] private float _rotationSpeed;
    public Option _currentOprion { private set; get;}


    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
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
        Vector3 worldCenter = _sphereCollider.transform.TransformPoint(_sphereCollider.center);
        float worldRadius = _sphereCollider.radius * Mathf.Max(_sphereCollider.transform.lossyScale.x,
            _sphereCollider.transform.lossyScale.y, _sphereCollider.transform.lossyScale.z);
        Collider[] colliders = Physics.OverlapSphere(worldCenter, worldRadius, _colLayerMask); 
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

    private void Update()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
    }

    void OnDrawGizmos()
    {
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            Gizmos.color = Color.red;

            Vector3 worldCenter = sphereCollider.transform.TransformPoint(sphereCollider.center);
            float worldRadius = sphereCollider.radius * Mathf.Max(
                sphereCollider.transform.lossyScale.x,
                sphereCollider.transform.lossyScale.y,
                sphereCollider.transform.lossyScale.z
            );

            Gizmos.DrawWireSphere(worldCenter, worldRadius);
        }
    }
}
