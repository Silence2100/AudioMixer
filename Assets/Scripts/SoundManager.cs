using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private AudioSource _backgroundAudioSource;
    [SerializeField] private AudioSource _buttonsAudioSource;
    [SerializeField] private AudioClip[] _clips;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _buttonVolumeSlider;
    [SerializeField] private Slider _backgroundVolumeSlider;

    private bool _isMuted = false;
    private float _lastVolume = 1f;

    public void SetMasterVolume() => SetVolume(_masterVolumeSlider, "MasterVolume");
    public void SetButtonVolume() => SetVolume(_buttonVolumeSlider, "ButtonVolume");
    public void SetMusicVolume() => SetVolume(_backgroundVolumeSlider, "MusicVolume");

    public void PlaySound(int index)
    {
        if (index >= 0 && index < _clips.Length && _clips[index] != null)
        {
            _buttonsAudioSource.PlayOneShot(_clips[index]);
        }
    }

    public void SetVolume(Slider slider, string exposedParameter)
    {
        float volume = Mathf.Clamp(slider.value, 0.0001f, 1f);
        _audioMixer.SetFloat(exposedParameter, Mathf.Log10(volume) * 20f);
    }

    public void ToggleMute()
    {
        if (_isMuted)
        {
            _audioMixer.SetFloat("MasterVolume", Mathf.Log10(_lastVolume) * 20f);
            _masterVolumeSlider.value = _lastVolume;
        }
        else
        {
            _lastVolume = _masterVolumeSlider.value;
            _audioMixer.SetFloat("MasterVolume", -80f);
            _masterVolumeSlider.value = 0.0001f;
        }

        _isMuted = !_isMuted;
    }
}