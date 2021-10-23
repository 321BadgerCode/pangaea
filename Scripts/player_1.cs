using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace player
{
	public class player_1 : object_1
	{
		private pause_1 pause;
		private GameObject player;
		private SpriteRenderer sr;
		private bool hit;
		private audio_manager_1 Audio;
		[HideInInspector()] public float currency;
		[HideInInspector()] public bool dead;

		[SerializeField()] private main_mechanic_1 main;
		[SerializeField()] private GameObject pauseButton;
		[SerializeField()] private TMPro.TextMeshProUGUI text;
		[SerializeField()] private Slider healthBar;
		[SerializeField()] private GameObject DeathMenu;
		[Range(0, 100)] public float health = 100;

		void Start()
		{
			Audio = FindObjectOfType<audio_manager_1>();

			pause = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<pause_1>();

			player = gameObject;
			sr = player.GetComponent<SpriteRenderer>();
		}

		void Update()
		{
			currency = PlayerPrefs.GetFloat("currency");
			text.text = currency.ToString();

			health = PlayerPrefs.GetFloat("player_health");
			healthBar.value = health;

			if (hit == true) { PlayerPrefs.SetFloat("player_health", health -= 10); hit = false; }

			if (a1 == 1)
			{
				dead = true;
				Audio.play("player_death");
				player.transform.position = new Vector3(0, 0, 0);
				a1 = 2;
			}
			if (health <= 0) { dead = true; Audio.play("player_death"); }
			if (dead == true)
			{
				DeathMenu.SetActive(true);
				sr.color = new Color(0, 0, 0);
				Time.timeScale = 0f;
				pause.PauseMenu.SetActive(false);
				pauseButton.SetActive(false);
				PlayerPrefs.SetInt("stage", 0);
				PlayerPrefs.SetFloat("player_health", health = 100);
			}
			if (dead == false && pause.paused == false) { Time.timeScale = 1f; }
		}

		private void OnTriggerEnter2D(Collider2D collision) { if (collision.CompareTag("Enemy")) { sr.color = new Color(255, 0, 0); hit = true; } }
		private void OnTriggerExit2D(Collider2D collision) { if (collision.CompareTag("Enemy")) { sr.color = new Color(255, 255, 255); } }
	};
};