using UnityEngine;
using UnityEngine.UI;

public class SoundButtonPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;

    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(PlayClip);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlayClip);
    }

    private void PlayClip()
    {
        if (_clip != null)
            _audioSource.PlayOneShot(_clip);
    }
}
