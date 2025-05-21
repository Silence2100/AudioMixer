using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    [SerializeField] private Button muteButton;

    private bool isMuted = false;

    private void OnEnable()
    {
        muteButton.onClick.AddListener(ToggleMute);
    }

    private void OnDisable()
    {
        muteButton.onClick.RemoveListener(ToggleMute);
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
