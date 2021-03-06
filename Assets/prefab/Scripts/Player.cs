﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private Transform myTransform;
	private Movement movement;
	private GameObject draggingObject;
	private bool isDead = false;
	public Texture2D deadImage;

	// Use this for initialization
	void Start () 
	{
		myTransform = this.transform;
		movement = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!isDead)
			Controls();
	}

	void Controls()
	{
		float y = Input.GetAxis("Vertical");
		float x = Input.GetAxis("Horizontal");
		Vector2 control = new Vector2(x,y);

		movement.Move(control);

		if(Input.GetButtonDown("Jump"))
		{
			movement.Jump();
		}

		if(Input.GetButtonDown("Fire1"))
		{
			movement.Shoot();
			BroadcastMessage("Shoot", movement.GetDirection(), SendMessageOptions.DontRequireReceiver);
		}
		if(Input.GetButtonDown("Fire2"))
		{
			Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
			Vector3 pos = Camera.allCameras[0].ScreenToWorldPoint(Input.mousePosition);
			//RaycastHit hit;
			
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.up, 0.1f);	
			if(hit != null && hit.transform)
			{
				Debug.Log(hit.transform.name);
				if(hit.transform.tag == "Moveable")
				{
					hit.transform.BroadcastMessage("OnDragStart");

					draggingObject = hit.transform.gameObject;
					draggingObject.transform.position = hit.transform.position;
				}
			}
		}
		if(draggingObject && Input.GetButton("Fire2"))
		{
			Vector3 pos = Camera.allCameras[0].ScreenToWorldPoint(Input.mousePosition);
			draggingObject.BroadcastMessage("Move", pos);
			//draggingObject.transform.position = new Vector3(pos.x, pos.y, 0f);
		}
		if(draggingObject && Input.GetButtonUp("Fire2"))
		{
			draggingObject.BroadcastMessage("Drop");
			draggingObject = null;
		}
	}

	public void Die()
	{
		Debug.Log("Do death animation");
		isDead = true;
		SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer> ();
		foreach (SpriteRenderer sr in renderers) {
			sr.enabled = false;
				}
		GetComponent<ConstantMovement> ().enabled = false;
	}

	void OnGUI()
	{
		if (isDead) {
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.5f, 200, 35), "Wipe Out");
			//GUI.DrawTexture(new Rect(Screen.width * 0.5f, Screen.height * 0.5f, 200, 35), deadImage);
			if(GUI.Button(new Rect(Screen.width * 0.5f, Screen.height * 0.6f, 100, 50), "Restart"))
			{
				Application.LoadLevel(Application.loadedLevelName);
			}
				}
	}

	private void DeathCountdown()
	{
		Destroy(this.gameObject);
	}
}