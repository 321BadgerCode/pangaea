using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemy
{
	public abstract class enemy : MonoBehaviour
	{
		private audio_manager_1 Audio;
		private random_audio_1 RAudio;
		private gun_1 gun;
		private BoxCollider2D enemyCT;
		private float health = 100;
		private main_mechanic_1 mainMechanic;
		[HideInInspector()] public GameObject Player;
		[HideInInspector()] public player.player_1 player;
		[HideInInspector()] public bool enemyHurt;
		[HideInInspector()] public bool enemyDead;

		[System.Serializable()]
		public class save
		{
			[Range(0, 100)] public float hurt;
			[Range(0, 100)] public float dead;
		};
		[SerializeField()] private save s1;
		[SerializeField()] private GameObject EnemyDieParticle;
		public float speed;

		void Start()
		{
			Audio = FindObjectOfType<audio_manager_1>();
			RAudio = gameObject.GetComponent<random_audio_1>();

			Player = GameObject.FindGameObjectWithTag("Player");
			player = Player.GetComponent<player.player_1>();
			gun = Player.transform.GetChild(0).GetComponent<gun_1>();

			mainMechanic = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<main_mechanic_1>();

			gameObject.AddComponent<BoxCollider2D>();
			enemyCT = gameObject.AddComponent<BoxCollider2D>(); enemyCT.isTrigger = true;
		}

		private void Update()
		{
			if (player.dead == true || mainMechanic.saved == true) { Destroy(gameObject); }
			if (health <= 0)
			{
				enemyDead = true;
				PlayerPrefs.SetFloat("currency", player.currency += s1.dead);
				Audio.play("EnemyDeath");
				Destroy(gameObject);
			}
		}
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Bullet"))
			{
				Instantiate(EnemyDieParticle, transform.position, transform.rotation);
				health -= gun.damage;
				PlayerPrefs.SetFloat("currency", player.currency += s1.hurt);
				enemyHurt = true;
				RAudio.play();
			}
		}
		private void OnTriggerExit2D(Collider2D collision) { if (collision.CompareTag("Bullet")) { enemyHurt = false; } }
	};
};