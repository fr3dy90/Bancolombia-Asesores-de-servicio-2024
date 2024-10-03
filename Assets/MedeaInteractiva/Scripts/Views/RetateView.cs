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
    [SerializeField] private Image _checkmark;
    [SerializeField] private Image _crossbar;

    private const string QUESTION = "Pregunta";
    
    public void SetUI(Question question, int index)
    {
        _textQuestionNumber.text = $"{QUESTION} {index+1}";
        _textQuestion.text = question.question;
        
        _checkmark.gameObject.SetActive(false);
        _crossbar.gameObject.SetActive(false);
            
            
        for (int i = 0; i < question.answers.Length; i++)
        {
           _answers[i].containerUI.color = !question.answered ||  !question.answers[i].isCorrectAnswer && !question.answers[i].userChoise? 
               ColorManager.Instance.colorLibrary.NormalColor 
               : question.answers[i].isCorrectAnswer ? 
                   ColorManager.Instance.colorLibrary.itemInfo_ViewColor:
                    ColorManager.Instance.colorLibrary.incorrectColor;
           _answers[i].textAnswer.text = question.answers[i].answer;
           if (question.answers[i].userChoise)
           {
                _checkmark.gameObject.SetActive(question.answers[i].isCorrectAnswer);
                _checkmark.rectTransform.localPosition = new Vector2(_checkmark.rectTransform.localPosition.x,
                    _answers[i].containerUI.rectTransform.localPosition.y);
                
                _crossbar.gameObject.SetActive(!question.answers[i].isCorrectAnswer);
                _crossbar.rectTransform.localPosition = new Vector2(_crossbar.rectTransform.localPosition.x,
                    _answers[i].containerUI.rectTransform.localPosition.y);
           }
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