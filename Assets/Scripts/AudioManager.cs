using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    public void PlayAudio(AudioClip audioClip, bool overwrite)
    {
        if (!_audioSource.isPlaying || overwrite)
        {
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    }
}
