using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace platform
{
	public class platform_color_1 : MonoBehaviour
	{
		private Vignette vignette;
		private GameObject[] p;
		private SpriteRenderer[] sr;
		private Color[] colors;
		private int color_index;
		private float a1;

		[Tooltip("How long it takes until the color of the platform changes")] [Range(0, 1)] public float time;

		void Awake()
		{
			vignette = null; GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<PostProcessVolume>().profile.TryGetSettings(out vignette); vignette.enabled.value = true;

			colors = new Color[5];
			colors[0] = Color.red;
			colors[1] = Color.yellow;
			colors[2] = Color.green;
			colors[3] = Color.blue;
			colors[4] = Color.magenta;
			color_index = Random.Range(0, colors.Length);
		}

		/*private void Start()
		{
			p = GameObject.FindGameObjectsWithTag("Platform");
			System.Array.Resize(ref sr, p.Length);
			for (int a = 0; a < p.Length; a++) sr[a] = p[a].GetComponent<SpriteRenderer>();
		}*/

		void Update()
		{
			p = GameObject.FindGameObjectsWithTag("Platform");
			System.Array.Resize(ref sr, p.Length);
			for (int a = 0; a < p.Length; a++) sr[a] = p[a].GetComponent<SpriteRenderer>();

			a1 = Mathf.Lerp(a1, 1f, time * Time.deltaTime);
			if (a1 > .9f) { color_index = (color_index >= colors.Length) ? 0 : color_index + 1; a1 = 0f; }

			vignette.color.value = Color.Lerp(vignette.color, colors[color_index], time * Time.deltaTime);
			for (int a = 0; a < sr.Length; a++) { sr[a].color = Color.Lerp(sr[a].color, colors[color_index], time * Time.deltaTime); }
		}
	};
};
