using UnityEngine;
using System.Collections;

public class CoalDamage : MonoBehaviour {

	public int damage = 5;
	bool showCollect = false;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			audio.Play();
			other.gameObject.BroadcastMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);
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
			GUI.color = Color.red;
			GUI.Label(new Rect(pos.x,Screen.height - pos.y, 100,35), "-" + damage);
		}
	}
	
	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(1f);
		GameObject.Destroy (this.gameObject);
	}
}
