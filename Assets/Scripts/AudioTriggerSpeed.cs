using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerSpeed : MonoBehaviour
{
    [SerializeField]
	private AudioSource audio;
 
	private void OnTriggerEnter(Collider other)
	{
   		if (other.CompareTag("Player") && !audio.isPlaying) {
      		audio.Play();
		}
	}

	private void OnTriggerExit(Collider other)
    {
   		if (other.CompareTag("Player") && audio.isPlaying) {
      		audio.Stop();
        }
    }
}
