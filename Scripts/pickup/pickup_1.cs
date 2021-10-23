using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pickup
{
	public abstract class pickup_1 : MonoBehaviour
	{
		protected player.player_1 p1;
		protected CircleCollider2D cc1;

		[SerializeField()] [Range(0, 100)] protected float value;

		void Start()
		{
			p1 = GameObject.FindGameObjectWithTag("Player").GetComponent<player.player_1>();

			cc1 = gameObject.AddComponent<CircleCollider2D>(); cc1.isTrigger = true;
		}
	};
};
