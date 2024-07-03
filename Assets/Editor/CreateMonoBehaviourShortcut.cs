using UnityEditor;
using UnityEngine;

public class CreateMonoBehaviourShortcut
{
    [MenuItem("Assets/Create/C# MonoBehaviour Script %&x", priority = 80)]
    private static void CreateNewScript()
    {
        // Path to the folder selected in the Project view
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);

        // If the selected object is not a folder, use the folder containing the object
        if (!AssetDatabase.IsValidFolder(path))
        {
            path = System.IO.Path.GetDirectoryName(path);
        }

        // Default script template content
        string scriptContent = 
            @"using UnityEngine;

public class NewMonoBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}";

        // Create the script file in the selected folder
        string scriptPath = AssetDatabase.GenerateUniqueAssetPath(path + "/NewMonoBehaviour.cs");
        System.IO.File.WriteAllText(scriptPath, scriptContent);

        // Refresh the AssetDatabase to show the new script
        AssetDatabase.Refresh();

        // Optionally, you can select the newly created script in the Project view
        UnityEngine.Object scriptAsset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(scriptPath);
        Selection.activeObject = scriptAsset;
    }

    [MenuItem("Assets/Create/C# MonoBehaviour Script %&x", true)]
    private static bool ValidateCreateNewScript()
    {
        // This menu item will only be enabled if a folder or an asset within a folder is selected
        return Selection.activeObject != null;
    }
}