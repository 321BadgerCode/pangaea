using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class options_1 : MonoBehaviour
{
	private float a1;

	[SerializeField()] private AudioMixer audioMixer;

	public void volume(float A1) { a1 = A1; audioMixer.SetFloat("Volume", a1); }
	public void mute(bool A1) { if (A1 == true) { a1 = 0; } audioMixer.SetFloat("Volume", a1); }
};