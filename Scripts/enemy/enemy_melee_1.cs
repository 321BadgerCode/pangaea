using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemy
{
	public class enemy_melee_1 : enemy
	{
		private void Update() { transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime); }
	};
};
