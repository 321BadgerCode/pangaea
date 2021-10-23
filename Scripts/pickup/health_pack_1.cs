using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pickup
{
	public class health_pack_1 : pickup_1
	{
		private void OnTriggerEnter2D(Collider2D collision) { if (collision.CompareTag("Player")) { p1.health += value; PlayerPrefs.SetFloat("player_health", p1.health); Destroy(gameObject, .1f); } }
	};
};
