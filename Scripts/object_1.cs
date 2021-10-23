using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class object_1 : MonoBehaviour, IDisposable
{
	private player.player_1 p1;
	private finish_1 f1;
	private void Start() { p1 = GameObject.FindGameObjectWithTag("Player").GetComponent<player.player_1>(); f1 = GameObject.FindGameObjectWithTag("Finish").GetComponent<finish_1>(); }
	private void Update() { Dispose(); }

	protected int a1;

	public void Dispose() { if (p1.dead == true || f1.collided == true || transform.position.x <= -50 || transform.position.x >= 50 || transform.position.y <= -50 || transform.position.y >= 50) { a1 = 1; Destroy(gameObject); } }
};