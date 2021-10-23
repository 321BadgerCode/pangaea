using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class visual_1 : MonoBehaviour
{
	private Vignette vignette;
	private PostProcessVolume volume;
	private GameObject[] p;
	private SpriteRenderer[] sr;
	private Color[] colors;
	private float timer;
	private float color_num;
	private int switch1;
	private int color_index;
	private float a1;

	public enum type { none, change, shift, everything };
	[System.Serializable()] public class change {[Range(0, 100)] [Tooltip("How long it takes until the color of the platform changes")] public float max_num; };
	[System.Serializable()] public class shift {[Range(0, 1)] [Tooltip("How long it takes until the color of the platform changes")] public float time; };
	[SerializeField()] private type t1;
	[Header("Change class")]
	[Space(5)]
	[SerializeField()] private change c1;
	[Header("Shift class")]
	[Space(5)]
	[SerializeField()] private shift s1;

	void Start()
	{
		volume = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<PostProcessVolume>();
		vignette = null; volume.profile.TryGetSettings(out vignette); vignette.enabled.value = true;

		colors = new Color[5];
		colors[0] = Color.red;
		colors[1] = Color.yellow;
		colors[2] = Color.green;
		colors[3] = Color.blue;
		colors[4] = Color.magenta;
		/*colors[0] = new Color(255, 0, 0);
		colors[1] = new Color(255, 125, 0);
		colors[2] = new Color(255, 255, 0);
		colors[3] = new Color(0, 255, 0);
		colors[4] = new Color(0, 0, 255);
		colors[5] = new Color(125, 0, 125);
		colors[6] = new Color(125, 0, 255);*/
		color_index = Random.Range(0, colors.Length);

		p = GameObject.FindGameObjectsWithTag("Platform");
		System.Array.Resize(ref sr, p.Length);
		for (int a = 0; a < p.Length; a++) sr[a] = p[a].GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if (t1 == type.change)
		{
			timer += Time.deltaTime;

			color_num += .01f;
			if (timer >= c1.max_num) { switch1++; timer = 0f; color_num = 0f; }
			for (int a = 0; a < sr.Length; a++)
			{
				if (switch1 == 0) { sr[a].color = new Color(color_num, 0, 0); }
				else if (switch1 == 1) { sr[a].color = new Color(0, color_num, 0); }
				else if (switch1 == 2) { sr[a].color = new Color(0, 0, color_num); }
				else if (switch1 == 3) { sr[a].color = new Color(color_num, color_num, 0); }
				else if (switch1 == 4) { sr[a].color = new Color(0, color_num, color_num); }
				else if (switch1 == 5) { sr[a].color = new Color(color_num, 0, color_num); switch1 = 0; }
			}
		}
		else if (t1 == type.shift)
		{
			a1 = Mathf.Lerp(a1, 1f, s1.time * Time.deltaTime);
			if (a1 > .9f) { color_index = (color_index >= colors.Length) ? 0 : color_index + 1; a1 = 0f; }

			vignette.color.value = Color.Lerp(vignette.color, colors[color_index], s1.time * Time.deltaTime);
			for (int a = 0; a < sr.Length; a++) { sr[a].color = Color.Lerp(sr[a].color, colors[color_index], s1.time * Time.deltaTime); }
		}
	}
};
