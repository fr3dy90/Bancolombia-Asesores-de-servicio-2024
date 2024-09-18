using System;
using MedeaInteractiva.Scripts.Interfaces;
using UnityEngine;

public class Item : MonoBehaviour, IDraggable
{
    [SerializeField] private Camera _cam;
    [SerializeField] private ItemInfo _info;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private ClasificaController _controller;
    private Vector3 offset;
    public bool isDraggin {get; private set; }

    public void InitItem(Vector3 startPosition, Camera camera, ClasificaController controller)
    {
        _controller = controller;
        _cam = camera;
        _startPosition = startPosition;
        transform.position = _startPosition;
    }
    
    public string GetName()
    {
        return _info.itemName;
    }

    public Category GetCategory()
    {
        return _info.actualCategory;
    }

    private void OnMouseDown()
    {
        isDraggin = true;
        Vector3 mouseWorldPosition = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.WorldToScreenPoint(transform.position).z));
        offset = transform.position - mouseWorldPosition;
    }

    private void OnMouseUp()
    {
        isDraggin = false;
        transform.position = _startPosition;
    }


    public void OnStartDrag()
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(bool isSucces)
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        if (isDraggin)
        {
            Vector3 mouseWorldPosition = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.WorldToScreenPoint(transform.position).z));
            transform.position = offset + mouseWorldPosition;
        }
    }

    public void OnSuccessfullDrop(Category dropZoneCategory)
    {
        bool isMatch = _info.actualCategory == dropZoneCategory;
        _controller.ReportDropResult(this, isMatch, dropZoneCategory);
    }
}
