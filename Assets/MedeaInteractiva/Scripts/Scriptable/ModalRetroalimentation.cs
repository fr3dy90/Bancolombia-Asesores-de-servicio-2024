using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ModalRetroalimentation", menuName = "Medea Interactiva/ModalRetroalimentation")]
public class ModalRetroalimentation : ScriptableObject
{
    public RetroalimentationContent[] modalContent;
    public Sprite iconMoment;
    public Vector2 iconMomentSize;
}

[Serializable]
public class RetroalimentationContent
{
    public UIType actualUIType;
    public bool isGood;
    [TextArea(3,3)] public string titleText;
    [TextArea(3,3)] public string retroalimentationText;
    public Action onAction;
    public AudioClip audioClip;
    public float audioFade;
    public float _timeInScreen;
    
}