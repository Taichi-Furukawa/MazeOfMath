using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	public static float SPEED = 20.0f;
	Vector2 Purpose_position;
	Vector2 Player_position;
	bool move_state = false;
	bool right = false;
	bool left = false;
	bool up = false;
	bool down = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Player_position = transform.position;
		if (move_state == false) {
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				right = true;
				move_state = true;
				Purpose_position = Player_position;
				Purpose_position.x += MapGen.CELL_SIZE;
				//Ppos.x += MapGen.CELL_SIZE;
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				left = true;
				move_state = true;
				Purpose_position = Player_position;
				Purpose_position.x -= MapGen.CELL_SIZE;
				//Ppos.x -= MapGen.CELL_SIZE;
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				up = true;
				move_state = true;
				Purpose_position = Player_position;
				Purpose_position.y += MapGen.CELL_SIZE;
				//Ppos.y += MapGen.CELL_SIZE;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				down = true;
				move_state = true;
				Purpose_position = Player_position;
				Purpose_position.y -= MapGen.CELL_SIZE;
				//Ppos.y -= MapGen.CELL_SIZE;
			}
		}
		if (right) {
			right_move();
		}

		if(left){
			left_move();
		}

		if (up) {
			up_move();
		}

		if (down) {
			down_move();
		}
		//transform.position = Ppos;
	}
	void right_move(){
		Player_position.x += SPEED;
		if(Player_position.x < Purpose_position.x-MapGen.CELL_SIZE/2){
			Player_position.y += SPEED;
		}
		if (Player_position.x > Purpose_position.x - MapGen.CELL_SIZE / 2) {
			Player_position.y -= SPEED;		
		}
		transform.position = Player_position;
		if (Player_position.x > Purpose_position.x) {
			transform.position = Purpose_position;
			right = false;
			move_state = false;
		}
	}
	void left_move(){
		Player_position.x -= SPEED;
		if (Player_position.x > Purpose_position.x + MapGen.CELL_SIZE / 2) {
			Player_position.y += SPEED;
		}
		if (Player_position.x < Purpose_position.x + MapGen.CELL_SIZE / 2) {
			Player_position.y -= SPEED;		
		}
		transform.position = Player_position;
		if (Player_position.x < Purpose_position.x) {
			transform.position = Purpose_position;
			left = false;
			move_state = false;
		}
	}
	void up_move(){
		Player_position.y += SPEED;
		transform.position = Player_position;
		if (Player_position == Purpose_position) {
			up = false;
			move_state = false;
		}
	}
	void down_move(){
		Player_position.y -= SPEED;
		transform.position = Player_position;
		if (Player_position == Purpose_position) {
			down = false;
			move_state = false;
		}
	}

}
