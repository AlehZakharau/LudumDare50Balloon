using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Code
{
    [CreateAssetMenu(fileName = "Audio", menuName = "DataBase/Audio", order = 0)]
    public class AudioDB : ScriptableObject
    {
        [SerializeField] private AudioBase[] audioBases;
        [SerializeField] private AudioPlaylist[] audioPlaylists;
        [SerializeField] private AudioData audioData;

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
        
        public AudioClip[] GetPlaylist(EAudioPlaylist name)
        {
            foreach (var audioPlaylist in audioPlaylists)
            {
                if (audioPlaylist.name == name)
                {
                    return audioPlaylist.clips;
                }
            }
            throw new Exception($"doesn't find Clip with name: {name}");
        }
        
        public AudioMixerGroup GetMixerGroup(EAudioMixerGroupNames name)
        {
            foreach (var group in audioData.groups)
            {
                if (group.name == name.ToString())
                {
                    return group;
                }
            }
            throw new Exception($"There is no such Audio Mixer group {name}");
        }

    }

    [Serializable]
    public class AudioBase
    {
        public EAudioClips name;
        public AudioClip clip;
    }

    [Serializable]
    public class AudioPlaylist
    {
        public EAudioPlaylist name;
        public AudioClip[] clips;
    }
    
    [Serializable]
    public class AudioData
    {
        public AudioMixerGroup[] groups;
    }

    public enum EAudioPlaylist
    {
        Music,
        Environment
    }

    public enum EAudioClips
    {
        MainTheme,
        Environment,
        Wind,
        Button,
        Landing,
        Crash,
        Upgrade,
        AddBurst,
        NormalBurst,
        LowBurst
       
    }
}