using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_audio_1 : MonoBehaviour
{
	private AudioSource as1;
	private bool a1;

	[SerializeField()] private AudioClip[] audioClips;
	[SerializeField()] [Tooltip("Check to play audio when game starts")] private bool start;

	private void Awake() { as1 = gameObject.AddComponent<AudioSource>(); }
	private void Start() { if (start == true) { a1 = true; } }
	private void Update() { if (a1 == true) { as1.clip = audioClips[Random.Range(0, audioClips.Length)]; as1.PlayOneShot(as1.clip); a1 = false; } }

	public void play() { a1 = true; }
};
