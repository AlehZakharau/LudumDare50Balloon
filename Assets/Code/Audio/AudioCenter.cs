using System;
using UnityEngine;

namespace Code
{
    public class AudioCenter : MonoBehaviour
    {
        [SerializeField] private AudioDB audioDB;  
        [Header("Audio Players")]
        [SerializeField] private AudioPlayer sfxPlayer;
        [SerializeField] private AudioPlayer musicPlayer;
        [SerializeField] private AudioPlayer environmentPlayer;
        [SerializeField] private AudioPlayer catSounds;

        public static AudioCenter Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
           // catSounds.PlayClip(audioDB.GetClip(EAudioClips.CatPure));
            environmentPlayer.PlayClip(audioDB.GetClip(EAudioClips.Environment));
            musicPlayer.PlayClip(audioDB.GetClip(EAudioClips.MainTheme));
        }

        public void PlaySound(EAudioClips clipName)
        {
            sfxPlayer.PlayClip(audioDB.GetClip(clipName));
        }
        
        public void PlaySound2(EAudioClips clipName)
        {
            catSounds.PlayClip(audioDB.GetClip(clipName));
        }
    }
}