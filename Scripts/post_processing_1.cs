using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class post_processing_1 : MonoBehaviour
{
	private player.player_1 player;
	private Bloom bloomLayer;
	private LensDistortion Lens;
	private Vignette Vignette;
	private AutoExposure Exposure;
	private bool collided;

	[SerializeField()] private bool Default;
	[SerializeField()] private bool OnCollided;
	[SerializeField()] private bool dead;
	[SerializeField()] private float bloom;
	[SerializeField()] private float distortion;
	[SerializeField()] private float vignette;
	[SerializeField()] private float exposure;
	[SerializeField()] private bool Activate;
	[SerializeField()] private bool start;

	public void change_visuals()
	{
		bloomLayer.intensity.value = bloom;
		Lens.intensity.value = distortion;
		Vignette.intensity.value = vignette;
		Exposure.keyValue.value = exposure;
	}

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<player.player_1>();

		PostProcessVolume volume = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<PostProcessVolume>();

		bloomLayer = null; volume.profile.TryGetSettings(out bloomLayer); bloomLayer.enabled.value = true;
		Lens = null; volume.profile.TryGetSettings(out Lens); Lens.enabled.value = true;
		Vignette = null; volume.profile.TryGetSettings(out Vignette); Vignette.enabled.value = true;
		Exposure = null; volume.profile.TryGetSettings(out Exposure); Exposure.enabled.value = true;

		if (start == true) { change_visuals(); }
	}

	private void Update()
	{
		if (Default == true) { bloom = 10f; distortion = 0f; vignette = .4f; exposure = 1f; }
		else if (OnCollided == false && dead == false) { Activate = true; }
		if (collided == true && OnCollided == true) { Activate = true; }
		if (dead == true && player.dead == true) { Activate = true; }
		if (Activate == true) { change_visuals(); }
	}

	private void OnTriggerEnter2D(Collider2D collision) { if (collision.CompareTag("Player")) { collided = true; } }
};
