using UnityEngine;
using System.Collections;

public class SelectBehaviour : MonoBehaviour {

	int heigh = 2;
	int width = 8;

	public Vector2 matrix_position = new Vector2 (0, 0);

	Vector2 space_interval = new Vector2(120,167);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 my_position = transform.localPosition;
		if (Input.GetKeyDown (KeyCode.RightArrow) && is_move("right")) {
			my_position.x += space_interval.x;
			matrix_position.x ++;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && is_move("left")) {
			my_position.x -= space_interval.x;
			matrix_position.x --;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) && is_move("up")) {
			my_position.y += space_interval.y;
			matrix_position.y --;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && is_move("down")) {
			my_position.y -= space_interval.y;
			matrix_position.y ++;
		}
		transform.localPosition = my_position;
	}

	bool is_move(string str){
		if (str == "right") {
			return matrix_position.x+1 < 8;
		}
		if (str == "left") {
			return matrix_position.x-1 >= 0;
		}
		if (str == "up") {
			return matrix_position.y-1 >= 0;
		}
		if (str == "down") {
			return matrix_position.y+1 < 2;	
		}
		return false;
	}
}
