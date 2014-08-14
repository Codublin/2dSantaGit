﻿using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour 
{
	public string levelName = "";

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Application.LoadLevel(levelName);
				}
		}
}
