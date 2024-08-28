using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler: MonoBehaviour
{
    private Vector3 _startPosition;

    public void SetInitialPosition(Vector3 initialPosition)
    {
        _startPosition = initialPosition;
    }
}
