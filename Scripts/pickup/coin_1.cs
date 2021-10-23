using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pickup
{
	public class coin_1 : pickup_1
	{
		private void OnTriggerEnter2D(Collider2D collision) { if (collision.CompareTag("Player")) { p1.currency += value; PlayerPrefs.SetFloat("currency", p1.currency); Destroy(gameObject, .1f); } }
	};
};