using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemy
{
	public class enemy_shoot_1 : enemy
	{
		private float timer;

		[SerializeField()] private GameObject bullet;
		[SerializeField()] private float fire_rate;

		private void shoot() { Instantiate(bullet, transform.position, transform.rotation); }

		private void Update()
		{
			timer += Time.deltaTime;
			//transform.Rotate(Player.transform.position, speed * Time.deltaTime);
			if (timer >= fire_rate) { shoot(); fire_rate = 0f; }
		}
	};
};