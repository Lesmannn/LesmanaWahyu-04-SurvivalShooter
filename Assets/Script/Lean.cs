using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lean : MonoBehaviour
{
	Quaternion initialRotation;
	public float amount;
	public float slerpAmount;
    // Start is called before the first frame update
    void Start()
    {
		initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.Q))
		{
			Quaternion newRot = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y - amount, transform.localRotation.z);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, newRot, Time.deltaTime * slerpAmount);
		}
		else if (Input.GetKey(KeyCode.E))
		{
			Quaternion newRot = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y + amount, transform.localRotation.z);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, newRot, Time.deltaTime * slerpAmount);
		}
		else
		{
			transform.localRotation = Quaternion.Slerp(transform.localRotation, initialRotation, Time.deltaTime * slerpAmount);
		}
    }
}
