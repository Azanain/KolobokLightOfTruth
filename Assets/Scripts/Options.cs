using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;

    [Header("Music")]
    [SerializeField] private Text volumeMusicText;
    private bool musicVolumeEnabled;
    private float volumeValueMusic;//от 0 до -80
    private byte numberVolumeMusic;

    [Header("Effects")]
    [SerializeField] private Text volumeEffextsText;
    private bool effectsVolumeEnabled;
    private float volumeValueEffects;//от 0 до -80
    private byte numberVolumeEffects;

    [Header("UI")]
    [SerializeField] private AudioSource clickButton;
    private bool uIVolumeEnabled;

    private void Start()
    {
        //заменить на загрузку данных
        musicVolumeEnabled = true;
        effectsVolumeEnabled = true;
        uIVolumeEnabled = true;

        numberVolumeMusic = 10;
        numberVolumeEffects = 10;
        UpdateTextVolumeMusic();
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
    private void UpdateTextVolumeMusic()
    {
        volumeMusicText.text = numberVolumeMusic.ToString();
        volumeEffextsText.text = numberVolumeEffects.ToString();
    }
    public void MinusVolumeMusic()
    {
        if (numberVolumeMusic >= 1)
        {
            mixer.audioMixer.SetFloat("MusicVolume", volumeValueMusic);
            volumeValueMusic -= 8;
            numberVolumeMusic--;
            UpdateTextVolumeMusic();
        }
    }
    public void PlusVolumeMusic()
    {
        if (volumeValueMusic <= 9)
        {
            mixer.audioMixer.SetFloat("MusicVolume", volumeValueMusic);
            volumeValueMusic += 8;
            numberVolumeMusic++;
            UpdateTextVolumeMusic();
        }
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
    public void PlusVolumeEffects()
    {
        if (volumeValueEffects <= 9)
        {
            mixer.audioMixer.SetFloat("EffectsVolume", volumeValueEffects);
            volumeValueEffects += 8;
            numberVolumeEffects++;
            UpdateTextVolumeMusic();
        }
    }
    public void MinusEffects()
    {
        if (volumeValueEffects >= 1)
        {
            mixer.audioMixer.SetFloat("EffectsVolume", volumeValueEffects);
            volumeValueEffects -= 8;
            numberVolumeEffects--;
            UpdateTextVolumeMusic();
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
