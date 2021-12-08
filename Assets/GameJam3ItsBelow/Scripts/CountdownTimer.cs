using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
	public Text timerText;
	

	public int count;

	public bool isTimerDone;

	public int finalScore = 0;
	public Player player;

	public GameObject finalScoreObj;

	[Header("Timer Count")] [Space] [SerializeField] public int timerCount = 75;


	private void OnEnable()
	{
		StartCoroutine(CountingDownTimer(timerCount));
	}

	private void Awake()
	{
		DontDestroyOnLoad(finalScoreObj);
		player = FindObjectOfType<Player>();
	}

	void Update()
	{
		UpdatePlayer();
	}

	void UpdateText()
	{
		timerText.text = count.ToString();
	}
	public IEnumerator CountingDownTimer(int _seconds)
	{
		count = _seconds;
		
		while (count > 0)
		{       
			yield return new WaitForSeconds(1);
			count--;
			UpdateText();
		}
        
		
		isTimerDone = true;
		
		yield return new WaitForSeconds(2f);
		SceneChange("EndGame"); 
	}
	 
	void UpdatePlayer()
	{
		if(!isTimerDone)
			return;
		finalScore = player.fishScore;
		player.GetComponent<CharacterController>().enabled = false;
	}
	public void SceneChange(string SceneName)
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		SceneManager.LoadScene(SceneName);
	}
	

}
