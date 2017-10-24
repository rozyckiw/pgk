using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	public float rotateSpeed;
	public float jumpForce;

	private float distToGround;


	private SphereCollider myCollider;
	private Rigidbody myRigidbody;
	public GameObject player;
	public GameObject cylinder;



	bool IsGrounded(){
		return Physics.Raycast(transform.position, -Vector3.up, distToGround+0.5f);
	}

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
		myCollider = GetComponent<SphereCollider>();
		distToGround = myCollider.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, myRigidbody.velocity.y, moveSpeed);

		if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
		{
			Debug.Log (player.transform.eulerAngles);
			myRigidbody.velocity = new Vector3 (jumpForce, jumpForce, myRigidbody.velocity.z);
		}

		if(Input.GetKey(KeyCode.A))
		{
			
			//myRigidbody.velocity = new Vector3 (-rotateSpeed, myRigidbody.velocity.y, myRigidbody.velocity.z);
			player.transform.RotateAround(cylinder.transform.position, cylinder.transform.up, rotateSpeed);
		}

		if(Input.GetKey(KeyCode.D))
		{
			//myRigidbody.velocity = new Vector3 (rotateSpeed, myRigidbody.velocity.y, myRigidbody.velocity.z);
			player.transform.RotateAround(cylinder.transform.position, cylinder.transform.up, -rotateSpeed);
		}
			
}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Obstacle")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}