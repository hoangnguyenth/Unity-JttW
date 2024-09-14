using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float speed = 5;

	private Rigidbody2D body;
	private GameObject target;
	private Animator anim;
	private bool isRunning = true;
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		target = GameObject.Find("Player");
		anim = GetComponent<Animator>();
		anim.SetBool("isRunning", isRunning);
	}

	void Update()
	{
		float step = speed * Time.deltaTime;
		Vector2 targetPos = new Vector2(target.transform.position.x, transform.position.y);
		
		transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			UnityEditor.EditorApplication.isPlaying = false;
			Application.Quit();
		}
	}
}
