using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private Rigidbody rigidbody;

	void Start()
	{
		rigidbody.velocity = transform.forward * speed;
	}
}