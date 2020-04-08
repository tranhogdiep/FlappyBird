using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoSingleton<SoundsManager>
{
    public enum SOUNDS {TAB_BOTTON, GET_SCORE };
    [System.Serializable]
    public class AudioModel
    {
        public SOUNDS key;
        public AudioClip audioClip;
    }
    public List<AudioModel> audios;
    private Dictionary<SOUNDS, AudioModel> models;

    public AudioSource backgound_mucsic;
    public AudioSource baseSound;
    private void Start()
    {
        backgound_mucsic.Play();
    }
    public void PlaySound(SOUNDS key)
    {
        //baseSound.clip = sounds[1];
        //baseSound.Play();
        AudioModel model = this.getAudioModelByKey(key);
        if (model != null)
        {
            this.baseSound.PlayOneShot(model.audioClip);
        }
    }
    public void PlayBackgroundSound()
    {
        backgound_mucsic.Play();
    }
    public void MuteBackgroundSound()
    {
        backgound_mucsic.Stop();
    }
    public virtual AudioModel getAudioModelByKey(SOUNDS key)
    {
        foreach(AudioModel model in audios)
        {
            if(model.key==key)
            {
                return model;
            }
        }
        return null;
    }
}
