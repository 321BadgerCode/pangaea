using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_1 : MonoBehaviour
{
	private Vector2 screen_bounds;

	[System.Serializable()]
	public sealed class go
	{
		[HideInInspector()] public Vector2 pos;
		[HideInInspector()] public float timer;
		[HideInInspector()] public bool a1;

		public enum type { none, xy, x, y, everything };
		public type t1;
		public GameObject spawn;
		public GameObject spawn_particle;
		[Range(0, 100)] public float time_between_spawns;
		[Range(0, 10)] public float time_particle_spawn;
		public Vector2 xy;
	};
	[SerializeField()] private go[] go1;

	void Start() { screen_bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); }

	void Update()
	{
		for (int a = 0; a < go1.Length; a++)
		{
			if (go1[a].t1 == go.type.x) { go1[a].pos = new Vector2(go1[a].xy.x, Random.Range(-screen_bounds.y, screen_bounds.y)); }
			else if (go1[a].t1 == go.type.y) { go1[a].pos = new Vector2(Random.Range(-screen_bounds.x, screen_bounds.x), go1[a].xy.y); }
			else if (go1[a].t1 == go.type.xy) { go1[a].pos = new Vector2(go1[a].xy.x, go1[a].xy.y); }
			else { go1[a].pos = new Vector2(Random.Range(-screen_bounds.x, screen_bounds.x), Random.Range(-screen_bounds.y, screen_bounds.y)); }

			if (go1[a].spawn_particle != null && go1[a].timer >= go1[a].time_between_spawns - go1[a].time_particle_spawn && go1[a].a1 == false) { Instantiate(go1[a].spawn_particle, go1[a].pos, Quaternion.identity); go1[a].a1 = true; }

			if (go1[a].timer >= go1[a].time_between_spawns) { Instantiate(go1[a].spawn, go1[a].pos, Quaternion.identity); go1[a].timer = 0f; go1[a].a1 = false; }
			else { go1[a].timer += Time.deltaTime; }
		}
	}
};
