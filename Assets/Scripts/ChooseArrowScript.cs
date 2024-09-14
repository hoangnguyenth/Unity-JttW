using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseArrowScript : MonoBehaviour
{
	public Transform target;

	// Start is called before the first frame update
	void Start()
	{
		gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (gameObject.activeInHierarchy && target != null)
		{
			transform.position = target.position;
		}
	}

	public void SetTarget(Transform newt)
	{
		target = newt;
		gameObject.SetActive(target != null);
	}
}
