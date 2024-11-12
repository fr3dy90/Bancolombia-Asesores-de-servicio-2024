using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance;
   [SerializeField] private AudioSource _audioSource;
   [SerializeField] private AudioSource _music;
   [SerializeField] private AudioSource _SFX;

   [SerializeField] private Button _audioButton;
   [SerializeField] private Image _imgBtn;
   [SerializeField] private Sprite _on;
   [SerializeField] private Sprite _off;
   private bool isOn = true;

   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
      _audioButton.onClick.AddListener(SoundButton);
   }

   public void PlayAudio(AudioClip audioClip)
   {
      if (_audioSource.isPlaying)
      {
         _audioSource.Stop();
      }

      _audioSource.PlayOneShot(audioClip);
   }

   private void SoundButton()
   {
      isOn = !isOn;
      _imgBtn.sprite = isOn ? _on : _off;
      _imgBtn.SetNativeSize();
      _imgBtn.rectTransform.sizeDelta *= 0.2f;
      _music.volume = isOn ? 1 : 0;
      _SFX.volume = isOn ? 1 : 0;
   }
}
