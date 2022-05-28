using UnityEngine;
using UnityEngine.Audio;
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

    private void Awake()
    {
        EventManager.PauseEvent += Pause;
    }
    private void Start()
    {
        //�������� �� �������� ������
        musicVolumeEnabled = true;
        effectsVolumeEnabled = true;
        uIVolumeEnabled = true;
    }
    /// <summary>
    /// �����
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
    /// ����� ����� ��� �������� � ���
    /// </summary>
    public void Hub()
    {
        EventManager.CallCapsuleTeleport();
    }
    /// <summary>
    /// ������������ ����� ������� ������
    /// </summary>
    public void ClickAudio()
    {
        clickButton.Play();
    }
    /// <summary>
    /// ����� �� ����
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// ������� ����� ������
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
    ///  ������� ��������� ��������� ������
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeVolumeMusic(float volume)
    {
        mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }
    /// <summary>
    /// ������� ��������� ��������� ��������
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeVolumeEffects(float volume)
    {
        mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
    }
    /// <summary>
    /// ������� ����� ��������
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
  /// ������� ���� UI
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
    private void OnDestroy()
    {
        EventManager.PauseEvent -= Pause;
    }
}
