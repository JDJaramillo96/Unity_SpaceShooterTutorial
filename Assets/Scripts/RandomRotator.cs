using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	[SerializeField]
	private float tumble;
	[SerializeField]
	private Rigidbody rigidbody;

	void Start ()
	{
		rigidbody.angularVelocity = Random.onUnitSphere * tumble;
	}
}