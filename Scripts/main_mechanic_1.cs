using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class main_mechanic_1 : MonoBehaviour
{
	private player.player_1 player;
	private Transform Warning2;
	private TextMeshProUGUI Warning3;
	private audio_manager_1 Audio;
	private finish_1 finish2;
	private int timer;
	private float timer2;
	private float a1;
	private int a2 = 0;
	[HideInInspector()] public int stage;
	[HideInInspector()] public bool saved;

	[SerializeField()] private TextMeshProUGUI Timertext;
	[SerializeField()] private TextMeshProUGUI Highscoretext;
	[SerializeField()] private TextMeshProUGUI HighscoreStagetext;
	[SerializeField()] private TextMeshProUGUI Stagetext;
	[SerializeField()] private GameObject Warning;
	[SerializeField()] private GameObject finish;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<player.player_1>();

		Warning2 = Warning.transform.GetChild(1);
		Warning3 = Warning2.GetComponent<TextMeshProUGUI>();

		Audio = FindObjectOfType<audio_manager_1>();

		finish2 = finish.GetComponent<finish_1>();

		PlayerPrefs.SetFloat("highscore", 0);
		Highscoretext.text = PlayerPrefs.GetFloat("highscore").ToString();

		PlayerPrefs.SetInt("stage_highscore", 0);
		HighscoreStagetext.text = PlayerPrefs.GetInt("stage_highscore").ToString();
	}

	void Update()
	{
		a1 += Time.deltaTime;
		timer = 30 - Mathf.RoundToInt(a1);

		Timertext.text = timer.ToString();

		stage = PlayerPrefs.GetInt("stage");
		Stagetext.text = PlayerPrefs.GetInt("stage").ToString();
		if (timer > PlayerPrefs.GetFloat("highscore"))
		{
			PlayerPrefs.SetFloat("highscore", timer);
			Highscoretext.text = timer.ToString();
		}
		if (stage > PlayerPrefs.GetInt("stage_highscore"))
		{
			PlayerPrefs.SetInt("stage_highscore", stage);
			HighscoreStagetext.text = stage.ToString();
		}

		if (timer <= 0)
		{
			timer2 += Time.deltaTime;
			Warning3.text = timer2.ToString();
			if (a2 == 0) { a2 = 1; }
			if (a2 == 1)
			{
				finish.SetActive(true);
				Warning.SetActive(true);
				Audio.play("Map");
				a2 = 2;
			}
		}
		if (timer2 >= 10 && finish2.collided == false) { saved = false; player.dead = true; }
		else if (finish2.collided == true) { saved = true; }
	}
};
