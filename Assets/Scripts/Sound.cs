/*
 * Program Header: Sound
 * Robert Wymer - 101070567
 * Last Date Modified - Dec 11, 2021
 * Version 1.0
 * 
 * Class to represent an Audio Clip, Instances of sound class are played by the AudioManager
 *
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 1f)]
    public float pitch;

    public bool loop;


    [HideInInspector]
    public AudioSource source;
}


