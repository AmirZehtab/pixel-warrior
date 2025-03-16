using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumesettings : MonoBehaviour
{
    public AudioMixer audio;
    public AudioMixer sfx;
    public Slider music;
    public Slider sfxslider;

    public void Start(){
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        float savedSfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1.0f);
        music.value = savedMusicVolume;
        sfxslider.value = savedSfxVolume;
    }

    public void Update(){
        

        
    }
    public void setmusic(){
        float audiov = music.value;
        audio.SetFloat("music", Mathf.Log10(audiov)*20);

        PlayerPrefs.SetFloat("MusicVolume", audiov);
        PlayerPrefs.Save();

    }

    public void setsfx(){
        float sfxv = sfxslider.value;
        sfx.SetFloat("sfx", Mathf.Log10(sfxv)*20);
        
        PlayerPrefs.SetFloat("SfxVolume", sfxv);
        PlayerPrefs.Save();

    }
}
