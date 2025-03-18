using Scorm;
using UnityEngine;

public class ScormManager : MonoBehaviour
{
    private static ScormManager _instance;
    public static ScormManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<ScormManager>();

                if (_instance == null)
                {
                    GameObject scormManagerObject = new GameObject("ScormManager");
                    _instance = scormManagerObject.AddComponent<ScormManager>();
                }
            }

            return _instance;
        }
    }

    private IScormService _scormService;

    public void Init()
    {
#if UNITY_EDITOR
        _scormService = new ScormPlayerPrefsService();
#else
        _scormService = new ScormService();
#endif

        Initialize();
    }

    private void Initialize()
    {
        Version version = Version.Scorm_1_2;

        bool result = _scormService.Initialize(version);

        if (result)
        {
            //Debug.Log("SCORM Initialized.");

            string lastLocation = _scormService.GetLessonLocation();
            if (!string.IsNullOrEmpty(lastLocation))
            {
                //Debug.Log("Resuming from: " + lastLocation);
            }
        }
    }

    public void SetLessonLocation(string location)
    {
        _scormService.SetLessonLocation(location);
        _scormService.Commit();
    }

    public void SetCompleted()
    {
        if (CheckIsCompleted()) return;
        
        _scormService.SetRawScore(100.0f);
         _scormService.SetLessonStatus(LessonStatus.Passed);
        _scormService.SetLessonStatus(LessonStatus.Completed);
        _scormService.Commit();
    }

    public bool CheckIsCompleted()
    {
        return _scormService.GetLessonStatus() == LessonStatus.Completed;
    }

    public void SetFinish()
    {
        _scormService.Commit();
        _scormService.Finish();
    }

    void OnApplicationQuit()
    {
        SetFinish();
    }

    void OnDestroy()
    {
        SetFinish();
    }
}
