using System;
using System.IO;
using UnityEngine;

public class TakeRender : MonoBehaviour
{
    [SerializeField] private GameObject _objectToRender;
    [SerializeField] private Camera _cam;
    [SerializeField] private int _widt;
    [SerializeField] private int _height;

    [SerializeField] private string _fileName;
    [SerializeField] private string _folderPath;
    
    
    private void Start()
    {
        ObjectRenderer render = new ObjectRenderer(_objectToRender, _cam, _widt, _height);

        string filepath = Path.Combine(_folderPath, _fileName);
        render.SaveImage(filepath);
    }
}
