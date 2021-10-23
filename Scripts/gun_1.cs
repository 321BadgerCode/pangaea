using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_1 : MonoBehaviour
{
	private audio_manager_1 Audio;
	private GameObject Player;
	private Vector2 GameobjectRotation;
	private float GameobjectRotation2;
	private float GameobjectRotation3;
	private bool time;
	private float timer;
	private bool FacingRight = true;

	public gun_1(float A1, float A2) { fire_rate = A1; damage = A2; }
	[Range(0, 1)] public float fire_rate;
	[Range(0, 100)] public float damage;
	[SerializeField()] private Joystick joystick;
	[SerializeField()] private Transform fire_point;
	[SerializeField()] private GameObject bullet;

	private void Start() { Audio = FindObjectOfType<audio_manager_1>(); Player = GameObject.FindGameObjectWithTag("Player"); }

	void Update()
	{
		if (joystick.Horizontal != 0) { time = true; }

		GameobjectRotation = new Vector2(joystick.Horizontal, joystick.Vertical);
		GameobjectRotation3 = GameobjectRotation.x;

		if (FacingRight == true) { rotate(90, 0, GameobjectRotation2); }
		else { rotate(-90, 180, -GameobjectRotation2); }
		if (GameobjectRotation3 < 0 && FacingRight || GameobjectRotation3 > 0 && !FacingRight) { flip(); }

		if (time == true) { timer += Time.deltaTime; }
		if (timer >= fire_rate) { Instantiate(bullet, fire_point.position, transform.rotation); Audio.play("gunshot"); timer = 0f; time = false; }
	}

	private void rotate(int A1, float A2, float A3) { GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * A1; transform.rotation = Quaternion.Euler(0f, A2, A3); }
	private void flip() { FacingRight = !FacingRight; transform.Rotate(0, 180, 0); Player.transform.Rotate(0, 180, 0); }
};

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_1 : MonoBehaviour
{
	private AudioManager Audio;
	private GameObject Player;
	private Vector2 GameobjectRotation;
	private float GameobjectRotation2;
	private float GameobjectRotation3;
	private bool time;
	private float timer;
	private bool FacingRight = true;

	[Range(0, 1)] public float fire_rate;
	[Range(0, 100)] public float damage;
	[SerializeField()] private Joystick joystick;
	[SerializeField()] private Transform fire_point;
	[SerializeField()] private GameObject bullet;

	private void Start() { Audio = FindObjectOfType<AudioManager>(); Player = GameObject.FindGameObjectWithTag("Player"); }

	void Update()
	{
		Fire();

		GameobjectRotation = new Vector2(joystick.Horizontal, joystick.Vertical);
		GameobjectRotation3 = GameobjectRotation.x;

		if (FacingRight == true) { rotate(90, 0, GameobjectRotation2); }
		else { rotate(-90, 180, -GameobjectRotation2); }
		if (GameobjectRotation3 < 0 && FacingRight || GameobjectRotation3 > 0 && !FacingRight) { Flip(); }

		if (time == true) { timer += Time.deltaTime; }
		if (timer >= fire_rate) { Instantiate(bullet, fire_point.position, transform.rotation); Audio.Play("Shoot"); timer = 0f; time = false; }
	}

	private void rotate(int A1, float A2, float A3) { GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * A1; transform.rotation = Quaternion.Euler(0f, A2, A3); }
	private void Flip() { FacingRight = !FacingRight; transform.Rotate(0, 180, 0); Player.transform.Rotate(0, 180, 0); }
	private void Fire() { if (joystick.Horizontal != 0) { time = true; } }
};*/