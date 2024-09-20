using System;
using UnityEngine;

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
    Conecta
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

[Serializable]
public struct StrDropZone
{
    public RectTransform dropZoneUI;
    public Collider dropZoneCollider;
}