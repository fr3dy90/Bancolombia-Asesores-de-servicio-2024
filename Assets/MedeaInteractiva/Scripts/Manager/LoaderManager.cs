using System;
using UnityEngine;
using UnityEngine.UI;

public class LoaderManager: MonoBehaviour
{
    [SerializeField] public Image _imgLoader;
    [SerializeField] public float _fillDuration;
    [SerializeField] public float _elapsedTime = 0;
    [SerializeField] public bool _isFilling = false;
    [SerializeField] private DropZone lastDrop;
    public static Action<DropZone> onDroppedObj;
    
    private void Update()
    {
        if (!_isFilling)
        {
            _elapsedTime = 0;
            _imgLoader.fillAmount = 0;
            lastDrop = null;
            return;
        }
            
        
        if (_isFilling)
        {
            _imgLoader.fillAmount = _elapsedTime / _fillDuration;
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _fillDuration)
            {
                _isFilling = false;
                _elapsedTime = 0;
                onDroppedObj?.Invoke(lastDrop);
                lastDrop = null;
            }
        }
    }

    public void GetDropZone(DropZone dz)
    {
        lastDrop = dz;
    }
}
