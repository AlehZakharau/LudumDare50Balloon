using UnityEngine;

namespace Code
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        public void PlayClip(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }
    }
}