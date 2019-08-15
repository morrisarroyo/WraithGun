
using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;

  
[CreateAssetMenu(fileName = "New Sound", menuName = "Sound")]
public class Sound : ScriptableObject
{
    public AudioClip soundClip;
    [Range(0f,1f)]
    public float volume = 1f;
    [Range(.1f,3f)]
    public float pitch = 1f;
    public bool loop;
}

[Serializable]
public class CharacterSounds
{
    public Sound death;
    public Sound idle;
    public Sound walk;
    public Sound attack;
}