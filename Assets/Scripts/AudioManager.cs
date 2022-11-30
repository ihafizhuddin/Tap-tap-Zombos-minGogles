using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioData{
    public string name;
    public AudioClip audio;
}

public class AudioManager : MonoBehaviour{
    public static AudioManager ins;
    [Header("AudioSource")]
    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;

    [Header("Audio List")]
    public List<AudioData> sfxList;
    public List<AudioData> bgmList;

    void Awake(){
        if(ins == null){
            ins = this;
        }
        if(ins != null && ins != this){
            Destroy(this.gameObject);
        }
    }
    void Start(){
        DontDestroyOnLoad(this);
        AudioManager.ins.playBgm("bgm");

    }

    public void playSFX(string name){
        AudioData audioToUse = sfxList.Find(x => x.name == name);
        if(audioToUse == null){
            Debug.Log("audio " + name + "is not found");
            return;
        }
        sfxAudioSource.clip = audioToUse.audio;
        sfxAudioSource.PlayOneShot( audioToUse.audio);
    }
    public void playBgm(string name){
        AudioData audioToUse = bgmList.Find(x => x.name == name);
        if(audioToUse == null){
            Debug.Log("audio " + name + "is not found");
            return;
        }
        bgmAudioSource.clip = audioToUse.audio;
        bgmAudioSource.Play();
    }

}
