using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance;
   [SerializeField] private AudioSource _audioSource;

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
   }

   public void PlayAudio(AudioClip audioClip)
   {
      if (_audioSource.isPlaying)
      {
         _audioSource.Stop();
      }

      _audioSource.PlayOneShot(audioClip);
   }
}
