using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class diolog_1 : MonoBehaviour
{
	private int index;

	[SerializeField()] private string[] reply;
	[SerializeField()] private float TypeSpeed;
	[SerializeField()] private Text text;
	[SerializeField()] private GameObject Button;
	[SerializeField()] private GameObject PlayButton;

	void Start() { StartCoroutine(Type()); }

	private void Update()
	{
		if (text.text == reply[index]) { Button.SetActive(true); }
		if (index >= reply.Length - 1) { PlayButton.SetActive(true); }
	}

	IEnumerator Type() { foreach (char letter in reply[index].ToCharArray()) { text.text += letter; yield return new WaitForSeconds(TypeSpeed); } }

	public void Click()
	{
		Button.SetActive(false);
		if (index < reply.Length) { index++; text.text = ""; StartCoroutine(Type()); }
		else { text.text = ""; }
	}

	public void end(string A1)
	{
		if (index == reply.Length) { SceneManager.LoadSceneAsync(A1, LoadSceneMode.Single); }
	}
};
