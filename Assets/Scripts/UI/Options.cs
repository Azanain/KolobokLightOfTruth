using UnityEngine;
using UnityEngine.Audio;
public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;
    [SerializeField] private AudioSource audioSourceMusicScene;

    [Header("Музыка сцен")]
    [SerializeField] private AudioClip[] audioClips;
    public static bool isPause { get; private set; }

    [Header("Music")]
    private bool musicVolumeEnabled = true;

    [Header("Effects")]
    private bool effectsVolumeEnabled = true;

    [Header("UI Audio")]
    [SerializeField] private AudioSource clickButton;
    private bool uIVolumeEnabled = true;

    private float valueVolumeMusic;
    private float valueVolumeEffects;
    private void Awake()
    {
        EventManager.PauseEvent += Pause;
    }
    private void Start()
    {
        LoadData();
        StartMusicOnCurrentScene();
    }
    private void LoadData()
    {
        valueVolumeMusic = LoadSavedData.ValueVolumeMusic;
        valueVolumeEffects = LoadSavedData.ValueVolumeEffects;
        uIVolumeEnabled = LoadSavedData.UIVolumeEnabled;
        effectsVolumeEnabled = LoadSavedData.EffectsVolumeEnabled;
        musicVolumeEnabled = LoadSavedData.MusicVolumeEnabled;

        ChangeVolumeMusic(valueVolumeMusic);
        ChangeVolumeEffects(valueVolumeEffects);
        ToggleVolumeMusic();
        ToggleVolumeEffects();
        ToggleVolumeUI();
    }
    /// <summary>
    /// запуск музыки на текущей сцене
    /// </summary>
    private void StartMusicOnCurrentScene()
    {
        audioSourceMusicScene.Stop();
        switch (SceneTransition.NumberCurrentScene)
        {
            case 1:
                audioSourceMusicScene.PlayOneShot(audioClips[0]);
                break;
            case 2:
                audioSourceMusicScene.PlayOneShot(audioClips[1]);
                break;
            case 3:
                audioSourceMusicScene.PlayOneShot(audioClips[2]);
                break;
        }
    }
    /// <summary>
    /// при нажатии кнопки запускает игру с хаба
    /// </summary>
    public void StartGame()
    {
        EventManager.LoadGameScene(2);
    }
    /// <summary>
    /// пауза
    /// </summary>
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
    /// <summary>
    /// вызов трубы для перехода в хаб
    /// </summary>
    public void Hub()
    {
        EventManager.SaveData();
        EventManager.CallCapsuleTeleport();
    }
    /// <summary>
    /// проигрывание звука нажатии кнопки
    /// </summary>
    public void ClickAudio()
    {
        clickButton.Play();
    }
    /// <summary>
    /// выход из игры
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// тумблер звука музыки
    /// </summary>
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
    /// <summary>
    ///  слайдер настройки громкости музыки
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeVolumeMusic(float volume)
    {
        mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        valueVolumeMusic = volume;
    }
    /// <summary>
    /// слайдер настройки громкости еффектов
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeVolumeEffects(float volume)
    {
        mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
        valueVolumeEffects = volume;
    }
    /// <summary>
    /// тумблер звука еффектов
    /// </summary>
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
  /// <summary>
  /// тумблер звук UI
  /// </summary>
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
    /// <summary>
    /// сохранение перед выход из игры
    /// </summary>
    private void OnApplicationQuit()
    {
        EventManager.SaveData();
    }
    public void ButtonSaveOptionsData()
    {
        EventManager.SaveDataOptions();
    }
    private void OnDestroy()
    {
        EventManager.PauseEvent -= Pause;
    }
}
