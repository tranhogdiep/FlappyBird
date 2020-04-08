using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBase : MonoSingleton<SoundBase> {

    public AudioSource audioMusic;
    public AudioSource audioSound;
    public AudioSource audioSoundLoop;
    [System.Serializable]
    public class AudioModel
    {
        public string key;
        public AudioClip audioClip;
    }
    public List<AudioModel> audios;
    private Dictionary<string, AudioModel> models;
    protected object data;
    public void Awake()
    {
        if (true)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
        this.models = new Dictionary<string, AudioModel>();
        foreach (AudioModel model in this.audios)
        {
            if (!this.models.ContainsKey(model.key))
            {
                this.models.Add(model.key, model);
            }
        }
        this.OnLoadSound(SoundManager.Instance.data);
    }
    public virtual void OnLoadSound(object data = null)
    {
        this.data = data;
        SoundManager.Instance.sound = this;
        SoundManager.Instance.AddSettingMusic(OnPlayMusic);
        SoundManager.Instance.AddSettingSound(OnPlaySound);
    }
    public virtual void OnPlayMusic(bool isMute)
    {
        if (PlayerPrefs.HasKey("isMusic"))
        {
            if (PlayerPrefs.GetInt("isMusic") == 1)
                isMute = false;
            else
                isMute = true;
        }
        else
        {
            PlayerPrefs.SetInt("isMusic", 1);
            isMute = false;
        }
        this.audioMusic.mute = isMute;
        if (isMute == false)
        {
            AudioModel model = this.getAudioModelByKey("BG");

            if (model != null)
            {
                this.audioMusic.clip = model.audioClip;
                this.audioMusic.Play();
                this.audioMusic.loop = true;
            }
        }
    }
    public virtual void OnPlaySound(bool isMute)
    {
        if (PlayerPrefs.HasKey("isSound"))
        {
            if (PlayerPrefs.GetInt("isSound") == 1)
                isMute = false;
            else
                isMute = true;
        }
        else
        {
            PlayerPrefs.SetInt("isSound", 1);
            isMute = false;
        }
        if (this.audioSound != null)
            this.audioSound.mute = isMute;
    }
    public virtual void PlayOnShot(string key)
    {
        AudioModel model = this.getAudioModelByKey(key);
        if (model != null)
        {
            this.audioSound.PlayOneShot(model.audioClip);
        }
    }
    public virtual void PlayOnLoop(string key)
    {
        AudioModel model = this.getAudioModelByKey(key);
        if (model != null)
        {
            this.audioSoundLoop.clip  = model.audioClip;
            this.audioSoundLoop.Play();
        }
    }
    public virtual void StopOnLoop()
    {
        this.audioSoundLoop.Stop();
    }
    public virtual AudioModel getAudioModelByKey(string key)
    {
        if (this.models.Count == 0)
        {
            return null;
        }
        if (this.models.ContainsKey(key))
        {
            return this.models[key];
        }
        return null;
    }
}
