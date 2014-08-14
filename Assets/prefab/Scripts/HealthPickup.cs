using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour 
{
	public int health = 5;
	bool showCollect = false;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" && other.gameObject.GetComponent<Health>().AddHealth(health))
		{
			GetComponentInChildren<SpriteRenderer>().enabled = false;
			collider2D.enabled = false;
			StartCoroutine("Destroy");
			showCollect = true;
		}
	}

	void OnGUI()
	{
		if (showCollect) 
		{
			Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
			GUI.color = Color.green;
			GUI.Label(new Rect(pos.x,Screen.height - pos.y, 100,35), "+" + health);
				}
	}

	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(1f);
		GameObject.Destroy (this.gameObject);
	}


}