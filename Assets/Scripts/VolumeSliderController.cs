using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    private const float MIN_DECIBEL = -80f;
    private const float DECIBEL_CONVERSION_FACTOR = 20f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _exposedParameter;
    [SerializeField] private Slider _volumeSlider;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        OnSliderValueChanged(_volumeSlider.value);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        if (value <= 0)
        {
            _audioMixer.SetFloat(_exposedParameter, MIN_DECIBEL);
        }
        else
        {
            float dB = Mathf.Log10(value) * DECIBEL_CONVERSION_FACTOR;
            _audioMixer.SetFloat(_exposedParameter, dB);
        }
    }
}
