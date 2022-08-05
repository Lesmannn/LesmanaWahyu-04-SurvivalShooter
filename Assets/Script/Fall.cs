using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
	private void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			GameManager.instance.LoseGame();
		}
	}
}
