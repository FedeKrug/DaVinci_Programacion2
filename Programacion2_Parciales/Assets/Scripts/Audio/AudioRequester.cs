using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRequester : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioClip _clipToPlay;

    private void Start()
    {
        AudioManager.instance.PlayAudio(_clipToPlay);
    }
}
