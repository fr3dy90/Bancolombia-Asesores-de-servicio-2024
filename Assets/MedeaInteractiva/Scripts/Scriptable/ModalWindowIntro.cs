using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ModalWindowIntro", menuName = "Scriptable Objects/ModalWindowIntro")]
public class ModalWindowIntro : ScriptableObject
{
    public Sprite modalSprite;
    public ModalContent[] modalContent;
}

[Serializable]
public class ModalContent
{
    [TextArea(3, 3)] public string text;
    public float timeInScreen;
    public AudioClip audio;
    public Action buttonAction;
}
