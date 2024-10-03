using UnityEngine;
using System.IO;

public class ObjectRenderer
{
    private Camera _renderCamera;
    private RenderTexture _renderTexture;
    private GameObject _objectRender;

    public Texture2D renderImage { get; private set; }

    public ObjectRenderer(GameObject objectRender, Camera cam, int widt, int height)
    {
        _objectRender = objectRender;
        _renderCamera = cam;
        InitilaizeRenderTexture(widt, height);
        InitializeCmera();
        Render();
    }

    private void InitilaizeRenderTexture(int widt, int height)
    {
        _renderTexture = new RenderTexture(widt, height, 24)
        {
            format = RenderTextureFormat.ARGB32,
            depth = 24,
            antiAliasing = 1
        };
        _renderTexture.Create();
    }
    
    private void InitializeCmera()
    {
        _renderCamera.clearFlags = CameraClearFlags.SolidColor;
        _renderCamera.backgroundColor = new Color(0, 0, 0, 0);
        _renderCamera.targetTexture = _renderTexture;

        int renderLayer = LayerMask.NameToLayer("RenderLayer");
        if (renderLayer == -1)
        {
            Debug.LogError("La capa 'RenderLayer' no existe, debe crearla en el proyuecto");
            return;
        }

        _renderCamera.cullingMask = 1 << renderLayer;

        //_renderCamera.transform.position = _objectRender.transform.position + new Vector3(0, 0, -10);
        //_renderCamera.transform.LookAt(_objectRender.transform);
    }
    
    private void Render()                          
    {
        if (_renderCamera == null)
        {
            Debug.LogError("La camara no se inicializo correctamente");
            return;
        }

        int originalLayer = _objectRender.layer;
        int renderLayer = LayerMask.NameToLayer("RenderLayer");
        _objectRender.layer = renderLayer;
        
        _renderCamera.Render();

        RenderTexture.active = _renderTexture;
        renderImage = new Texture2D(_renderTexture.width, _renderTexture.height, TextureFormat.ARGB32, false);
        renderImage.ReadPixels(new Rect(0,0, _renderTexture.width, _renderTexture.height), 0,0);
        renderImage.Apply();
        RenderTexture.active = null;

        _objectRender.layer = originalLayer;
    }

    public void SetImageSize(int widt, int height)
    {
        _renderTexture.Release();
        _renderTexture.width = widt;
        _renderTexture.height = height;
        _renderTexture.Create();
        Render();
    }

    public void SaveImage(string filePath)
    {
        if (renderImage == null)
        {
            Debug.LogError("No hay imagen renderizada para guardar");
            return;
        }

        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        byte[] bytes = renderImage.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);
        Debug.Log($"Imagen guardada en {filePath}");
    }
}
