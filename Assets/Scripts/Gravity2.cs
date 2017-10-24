using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gravity2 : MonoBehaviour {

	public GameObject player;
	public GameObject cylinder;

	public float gravitationalPull;

	private Vector3 middlePoint;
	private Vector3 playerV;
	private Vector3 playerPos;

	void Start () {
		
		//playerV = player.transform.position;
		//middlePoint = new Vector3 (0, 0, playerV[2]); // sets middle point to have same z as player
	}    

	void FixedUpdate() {
		//apply spherical gravity to selected objects (set the objects in editor)
		//playerPos = new Vector3 (playerV [0], playerV [1], playerV [2]); 
		//middlePoint.z = playerV [2];
		player.GetComponent<Rigidbody>().AddForce((cylinder.transform.position - player.transform.position).normalized * gravitationalPull);

		}
		
		}
