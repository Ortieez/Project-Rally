using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
	// sound input
	public AudioSource ButtonHover;
	public AudioSource ButtonClick;

    public void QuitGame()
    {
        Debug.Log("Quit"); // Prints "Quit" to the console
        Application.Quit(); // Quits the game
    }


	public void onMouseEnterButton() {
		ButtonHover.Play();
	}

	public void onMouseClickButton() {
		ButtonClick.Play();
	}
}
