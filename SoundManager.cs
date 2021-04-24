using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gnome game. Soundmanager
public static class SoundManager 
{
    public enum Sound
    {
        PlayerMove,
        PlayerYay,
        PlayerAuts,
        PlayerJump,
        TrollSound,
        TrollHit,
        TrollMiss,
        Kiira,
        Nakki,
    }

    private static Dictionary<Sound, float> soundTimeDictionary;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;

    public static void Initialize()
    {
        soundTimeDictionary = new Dictionary<Sound, float>();
        soundTimeDictionary[Sound.PlayerMove] = 0f;
    }
    public static void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
        }
    }

    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound)) {
            if(oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("One Shot Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
                oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
            }
            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
            
        }
    }

    private static bool CanPlaySound(Sound sound)
    {

        switch (sound)
        {
            default:
                return true;
                
            case Sound.PlayerMove:
                if (soundTimeDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimeDictionary[sound];
                    float playerMoveTimerMax = .5f;

                    if (lastTimePlayed + playerMoveTimerMax < Time.time)
                    {
                        
                        soundTimeDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                      
                        return false;
                    }

                }
                else
                {
                    Debug.Log("else");
                    return true;
                }
                //break;

        }
    }
    private static AudioClip GetAudioClip(Sound sound)
    {
        
        foreach(GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.SoundAudioClipArray)
        {
            
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }

        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
