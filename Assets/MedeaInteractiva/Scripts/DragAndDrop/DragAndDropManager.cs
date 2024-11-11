using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private Item _currentItem;
    [SerializeField] private LayerMask _layerInteraction;
    public bool isDraggin {get; private set; }

    public void DragItem(Item item)
    {
        _currentItem = item;
        isDraggin = true;
    }
    
    private void ReleaseItem()
    {
        isDraggin = false;
        if (_currentItem != null)
        {
            _currentItem.Released();
            _currentItem = null;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseItem();
        }
        
        if (isDraggin && _currentItem != null)
        {
            /*
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 50f,_layerInteraction))
            {
                if (hit.transform != null)
                {
                    //_currentItem.transform.position = hit.transform.GetComponent<DropZone>()._itemTarget;
                    return;
                }                
            }*/
            
            _currentItem.transform.position = MouseWorldPosition(_currentItem.transform);
        }
    }

    Vector3 MouseWorldPosition(Transform target)
    {
         return _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.WorldToScreenPoint(target.transform.position).z));
    }
}