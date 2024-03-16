using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public Animator transition;
	public float transitionTime = 1f;
	
	public void LoadMainMenu()
    {
	    Time.timeScale = 1;
        StartCoroutine(LoadLevel(0));
    }
	
	public void LoadTrack()
    {
        StartCoroutine(LoadLevel(1));
    }

	public void LoadCarSelection()
    {
        StartCoroutine(LoadLevel(2));
    }

	public void LoadSettings()
	{
		StartCoroutine(LoadLevel(3));
	}

	IEnumerator LoadLevel(int levelIndex)
	{
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);
		SceneManager.LoadScene(levelIndex);
	}
}
