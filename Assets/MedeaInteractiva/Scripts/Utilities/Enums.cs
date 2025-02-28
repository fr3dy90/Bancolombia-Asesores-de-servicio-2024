using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    None,
    Avatar,
    Cinematic,
    Welcome,
    Menu,
    ModalIntro,
    CountDown,
    Retroalimentation,
    Conoce,
    Clasifica,
    Conecta,
    Retate,
    Info
}

public enum MainMenu
{
    Conoce,
    Clasifica,
    Conecta,
    Preparate
}

public enum UIType
{
    Standard,
    Images
}

public enum ShowInfo
{
    None,
    Intro,
    Instructions
}

public enum Category
{
    Dispositivos,
    Seguridad,
    Papeleria
}

public enum Option
{
    OptionA,
    OptionB,
    OptionC
}

public enum AvatarMoment
{
    Intro,
    Retate,
    Exit
}

public enum SetInfoText
{
    Start,
    End
}

[Serializable]
public struct StrDropZone
{
    public RectTransform targetItem;
    public RectTransform dropZoneUI;
    public Collider dropZoneCollider;
}

[Serializable]
public struct AnswerUI
{
    public TextMeshProUGUI textAnswer;
    public Image containerUI;
}