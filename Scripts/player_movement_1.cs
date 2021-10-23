using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
	public class player_movement_1 : MonoBehaviour
	{
		private random_audio_1 ra1;
		private Rigidbody2D rb;
		private bool jump;
		private bool collide;
		private float X;

		[SerializeField()] [Range(0, 1)] private float damp_x;
		[SerializeField()] [Range(0, 10)] private float speed;
		[SerializeField()] [Range(0, 100)] private float jump_height;
		[SerializeField()] private GameObject jump_particle;
		[SerializeField()] private Joystick joystick;

		void Start() { ra1 = gameObject.GetComponent<random_audio_1>(); rb = gameObject.AddComponent<Rigidbody2D>(); rb.constraints = RigidbodyConstraints2D.FreezeRotation; }

		void Update()
		{
			X = rb.velocity.x;
			X += joystick.Horizontal * speed;
			X *= Mathf.Pow(1f - damp_x, Time.deltaTime * 10f);
			rb.velocity = new Vector2(X, rb.velocity.y);

			if (joystick.Vertical >= .5f && jump == false)
			{
				rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jump_height);
				Instantiate(jump_particle, gameObject.transform);
				jump = true;
				ra1.play();
			}
			else if (joystick.Vertical <= .5f && collide == true) { jump = false; }
		}

		private void OnTriggerEnter2D(Collider2D collision) { if (collision.CompareTag("Platform")) { collide = true; jump = false; } }
		private void OnTriggerExit2D(Collider2D collision) { if (collision.CompareTag("Platform")) { collide = false; } }
	};
};
