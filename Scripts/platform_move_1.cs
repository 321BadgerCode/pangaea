using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace platform
{
	public class platform_move_1 : MonoBehaviour
	{
		private GameObject Platform;
		public Vector3 platformPos;
		public float speed;

		void Start()
		{
			Platform = this.gameObject;
		}

		void Update()
		{
			if (Platform.transform.position.x <= platformPos.x && Platform.transform.position.y <= platformPos.y)
			{
				Platform.transform.position += (platformPos * speed * Time.deltaTime);
			}
		}
	};
};
