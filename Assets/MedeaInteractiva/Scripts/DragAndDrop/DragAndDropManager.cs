using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private Item _currentItem;
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
            _currentItem.transform.position = MouseWorldPosition(_currentItem.transform);
        }
    }

    Vector3 MouseWorldPosition(Transform target)
    {
        return _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            _cam.WorldToScreenPoint(target.transform.position).z));
    }
}