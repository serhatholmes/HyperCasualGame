﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound  
{
    public string name;

    public enum AudioTypes { SoundFX, Music }
    public AudioTypes audioType;


    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;


    public bool loop = true;

    [HideInInspector]
    public AudioSource source;
}