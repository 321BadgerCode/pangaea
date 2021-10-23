using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_1 : MonoBehaviour
{
	public GameObject PauseMenu;
	[HideInInspector()] public bool paused;

	void Start() { PauseMenu.SetActive(false); }

	public void PauseGame() { paused = true; Time.timeScale = 0f; PauseMenu.SetActive(true); }
	public void Resume() { paused = false; Time.timeScale = 1f; PauseMenu.SetActive(false); }
	public void Restart() { PlayerPrefs.SetInt("stage", 0); }
};
