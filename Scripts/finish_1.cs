using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish_1 : MonoBehaviour
{
	private SpriteRenderer sr1;
	private BoxCollider2D bc1;
	private scene_manager_1 sm1;
	private bool a1;
	private float a2;
	[HideInInspector()] public bool collided;

	public main_mechanic_1 mainMechanic;

	void Start()
	{
		sr1 = gameObject.GetComponent<SpriteRenderer>();
		bc1 = gameObject.AddComponent<BoxCollider2D>(); bc1.isTrigger = true;
		sm1 = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<scene_manager_1>();
	}

	void Update()
	{
		if (collided == true)
		{
			a2 += Time.deltaTime;
			sr1.color = new Color(0, 255, 0);
			Time.timeScale = .5f;
		}
		if (collided == true && a1 == false) { if (a2 >= 5) { sm1.scene("main"); a2 = 0f; } PlayerPrefs.SetInt("stage", mainMechanic.stage += 1); a1 = true; }
	}

	private void OnTriggerEnter2D(Collider2D collision) { if (collision.CompareTag("Player")) { collided = true; } }
};
