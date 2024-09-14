using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Transform target;
	public float smoothSpeed = 10f;
	public Vector3 offset;

	void FixedUpdate()
	{
		Vector3 desiredPos = target.position + offset;
		Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);

		transform.position = smoothedPos;
	}
}
