using System;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "Audio", menuName = "DataBase/Audio", order = 0)]
    public class AudioDB : ScriptableObject
    {
        [SerializeField] private AudioBase[] audioBases;


        public AudioClip GetClip(EAudioClips name)
        {
            foreach (var audioBase in audioBases)
            {
                if (audioBase.name == name)
                {
                    return audioBase.clip;
                }
            }
            throw new Exception($"doesn't find Clip with name: {name}");
        }
    }

    [Serializable]
    public class AudioBase
    {
        public EAudioClips name;
        public AudioClip clip;
    }

    public enum EAudioClips
    {
        MainTheme,
        Environment,
        CatScare,
        CatMeow,
        CatPure,
        Jump,
        Button,
        Splash,
        Fireworks,
        CatMeow2,
        CatEating
    }
}