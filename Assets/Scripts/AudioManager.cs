﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Dictionary<string, AudioSource> sounds;
    [SerializeField] private PlayerCharacter character;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        sounds = new Dictionary<string, AudioSource>();
        LoadPlayerCharacterSounds();
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadPlayerCharacterSounds()
    {
        //Debug.Log("LoadPlayerCharacterSounds " + character.sounds.GetType().GetProperties().Length);

        var fieldInfos = character.sounds.GetType().GetFields();
        foreach (FieldInfo fInfo in fieldInfos)
        {
            string propertyName = fInfo.Name; //gets the name of the property
            //Debug.Log("LoadPlayerCharacterSounds " + propertyName);
            Sound sound = (Sound) fInfo.GetValue(character.sounds);
            //Debug.Log("LoadPlayerCharacterSounds " + fInfo.GetValue(character.sounds));

            AddAudioSourceComponent(sound);
        }
    }


    private void AddAudioSourceComponent(Sound sound)
    {
        
        //Debug.Log(sound);
        if (sound == null)
        {
            //Debug.Log("AudioManager.LoadPlayerCharacterSounds - Failed");
            return;
        }
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = sound.soundClip;
        source.volume = sound.volume;
        source.pitch = sound.pitch;
        source.loop = sound.loop;
        sounds.Add(sound.name, source);
    }
    
    
    public void Play(string soundName)
    {
        bool success = sounds.TryGetValue(soundName, out AudioSource sound);
        Debug.Log(sounds.Keys.First());
        if (!success)
            return;
        sound.Play();
    }
}