using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;
    public static bool isPause { get; private set; } 

    [Header("Music")]
    private bool musicVolumeEnabled;

    [Header("Effects")]
    private bool effectsVolumeEnabled;

    [Header("UI")]
    [SerializeField] private AudioSource clickButton;
    private bool uIVolumeEnabled;

    //private void Awake()
    //{
    //    EventManager.PauseEvent += Pause;
    //}
    private void Start()
    {
        //заменить на загрузку данных
        musicVolumeEnabled = true;
        effectsVolumeEnabled = true;
        uIVolumeEnabled = true;
    }
    public void Pause()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
        else
        {
            Time.timeScale = 0;
            isPause = true;
        }
    }
    public void Hub()
    {
        EventManager.CallCapsuleTeleport();
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
    //private void OnDestroy()
    //{
    //    EventManager.PauseEvent -= Pause;
    //}
}
