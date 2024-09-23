using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ModalQuestions", menuName = "Medea Interactiva/Modal Question")]
public class ModalQuestions : ScriptableObject
{
    public Question[] questions;
}

[Serializable]
public class Question
{
    [TextArea(3,4)]
    public string question;
    public bool answered = false;
    public Answer[] answers;
}

[Serializable]
public class Answer
{
    [TextArea(3, 4)] 
    public string answer;
    public bool isCorrectAnswer = false;
    public bool userChoise = false;
}
