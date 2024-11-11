using UnityEngine;
using UnityEditor;

public class ModelSetter : EditorWindow
{
    private Vector3 positionOffset;
    private Vector3 rotationOffset;
    private int gridColums;
    private int gridRows;

    [MenuItem("Tools/Arrange Selected Objects")]
    public static void ShowWindow()
    {
        GetWindow<ModelSetter>("Arrange Objects");
    }

    private void OnGUI()
    {
        GUILayout.Label("Arrange Selected Objects", EditorStyles.boldLabel);

        positionOffset = EditorGUILayout.Vector3Field("Position Offset", positionOffset);
        rotationOffset = EditorGUILayout.Vector3Field("Rotation", rotationOffset);
        gridColums = EditorGUILayout.IntField("GridColums (X)", gridColums);
        gridRows = EditorGUILayout.IntField("Grid Rows (Z)", gridRows);

        if (GUILayout.Button("Arrange Objects"))
        {
            ArrangeObjects();
        }
    }

    private void ArrangeObjects()
    {
        GameObject[] selectedObjects = Selection.gameObjects;
        if (selectedObjects.Length == 0)
        {
            Debug.LogWarning("No objects selected!");
            return;
        }

        Vector3 initialPosition = new Vector3(0, positionOffset.y, 0);

        for (int i = 0; i < selectedObjects.Length; i++)
        {
            GameObject obj = selectedObjects[i];
            int row = i / gridRows;
            int colum = i % gridColums;

            Vector3 newPosition = initialPosition + new Vector3(colum * positionOffset.x, positionOffset.y, positionOffset.z * row);
            obj.transform.rotation = Quaternion.Euler(rotationOffset);
            obj.transform.position = newPosition;
        }
        
        Debug.Log("Objects have been successfully arranged!!");
    }
}
