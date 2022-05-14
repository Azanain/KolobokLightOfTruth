using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;

    [Header("Music")]
    [SerializeField] private Text volumeMusicText;
    private bool musicVolumeEnabled;
    //private float volumeValueMusic;

    [Header("Effects")]
    [SerializeField] private Text volumeEffextsText;
    private bool effectsVolumeEnabled;
    //private float volumeValueEffects;

    [Header("UI")]
    [SerializeField] private AudioSource clickButton;
    private bool uIVolumeEnabled;

    private void Start()
    {
        //заменить на загрузку данных
        musicVolumeEnabled = true;
        effectsVolumeEnabled = true;
        uIVolumeEnabled = true;
    }
    public void ClickAudio()
    {
        clickButton.Play();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ToggleVolumeMusic()
    {
        if (!musicVolumeEnabled)
        {
            mixer.audioMixer.SetFloat("MusicVolume", 0);
            musicVolumeEnabled = true;
        }
        else
        {
            mixer.audioMixer.SetFloat("MusicVolume", -80);
            musicVolumeEnabled = false;
        }
    }

    public void ChangeVolumeMusic(float volume)
    {
        mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }
    public void ChangeVolumeEffects(float volume)
    {
        mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
    }
    public void ToggleVolumeEffects()
    {
        if (!effectsVolumeEnabled)
        { 
            mixer.audioMixer.SetFloat("EffectsVolume", 0);
            effectsVolumeEnabled = true;
        }
        else
        { 
            mixer.audioMixer.SetFloat("EffectsVolume", -80);
            effectsVolumeEnabled = false;
        }
    }
  
    public void ToggleVolumeUI()
    {
        if (!uIVolumeEnabled)
        { 
            mixer.audioMixer.SetFloat("UIVolume", 0);
            uIVolumeEnabled = true;
        }
        else
        { 
            mixer.audioMixer.SetFloat("UIVolume", -80);
            uIVolumeEnabled = false;
        }
    }
}
