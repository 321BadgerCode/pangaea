using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom_1 : MonoBehaviour
{
	private Camera camera_main;
	private int collide;
	private bool zoom_a;
	private float Original_Zoom;
	private Collider2D c1;
	private float a1;
	private bool a2;
	private float a3;

	[System.Flags()] public enum ZoomType { none, original, collided, stopped_colliding, everything };
	[Header("ZOOM VALUES!")]
	[Space(5)]
	[SerializeField()] private ZoomType zoomType;
	[SerializeField()] [Tooltip("Specifies what the zoom for the camera will be by the end of the zooming process")] [Range(0, 100)] private float zoom;
	[SerializeField()] [Tooltip("Specifies what the speed for the zooming process will be")] [Range(0, 100)] private float speed;
	[SerializeField()] [Tooltip("Check if you want to set the camera back to its default zoom value when player stops touching object")] private bool stop;
	[SerializeField()] [Tooltip("Tag for collision detection with player")] private string tag1;

	private float set_zoom()
	{
		if (speed > 0 && Mathf.Round(a1) != Mathf.Round(zoom))
		{
			if (a2 == true) { a1 += a3; }
			else { a1 -= a3; }
		}
		else if (speed <= 0) { a1 = zoom; }
		return a1;
	}

	private void Start()
	{
		camera_main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		c1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();

		if (camera_main.orthographic == true) { Original_Zoom = camera_main.orthographicSize; }
		else { Original_Zoom = camera_main.fieldOfView; }
		a1 = Original_Zoom;
		a2 = a1 < zoom;
		a3 = speed * Time.deltaTime;
	}

	private void Update()
	{
		if (c1.CompareTag(tag1)) { collide = 1; } else { collide = 2; }

		if (zoomType == ZoomType.collided && collide == 1) { zoom_a = true; }

		if (zoom_a == false)
		{
			if (zoomType == ZoomType.original) { zoom_a = true; collide = 3; }
			//else if (zoomType == ZoomType.collided && collide == 1) { zoom_a = true; }
			else if (zoomType == ZoomType.stopped_colliding && collide == 2) { zoom_a = true; collide = 3; }
		}

		if (stop == true && collide == 2)
		{
			zoom_a = false;
			if (camera_main.orthographic == true) { camera_main.orthographicSize = Original_Zoom; }
			else { camera_main.fieldOfView = Original_Zoom; }
			collide = 3;
		}

		if (camera_main.orthographic == true && zoom_a == true) camera_main.orthographicSize = set_zoom();
		else if (camera_main.orthographic == false && zoom_a == true) camera_main.fieldOfView = set_zoom();
	}
};