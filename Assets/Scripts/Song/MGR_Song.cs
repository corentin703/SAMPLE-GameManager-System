using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGR_Song : Singleton<MGR_Song>
{
    [Serializable]
    public struct SSong
    {
        public string Name;
        public AudioClip Song;
    }

    [SerializeField] private SSong[] Songs;
    [SerializeField] private AudioClip[] BackgoundSound;

    private Dictionary<string, AudioClip> m_dictSong;
    private List<AudioSource> m_audioSource;

    [SerializeField] private uint MaximumNAudioSource; 
    
//    private struct SBackgroundSong
//    {
//        public AudioClip Song;
//        public bool IsPlaying;
//
//        public SBackgroundSong(AudioClip song, bool isPlaying)
//        {
//            Song = song;
//            IsPlaying = isPlaying;
//        }
//    }

    private int m_currentBackgoundSoundIndex = 0;
    
//    private List<SBackgroundSong> m_backgroundSound;

    private AudioSource m_backgroundAudioSource;

    protected override void Awake()
    {
        base.Awake();
        
        m_dictSong = new Dictionary<string, AudioClip>();
//        m_backgroundSound = new List<SBackgroundSong>();
        m_audioSource = new List<AudioSource>();
        m_backgroundAudioSource = new AudioSource();

        foreach (SSong song in Songs)
        {
            m_dictSong.Add(song.Name, song.Song);
        }

//        foreach (AudioClip song in BackgoundSound)
//        {
//            m_backgroundSound.Add(new SBackgroundSong(song, false));
//        }
    }

    void Update()
    {
        if (!m_backgroundAudioSource.isPlaying)
        {
            m_backgroundAudioSource.clip = BackgoundSound[m_currentBackgoundSoundIndex];

            if (m_currentBackgoundSoundIndex + 1 < BackgoundSound.Length)
                m_currentBackgoundSoundIndex++;
            else
                m_currentBackgoundSoundIndex = 0;
        }
    }
    
    public void PlaySound(string name, float delay = 0)
    {
        if (m_dictSong.ContainsKey(name))
        {
            foreach (AudioSource audioSource in m_audioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = m_dictSong[name];
                    audioSource.PlayDelayed(delay);

                    return;
                }
            }

            if (MaximumNAudioSource == 0 || m_audioSource.Count <= MaximumNAudioSource)
            {
                // Création d'un nouveau GO contenant un AudioSource
                GameObject go = new GameObject("AudioSource" + (m_audioSource.Count + 1));
                AudioSource newAudioSource = go.AddComponent<AudioSource>();
                newAudioSource.clip = m_dictSong[name];
                newAudioSource.PlayDelayed(delay);

                m_audioSource.Add(newAudioSource);
            }
            else
                throw new Exception("[MGR_Song] To many AudioSources in use");
//                Debug.LogError("To many AudioSources in use");
        }
        else
            throw new Exception("[MGR_Song] Song reference error");
//            Debug.LogError("Song not found");
    }
}
