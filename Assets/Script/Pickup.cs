using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
	Health, Ammo
}

public class Pickup : MonoBehaviour
{
	public PickupType type; 
	public int value;

	public float rotateSpeed;
	public float bobSpeed;
	public float bobHeight;

	private Vector3 startPos;
	private bool bobbingUp;

	private void Start()
	{
		startPos = transform.position;
	}

	private void Update()
	{
		transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

		Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight / 2, 0));

		transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

		if(transform.position == startPos + offset)
		{
			bobbingUp = !bobbingUp;
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.CompareTag("Player"))
		{
			Player player = col.GetComponent<Player>();

			switch (type)
			{
				case PickupType.Health :
					player.GiveHealth(value);
				break;
				case PickupType.Ammo :
					player.GiveAmmo(value);
				break;
			}
			Destroy (gameObject);

		}
	}
}
