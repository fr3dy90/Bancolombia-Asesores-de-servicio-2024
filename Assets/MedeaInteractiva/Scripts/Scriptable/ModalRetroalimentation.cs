using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ModalRetroalimentation", menuName = "Scriptable Objects/ModalRetroalimentation")]
public class ModalRetroalimentation : ScriptableObject
{
    public RetroalimentationContent[] modalContent;
}

public class RetroalimentationContent
{
    public bool isWhite;
    public bool isGood;
    public string titleText;
    [TextArea(3,3)] public string retroalimentationText;
    public Action onAction;
}