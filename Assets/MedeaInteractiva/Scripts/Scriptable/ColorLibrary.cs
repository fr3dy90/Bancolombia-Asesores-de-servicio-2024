using UnityEngine;

[CreateAssetMenu(fileName = "Color Library", menuName = "Medea Interactiva/Color Library")]
public class ColorLibrary : ScriptableObject
{
    [Header("Modal Intro View")]
    public Color modalIntroView_SelectedColor;
    public Color modalIntroView_UnselectedColor;

    [Header("Item Color")] 
    public Color itemInfo_ViewColor;
    public Color itemInfo_UnviewColor;

    [Header("Answers")] 
    public Color NormalColor;
    public Color correctColor;
    public Color incorrectColor;
}
