
using System;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    public void Initialize()
    {
        if (_canvasGroup == null)
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    public CanvasGroup GetCanvasGroup()
    {
        if (_canvasGroup != null)
        {
            return _canvasGroup;
        }
        else
        {
            Debug.LogError("CanvasGroup not found");
            return null;
        }
    }
}
