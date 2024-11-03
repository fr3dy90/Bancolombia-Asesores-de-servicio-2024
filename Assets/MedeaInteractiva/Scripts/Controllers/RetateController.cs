using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class RetateController : BaseController
{
    [SerializeField] private RetateView _view;
    [SerializeField] private ModalQuestions _scriptableQuestions;
    [SerializeField] private ModalQuestions _runtimeQuestions;
    
    [SerializeField] private int _currentIndex;
    [SerializeField] private int _goodAnswers = 0;
    

    public override void Init()
    {
        base.Init();
        _view = GetComponentInChildren<RetateView>();
        _runtimeQuestions = Instantiate(_scriptableQuestions);
        SetButtonsAnswers();
        _view.GetNextButton().onClick.AddListener(() =>
        {
            _currentIndex++;
            SetQuestion(_currentIndex);
        });
        _view.GetBackButton().onClick.AddListener(() =>
        {
            _currentIndex--;
            SetQuestion(_currentIndex);
        });
    }

    public override void OnStart()
    {
        base.OnStart();
        _goodAnswers = 0;
        _currentIndex = 0;
        ClearAnswers();
        OnSetQuestions();
        SetQuestion(_currentIndex);
    }

    private void OnSetQuestions()
    {
        foreach (Question question in _runtimeQuestions.questions)
        {
            Random random = new Random();
            question.answers = question.answers.OrderBy(x => random.Next()).ToArray();
        }

        Random questionRandom = new Random();
        _runtimeQuestions.questions = _runtimeQuestions.questions.OrderBy(x => questionRandom.Next()).ToArray();
    }

    private void SetQuestion(int index)
    {
        if (index < _runtimeQuestions.questions.Length)
        {
            _view.SetUI(_runtimeQuestions.questions[index], index);
            _view.GetNextButton().interactable = _runtimeQuestions.questions[index].answered;
            _view.GetBackButton().gameObject.SetActive(index > 0);
        }
        else
        {
            RetroalimentationController.SelectedRetro = _goodAnswers >= 3 ? 1 : 0;
            RetroalimentationController.ActualUIState = MainMenu.Preparate;
            BaseSceneController.Instance.ChangeState(UIState.Retroalimentation);
        }
    }

    private void SetButtonsAnswers()
    {
        for (int i = 0; i < _view.GetAnswerButtons().Length; i++)
        {
            int i1 = i;
            _view.GetAnswerButtons()[i].onClick.AddListener(() =>
            {
                _runtimeQuestions.questions[_currentIndex].answered = true;
                _runtimeQuestions.questions[_currentIndex].answers[i1].userChoise = true;
                if (_runtimeQuestions.questions[_currentIndex].answers[i1].isCorrectAnswer)
                {
                    _goodAnswers++;
                }
                SetQuestion(_currentIndex);
            });
        }
    }

    private void ClearAnswers()
    {
        foreach (Question actualQuestion in _runtimeQuestions.questions)
        {
            actualQuestion.answered = false;
            foreach (Answer actualAnswer in actualQuestion.answers)
            {
                actualAnswer.userChoise = false;
            }
        }
    }
}