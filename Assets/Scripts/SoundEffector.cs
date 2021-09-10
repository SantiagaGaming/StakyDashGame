using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _dashSound, _winSound, _loseSund; 


    public void PlayDashSound()
    {
        _audioSource.PlayOneShot(_dashSound);

    }
    public void PlayWinSound()
    {
        _audioSource.PlayOneShot(_winSound);

    }
    public void PlayLoseSound()
    {
        _audioSource.PlayOneShot(_loseSund);

    }

}
