using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_1 : MonoBehaviour
{
	private random_audio_1 Audio;
	private player.player_1 player;
	private main_mechanic_1 mainMechanic;
	private GameObject bomb;
	private SpriteRenderer bombSR;
	private CircleCollider2D bombCT;
	private int collided;
	private float timer;
	private bool a1;

	[SerializeField()] private GameObject ExplodeParticle;
	[SerializeField()] [Range(0, 100)] private float damage;
	[SerializeField()] [Range(0, 100)] private float timeToExplode;
	[SerializeField()] [Range(0, 10)] private float reaction_time;

	void Start()
	{
		Audio = FindObjectOfType<random_audio_1>();

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<player.player_1>();

		bomb = gameObject;
		bombSR = bomb.GetComponent<SpriteRenderer>();
		bomb.AddComponent<Rigidbody2D>();
		bomb.AddComponent<CircleCollider2D>();
		bombCT = bomb.AddComponent<CircleCollider2D>(); bombCT.isTrigger = true; bombCT.radius = 2.8f; bombCT.enabled = false; bombCT.usedByEffector = true;

		mainMechanic = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<main_mechanic_1>();
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= timeToExplode - reaction_time) { bombSR.color = new Color(255, 0, 0); }

		if (timer >= timeToExplode)
		{
			if (a1 == false)
			{
				bombCT.enabled = true;
				Instantiate(ExplodeParticle, bomb.transform.position, Quaternion.identity);
				Audio.play();
				Destroy(bomb.gameObject, .1f);
				a1 = true;
			}
			if (collided == 1) { player.health -= damage; PlayerPrefs.SetFloat("player_health", player.health); collided = 2; }
			if (player.dead == true || mainMechanic.saved == true) { Destroy(this.gameObject); }
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) { if (collision.CompareTag("Player")) { collided = 1; } }
};
