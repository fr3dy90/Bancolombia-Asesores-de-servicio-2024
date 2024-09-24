using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ModalWindowIntro", menuName = "Medea Interactiva/ModalWindowIntro")]
public class ModalWindowIntro : ScriptableObject
{
    public Sprite modalSprite;
    public Vector2 modalSpriteSize;
    public ModalContent[] modalContent;
}

[Serializable]
public class ModalContent
{
    public UIType requiredType;
    public ShowInfo showInfo;
    [TextArea(3, 3)] public string text;
    public float timeInScreen;
    public AudioClip audio;
    public float audioFade;
    public Action buttonAction;
    public int imageIndex;
}


