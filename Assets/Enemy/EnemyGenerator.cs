using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
	public GameObject[] enemies;

	public float delayTime;

	private float timer;
	// Start is called before the first frame update
	void Start()
	{
		spawn();
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;

		if (timer > delayTime)
		{
			timer = 0;
			spawn();
		}
	}

	void spawn()
	{
		int randomIndex = Random.Range(0, enemies.Length);

		GameObject enemy = enemies[randomIndex];

		Instantiate(enemy, transform.position, Quaternion.identity);
	}
}
