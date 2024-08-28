using UnityEngine;

public class DropZone : MonoBehaviour
{
    [SerializeField] private string _requiredTag;
    
    public bool IsCorrectDrop(DragHandler currentDragHandler)
    {
        return currentDragHandler.CompareTag(_requiredTag);
    }
}
