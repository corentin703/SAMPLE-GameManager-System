﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    private List<AudioClip> m_backgroundSound;
    private List<AudioSource> m_audioSource;

    [SerializeField] private uint MaximumNAudioSource;

    private int m_currentBackgoundSoundIndex = 0;

    private AudioSource m_backgroundAudioSource;

    [SerializeField] private AudioMixer m_audioMixer;

    protected override void Awake()
    {
        base.Awake();
        
        m_dictSong = new Dictionary<string, AudioClip>();
        m_backgroundSound = new List<AudioClip>(BackgoundSound);
        m_audioSource = new List<AudioSource>();

        m_backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        m_backgroundAudioSource.outputAudioMixerGroup = m_audioMixer.FindMatchingGroups("BackgroundGroup")[0];

        foreach (SSong song in Songs)
        {
            m_dictSong.Add(song.Name, song.Song);
        }
    }
    
    void Update()
    {
        if (IsSetUp)
        {
            if (!m_backgroundAudioSource.isPlaying && BackgoundSound.Length != 0)
            {
                m_backgroundAudioSource.clip = BackgoundSound[m_currentBackgoundSoundIndex];

                if (m_currentBackgoundSoundIndex + 1 < BackgoundSound.Length)
                    m_currentBackgoundSoundIndex++;
                else
                    m_currentBackgoundSoundIndex = 0;
            }
        }
    }
    
    public bool IsSetUp { get; private set; } = false;
    public void SetUp(MGR_Song.SSong[] songs, AudioClip[] backgroundSound)
    {
        if (songs == null)
            throw new NullReferenceException("[MGR_Song] in SetUp: SSong[] is null");
        else if (songs.Length > 0)
        {
            m_dictSong = new Dictionary<string, AudioClip>();
        
            foreach (SSong song in Songs)
            {
                m_dictSong.Add(song.Name, song.Song);
            }
        
            foreach (SSong song in songs)
            {
                m_dictSong.Add(song.Name, song.Song);
            }
        }
        
        if (backgroundSound == null)
            throw new NullReferenceException("[MGR_Song] in SetUp: AudioClip[] is null");
        else if (backgroundSound.Length > 0)
        {
            m_backgroundSound = new List<AudioClip>(BackgoundSound);

            foreach (AudioClip song in backgroundSound)
            {
                m_backgroundSound.Add(song);
            }
        }


        IsSetUp = true;
    }
    
    public void NotifySceneChanged()
    {
        IsSetUp = false;
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
                AudioSource newAudioSource;
                GameObject go = new GameObject("AudioSource" + (m_audioSource.Count + 1));
                newAudioSource = go.AddComponent<AudioSource>();
                newAudioSource.clip = m_dictSong[name];
                
                // Assignation du son au groupe "EffectsGroup" de l'AudioMixer
                newAudioSource.outputAudioMixerGroup = m_audioMixer.FindMatchingGroups("EffectsGroup")[0];
                newAudioSource.PlayDelayed(delay);

                m_audioSource.Add(newAudioSource);
            }
            else
                throw new Exception("[MGR_Song] To many AudioSources in use");
        }
        else
            throw new Exception("[MGR_Song] Song reference error");
    }
}
