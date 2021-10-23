using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager_1 : MonoBehaviour
{
	private LoadSceneMode a1;

	[System.Serializable()]
	public class scenez
	{
		[System.Flags()] public enum type { none, scene_name, scene_number, random_name, random_number, everything };
		public type t1;
		[Tooltip("If 't1' is set to 'scene_name'")] public string name;
		[Tooltip("If 't1' is set to 'scene_number'")] public int number;
		[Tooltip("If 't1' is set to 'random'")] public int min;
		[Tooltip("If 't1' is set to 'random'")] public int max;
		[Tooltip("Makes scene add on to the screen rather than changing the scene")] public bool add;
		[Tooltip("Makes scene change on startup")] public bool start;
	};
	[Header("Scene class")]
	[Space(5)]
	[SerializeField()] private scenez[] s1;

	/*private IEnumerator load_scene(int A1, int A2)
	{
		while (SceneManager.sceneCount < A2)
		{
			if (s1[A1].add == false) { a1 = LoadSceneMode.Single; }
			else { a1 = LoadSceneMode.Additive; }

			if (s1[A1].t1 == scenez.type.scene_name) { SceneManager.LoadSceneAsync(s1[A1].name, a1); }
			else if (s1[A1].t1 == scenez.type.scene_number) { SceneManager.LoadSceneAsync(s1[A1].number, a1); }
			else if (s1[A1].t1 == scenez.type.random_name) { SceneManager.LoadSceneAsync(Random.Range(s1[A1].min, s1[A1].max + 1).ToString(), a1); }
			else if (s1[A1].t1 == scenez.type.random_number) { SceneManager.LoadSceneAsync(Random.Range(s1[A1].min, s1[A1].max + 1), a1); }
		}
		yield return new WaitForSeconds(1f);
	}*/

	void Start() { for (int a = 0; a < s1.Length; a++) { if (s1[a].start == true) { change_scene(a); } } }

	public void change_scene(int A1)
	{
		try
		{
			if (s1[A1].add == false) { a1 = LoadSceneMode.Single; }
			else { a1 = LoadSceneMode.Additive; }

			if (s1[A1].t1 == scenez.type.scene_name) { SceneManager.LoadSceneAsync(s1[A1].name, a1); }
			else if (s1[A1].t1 == scenez.type.scene_number) { SceneManager.LoadSceneAsync(s1[A1].number, a1); }
			else if (s1[A1].t1 == scenez.type.random_name) { SceneManager.LoadSceneAsync(Random.Range(s1[A1].min, s1[A1].max + 1).ToString(), a1); }
			else if (s1[A1].t1 == scenez.type.random_number) { SceneManager.LoadSceneAsync(Random.Range(s1[A1].min, s1[A1].max + 1), a1); }
		}
		catch { }
	}
	public void scene(string A1) { try { SceneManager.LoadSceneAsync(A1); } catch (System.Exception A) { Debug.Log(A.ToString()); } }
};
