using Unity.Android.Gradle.Manifest;using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "Medea Interactiva/Item Info")]
public class ItemInfo : ScriptableObject
{
    public Category actualCategory;
    public bool isViewed = false;
    public string itemName;
    [TextArea(3,3)]
    public string itemDescription;
    public Sprite spriteItem;
}

