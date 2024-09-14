using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NpcFollowingMovement : MonoBehaviour
{
	public Transform target;
	public float speed = 2f;
	public float minDistance = 3f;
	public TnkScript tnkScript;
	public float jumpForce = 5f;

	private Animator anim;
	private SpriteRenderer rdr;
	private Rigidbody2D body;
	private bool isTouchedGrass = false;

	private void Start()
	{
		anim = GetComponent<Animator>();
		rdr = GetComponent<SpriteRenderer>();
		body = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		float distance = Vector2.Distance(transform.position, target.position);

		if (distance > minDistance)
		{
			anim.SetBool("isRunning", true);

			Vector2 direction = (target.position - transform.position).normalized;
			float dirX = Mathf.Sign(direction.x);
			transform.Translate(new Vector3(dirX * speed * Time.deltaTime, 0));

			if (dirX < 0)
			{
				rdr.flipX = true;
			} else rdr.flipX = false;

			
			if (tnkScript != null && tnkScript.flyHack)
			{
				if (transform.position.y < target.position.y && !isTouchedGrass)
				{
					body.velocity = new Vector2(body.velocity.x, speed);
				}
			}
		} else 
		{
			anim.SetBool("isRunning", false);
		}
	}
}