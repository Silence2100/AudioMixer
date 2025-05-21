using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    private AudioSource _backgroundSource;

    private void Awake()
    {
        _backgroundSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _backgroundSource.loop = true;
        _backgroundSource.Play();
    }
}
