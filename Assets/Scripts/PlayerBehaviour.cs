using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	public static float SPEED = 1000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 Ppos = transform.position;
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			Ppos.x += MapGen.CELL_SIZE;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			Ppos.x -= MapGen.CELL_SIZE;
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Ppos.y += MapGen.CELL_SIZE;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			Ppos.y -= MapGen.CELL_SIZE;
		}
		transform.position = Ppos;
	}
}
