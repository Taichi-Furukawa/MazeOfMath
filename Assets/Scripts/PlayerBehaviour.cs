using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	public static float SPEED = 1500;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 direction = new Vector2 (Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
		rigidbody2D.velocity = direction * SPEED;
	}
}
