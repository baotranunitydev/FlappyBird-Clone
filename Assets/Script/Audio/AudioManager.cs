using System;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    public Sound soundBackround;
    public Sound[] soundsEffect;
    protected override void Awake()
    {
        foreach (Sound effect in soundsEffect)
        {
            effect.source = gameObject.AddComponent<AudioSource>();
            effect.source.clip = effect.clip;
            effect.source.loop = effect.loop;
        }
        soundBackround.source = gameObject.AddComponent<AudioSource>();
        soundBackround.source.clip = soundBackround.clip;
        soundBackround.source.loop = soundBackround.loop;
    }

    public void PlaySoundEffect(string soundName)
    {
        Sound effect = Array.Find(soundsEffect, item => item.name == soundName);
        if (effect == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
        }
        effect.source.volume = effect.volume;
        effect.source.Play();
    }

    public void PlaySoundBackround()
    {
        soundBackround.source.volume = soundBackround.volume;
        soundBackround.source.Play();
    }
}
