using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager> {

    public SoundBase sound;
    public bool isMusic=true;
    public bool m_isMusic;
    public bool isSound;
    public bool m_isSound;
    public object data;

    private void Start()
    {
        if (PlayerPrefs.GetInt("isMusic") == 1)
            m_isMusic = true;
        else
            m_isMusic = false;
        if (PlayerPrefs.GetInt("isSound") == 1)
            m_isSound = true;
        else
            m_isSound = false;
    }
    public void OnPlaySound(string key)
    {
            if (this.sound == null)
            {
                this.sound = FindObjectOfType<SoundBase>();
            }

            if (this.sound != null)
            {
                this.sound.PlayOnShot(key);
            }
    }
    public void OnPlayLoop(string key)
    {
        if (this.sound == null)
        {
            this.sound = FindObjectOfType<SoundBase>();
        }

        if (this.sound != null)
        {
            this.sound.PlayOnLoop(key);
        }
    }
    public void OnStopSound()
    {
        if (this.sound != null)
        {
            this.sound.StopOnLoop();
        }
    }
    public void OnStopMusic()
    {
        if (this.sound != null)
        {
            this.sound.audioMusic.mute = true;
        }
    }
    public void OnSetMusic(AudioClip clipAudio)
    {
        if (this.sound != null)
        {
            this.sound.audioMusic.clip = clipAudio;
            sound.OnLoadSound();
            sound.OnPlayMusic(false);
        }
    }
    public void OnStartMusic()
    {
        if (this.sound != null)
        {
            this.sound.audioMusic.mute = false;
        }
    }
    public void OnStartSound_D()
    {
        if (this.sound != null)
        {
            this.sound.audioSound.mute = false;
        }
    }
    public void OnStopSound_D()
    {
        if (this.sound != null)
        {
            this.sound.audioSound.mute = true;
        }
    }
    #region Setting
    public delegate void OnSettingAudio(bool isMute);
    public List<OnSettingAudio> callbackMusic;
    public List<OnSettingAudio> callbackSound;
    public void AddSettingMusic(OnSettingAudio callback)
    {
        if (this.callbackMusic == null)
        {
            this.callbackMusic = new List<OnSettingAudio>();
        }
        if (!this.callbackMusic.Contains(callback))
        {
            callback.Invoke(isMusic);
            this.callbackMusic.Add(callback);
        }
    }
    public void AddSettingSound(OnSettingAudio callback)
    {
        if (this.callbackSound == null)
        {
            this.callbackSound = new List<OnSettingAudio>();
        }
        if (!this.callbackSound.Contains(callback))
        {
            callback.Invoke(isMusic);
            this.callbackSound.Add(callback);
        }
    }
    public void OnChangeSettingMusic(bool Music)
    {
        if (Music)
        {
            OnStartMusic();
        }
        else
        {
            OnStopMusic();
        }
        m_isMusic = Music;
        if (m_isMusic)
            PlayerPrefs.SetInt("isMusic", 1);
        else
            PlayerPrefs.SetInt("isMusic", 0);
        //foreach (OnSettingAudio callback in this.callbackMusic)
        //{
        //    if (callback != null)
        //        callback.Invoke(this.isMusic);
        //}
    }
    public void OnChangeSettingSound(bool Sound)
    {
        if (Sound)
        {
            OnStartSound_D();
        }
        else
        {
            OnStopSound_D();
        }
        m_isSound = Sound;
        if (m_isSound)
            PlayerPrefs.SetInt("isSound", 1);
        else
            PlayerPrefs.SetInt("isSound", 0);
    }
    #endregion
}
