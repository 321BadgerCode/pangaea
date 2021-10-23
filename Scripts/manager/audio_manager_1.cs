using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audio_manager_1 : MonoBehaviour
{
	[System.Serializable()]
	public class Sound
	{
		public string name;
		public AudioClip audio;
		[Range(0f, 1f)] public float volume;
		[Range(.1f, 3f)] public float pitch;
		[HideInInspector] public AudioSource source;
	}
	public Sound[] sounds;

	void Awake()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.audio;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}
	}

	public void play(string A1) { Sound s = System.Array.Find(sounds, sound => sound.name == A1); s.source.Play(); }
};
