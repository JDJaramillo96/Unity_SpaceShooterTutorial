using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{

	public float xMin, xMax, zMin, zMaz;
}

public class PlayerController : MonoBehaviour {

	public Boundary boundary;
	[SerializeField]
	private float movementSpeed;
	[SerializeField]
	private float tilt;
	[SerializeField]
	private Rigidbody rigidbody;
	[SerializeField]
	private GameObject shot;
	[SerializeField]
	private Transform spawnShot;
	[SerializeField]
	private AudioSource audio;

	void Awake()
	{
		audio = GetComponent<AudioSource> ();
	}

	void Update()
	{
		if (Input.GetButtonDown ("Fire1"))
		{
			Instantiate (shot, spawnShot.position, spawnShot.rotation);
			audio.Play ();
		}
	}

	void FixedUpdate()
	{
		float movementHorizontal = Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (movementHorizontal, 0.0f, movementVertical);
		rigidbody.velocity = movement * movementSpeed;
		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMaz)
		);
		rigidbody.rotation = Quaternion.Euler (rigidbody.velocity.z * tilt, 0.0f, rigidbody.velocity.x * -tilt);
	}
}