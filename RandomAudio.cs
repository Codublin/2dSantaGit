using UnityEngine;
using System.Collections;
[RequireComponent(typeof (AudioSource))]
public class RandomAudio : MonoBehaviour {

	public AudioClip[] soundBank;
	public float maxPitch = 1.5f;
	public float minPitch = 0.5f;
	public float maxVolume = 1f;
	public float minVolume = 0.25f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayRandomSound()
		{
		audio.pitch = Random.Range(minPitch, maxPitch);
		audio.volume = Random.Range( minVolume, maxVolume );
		audio.PlayOneShot( soundBank[ Random.Range( 0, soundBank.Length ) ] );
		}
	void OnGUI()
		{

		if ( GUI.Button( new Rect( 10, 10, 100, 30 ), "play sound" ) )
			{
			PlayRandomSound();
			}
		}
}
