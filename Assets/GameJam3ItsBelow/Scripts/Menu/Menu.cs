using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void Quit()
	{
		Application.Quit();
	#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
	#endif
	}

	public void ChangeScene(string SceneName)
	{
		SceneManager.LoadScene(SceneName);
		if(SceneName != "SampleScene")
		{
			UnlockCursor();
		}
	}

	public void ChangeScene2()
	{
		SceneManager.LoadScene("SampleScene");
	}
	
	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}


