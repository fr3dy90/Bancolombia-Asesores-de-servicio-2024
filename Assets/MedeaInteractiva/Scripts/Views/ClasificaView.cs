using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClasificaView: BaseView
{
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _hours;
    [SerializeField] private TextMeshProUGUI _minutes;
    [SerializeField] private TextMeshProUGUI _seconds;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private Image _dispositivosFill;
    [SerializeField] private Image _seguridadFill;
    [SerializeField] private Image _papeleriaFill;

    public void SetName(string name)
    {
        _itemName.text = name;
    }

    public void SetTimer(string h, string m, string s)
    {
        _hours.text = h;
        _minutes.text = m;
        _seconds.text = s;
    }

    public void SetFillers(float dispositivosFill, float seguridadFill, float papeleriaFill)
    {
        _dispositivosFill.fillAmount = dispositivosFill;
        _seguridadFill.fillAmount = seguridadFill;
        _papeleriaFill.fillAmount = papeleriaFill;
    }

    public void SetScore(int score)
    {
        _score.text = $"x: {score}";
    }
}
