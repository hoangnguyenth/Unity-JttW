using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 8;
	public float jumpForce = 5f;
	
	private Rigidbody2D body;
	private SpriteRenderer rdr;
	private Animator anim;
	private float xAxis;

	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		rdr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}
	void FixedUpdate()
	{
		xAxis = Input.GetAxis("Horizontal");
		body.velocity = new Vector2(xAxis * speed, body.velocity.y);

		anim.SetBool("isRunning", xAxis != 0);
		if (xAxis != 0) rdr.flipX = xAxis < 0;
	}
}