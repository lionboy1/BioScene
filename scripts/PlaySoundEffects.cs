using UnityEngine;

namespace Bioscene
{
    [System.Serializable]
    public class PlaySoundEffects : MonoBehaviour, IAudioHandler
    {
        [SerializeField] AudioSource source;
        [SerializeField] AudioClip explosionClip;
        [SerializeField] AudioClip laughingClip;
     
        public void PlayLaughingClipOneShot()
        {
            source.PlayOneShot(laughingClip, 0.3f);
        }
        public void PlayExplosionSound()
        {
            source.PlayOneShot(explosionClip, 0.5f);
        }
    }
}