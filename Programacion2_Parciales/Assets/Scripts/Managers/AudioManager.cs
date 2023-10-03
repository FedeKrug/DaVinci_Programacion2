using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Game.SO;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour //lo hago todo en el mismo porque esto permite llevar la pantalla de opciones al gameplay
{
	#region Singleton
	public static AudioManager instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			//DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	#endregion
	[Header("Audio Manager")]
	[SerializeField] AudioMixer _mixer;
	[SerializeField] AudioSource _source;

	[Header("Sliders")]
	[SerializeField] Slider[] _volumeSliders;
	[Range(0.0001f, 1f)] [SerializeField] float _initialMasterVolume = .125f;

	private void Start()
	{
		_volumeSliders[0].value = _initialMasterVolume;
		instance.SetMasterVolume(_initialMasterVolume);
	}

	public void SetMasterVolume(float sliderValue)
	{
		_mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
	}
	public void SetMusicVolume(float sliderValue)
	{
		_mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
	}
	public void SetSfxVolume(float sliderValue)
	{
		_mixer.SetFloat("SfxVolume", Mathf.Log10(sliderValue) * 20);
	}

	public void PlayAudio(AudioClip clip)
	{
		if (_source.clip == clip) return;
		_source.Stop();
		_source.clip = clip;
		_source.Play();
	}
}
