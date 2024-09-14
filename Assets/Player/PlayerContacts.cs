using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerContacts : MonoBehaviour
{
	public float rayDistance = 10f;
	public Vector3 rayPos;

	private ChooseArrowScript arrowScript;
	private GameObject choosingArrow;
	private bool enemyDetected = false;

	private const int arrowLayer = 7;

	void Start()
	{
		choosingArrow = Resources.FindObjectsOfTypeAll<GameObject>()
			.FirstOrDefault(obj => 
							obj.layer == arrowLayer && 
							obj.name == "ChoosingArrow" &&
							obj.hideFlags == HideFlags.None);
		arrowScript = choosingArrow.GetComponent<ChooseArrowScript>();
	}
	void FixedUpdate()
	{
		// Raycast vv
		Debug.DrawRay(transform.position + rayPos, Vector2.right * rayDistance, Color.green);
		RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + rayPos, Vector2.right, rayDistance);

		enemyDetected = false;

		foreach (var hit in hits)
		{
			if (hit.collider != null && hit.collider.CompareTag("Enemy"))
			{
				Debug.Log("Enemy detected: " + hit.collider.name);
				arrowScript.SetTarget(hit.collider.transform);
				enemyDetected = true;
				break;
			}
		}

		if (!enemyDetected) arrowScript.SetTarget(null);
	}
}