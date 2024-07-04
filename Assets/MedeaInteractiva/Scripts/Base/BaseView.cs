
using System;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    public virtual void Initialize()
    {
        if (_canvasGroup != null) return;
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
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
