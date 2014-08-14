using UnityEngine;
using System.Collections;

public class part2d : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		particleSystem.renderer.sortingLayerName = "Main";
		particleSystem.renderer.sortingOrder = 5;
		StartCoroutine (OnOff ());
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator OnOff()
	{
		while (true) {
			particleSystem.enableEmission = true;
			GetComponent<BoxCollider2D>().enabled = true;
			yield return new WaitForSeconds (1f);
			particleSystem.enableEmission = false;
			GetComponent<BoxCollider2D>().enabled = false;
			yield return new WaitForSeconds (1f);
				}
	}
}
