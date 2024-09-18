using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ModalRetroalimentation", menuName = "Medea Interactiva/ModalRetroalimentation")]
public class ModalRetroalimentation : ScriptableObject
{
    public RetroalimentationContent[] modalContent;
}

[Serializable]
public class RetroalimentationContent
{
    public UIType actualUIType;
    public bool isGood;
    public string titleText;
    [TextArea(3,3)] public string retroalimentationText;
    public Action onAction;
    public AudioClip _audioClip;
    public float _timeInScreen;
}