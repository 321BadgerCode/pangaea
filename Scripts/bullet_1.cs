using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_1 : MonoBehaviour
{
	private GameObject bullet;
	private Rigidbody2D bulletRB;
	private CircleCollider2D bulletC;
	private float timer;

	[SerializeField()] private GameObject HitParticle;
	[SerializeField()] [Range(0, 100)] private float speed;

	void Start()
	{
		bullet = gameObject;
		bulletRB = bullet.AddComponent<Rigidbody2D>(); bulletRB.isKinematic = false; bulletRB.gravityScale = 0f;
		bulletC = bullet.AddComponent<CircleCollider2D>(); bulletC.isTrigger = true;
	}

	void Update()
	{
		timer += Time.deltaTime;

		transform.Translate(Vector2.right * speed * Time.deltaTime);

		if (timer >= 3) { Destroy(bullet.gameObject); }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(bullet.gameObject);

		if (collision.CompareTag("Platform")) { Instantiate(HitParticle, bullet.transform.position, Quaternion.identity); }
	}
};
