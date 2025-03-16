using UnityEngine;

public class volumesetting2
{
    void Start(){
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        float savedSfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1.0f);
    }
}
