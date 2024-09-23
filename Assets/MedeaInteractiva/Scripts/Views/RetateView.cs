using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RetateView: BaseView
{
    [SerializeField] private TextMeshProUGUI _textQuestionNumber;
    [SerializeField] private TextMeshProUGUI _textQuestion;
    [SerializeField] private AnswerUI[] _answers;
    [SerializeField] private Button _btnNext;
    [SerializeField] private Button _btnBack;
    [SerializeField] private Button[] _answerButtons;

    private const string QUESTION = "Pregunta";
    
    public void SetUI(Question question, int index)
    {
        _textQuestionNumber.text = $"{QUESTION} {index+1}";
        _textQuestion.text = question.question;
        for (int i = 0; i < question.answers.Length; i++)
        {
           _answers[i].containerUI.color = !question.answered ||  !question.answers[i].isCorrectAnswer && !question.answers[i].userChoise? 
               ColorManager.Instance.colorLibrary.NormalColor 
               : question.answers[i].isCorrectAnswer ? 
                   ColorManager.Instance.colorLibrary.itemInfo_ViewColor:
                    ColorManager.Instance.colorLibrary.incorrectColor;
           _answers[i].textAnswer.text = question.answers[i].answer;
        }

        foreach (Button btn in _answerButtons)
        {
            btn.enabled = !question.answered;
        }
    }

 

    public Button GetNextButton()
    {
        return _btnNext;
    }

    public Button GetBackButton()
    {
        return _btnBack;
    }

    public Button[] GetAnswerButtons()
    {
        return _answerButtons;
    }
}