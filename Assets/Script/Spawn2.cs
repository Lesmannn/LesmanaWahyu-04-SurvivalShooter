using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
	public GameObject musuh;
	public int xPos;
	public int zPos;
	public int banyakMusuh;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(SpawnEnemy());
	}

	IEnumerator SpawnEnemy()
	{
		while (banyakMusuh < 5)
		{
			xPos = Random.Range(-10, 9);
			zPos = Random.Range(6, 7);
			Instantiate(musuh, new Vector3(xPos, 1, zPos), Quaternion.identity);
			yield return new WaitForSeconds(3f);
			banyakMusuh += 1;
		}
	}
}
