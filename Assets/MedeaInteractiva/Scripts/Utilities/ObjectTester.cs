using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectTester: MonoBehaviour
{
    [SerializeField, InspectorButton("SetItem")] private string TestItem = "TestItem";
    //[SerializeField, InspectorButton("SetColliders")] private string SetItemList = "SetItemList";
    
    public Camera cam;
    public RectTransform spawnPoint;
    public int itemIndex;
    public float zOffset;
    public List<GameObject> objects;
    private const string SUFIX = "Model_3D_";

    private void SetItem()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(i == itemIndex);
        }
        objects[itemIndex].transform.position = ToolBox.SetItemPosition(spawnPoint, cam, zOffset);
        objects[itemIndex].transform.rotation = Quaternion.Euler(0,270,0);
    }

    private void SetColliders()
    {
        foreach (GameObject obj in objects)
        {
            GameObject go = new GameObject(CapitalizeFirstLetter(obj.name));
            obj.name = NameSetter(obj.name);
            go.transform.position = obj.transform.position;
            go.transform.parent = obj.transform.parent;
            obj.transform.parent = go.transform;
            obj.transform.localPosition = Vector3.zero;
            go.AddComponent<Item>();
            
            Item goItem = go.GetComponent<Item>();
            Item objItem = obj.GetComponent<Item>();

            goItem._info = objItem._info;
            goItem._dragAndDropManager = objItem._dragAndDropManager;
            
            SphereCollider goSc = go.GetComponent<SphereCollider>();
            goSc.radius = .11f;
        }
    }

    private string CapitalizeFirstLetter(string input)
    {
        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }

    private string NameSetter(string input)
    {
        return $"{SUFIX}{input.Substring(0).ToLower()}";
    }
}
