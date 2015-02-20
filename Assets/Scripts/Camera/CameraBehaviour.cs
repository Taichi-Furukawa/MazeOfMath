using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	public GameObject player;


	int i,j,old_i,old_j;

	float SPEED = 6.0f;
	Vector2 Camera_position;
	Vector2 Purpose_position;
	bool left = false;
	bool right = false;
	bool up = false;
	bool down = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		gameObject.name = "MainCamera";
		int i = player.GetComponent<PlayerBehaviour>().matrix_i;
		int j = player.GetComponent<PlayerBehaviour>().matrix_j;
		Vector2 my_position = MapWillLoad.PositionMatrix[i,j];

		transform.position = new Vector3 (my_position.x, my_position.y, -10);
		old_i = i;
		old_j = j;

	}
	
	// Update is called once per frame
	void Update () {
		Camera_position = transform.position;

		int i = player.GetComponent<PlayerBehaviour>().matrix_i;
		int j = player.GetComponent<PlayerBehaviour>().matrix_j;

		if(j > old_j){
			right = true;
			Purpose_position = Camera_position;
			Purpose_position.x += MapWillLoad.CELL_SIZE;
		}
		if(j < old_j){
			left = true;
			Purpose_position = Camera_position;
			Purpose_position.x -= MapWillLoad.CELL_SIZE;
		}
		if(i > old_i){
			up = true;
			Purpose_position = Camera_position;
			Purpose_position.y += MapWillLoad.CELL_SIZE;
		}
		if(i < old_i){
			down = true;
			Purpose_position = Camera_position;
			Purpose_position.y -= MapWillLoad.CELL_SIZE;
		}

		if(right){
			move_right();
		}
		if(left){
			move_left();
		}
		if(up){
			move_up();
		}
		if(down){
			move_down();
		}
		old_i = i;
		old_j = j;
	}

	void move_right(){
		Camera_position.x += SPEED;
		transform.position = new Vector3(Camera_position.x, Camera_position.y, -10);
		if(Camera_position.x > Purpose_position.x){
			Camera_position = new Vector3(Purpose_position.x, Purpose_position.y, -10);
			right = false;
		}
	}
	void move_left(){
		Camera_position.x -= SPEED;
		transform.position = new Vector3(Camera_position.x, Camera_position.y, -10);
		if(Camera_position.x < Purpose_position.x){
			Camera_position = new Vector3(Purpose_position.x, Purpose_position.y, -10);
			left = false;
		}
	}
	void move_up(){
		Camera_position.y += SPEED;
		transform.position = new Vector3(Camera_position.x, Camera_position.y, -10);
		if(Camera_position.y > Purpose_position.y){
			Camera_position = new Vector3(Purpose_position.x, Purpose_position.y, -10);
			up = false;
		}
	}
	void move_down(){
		Camera_position.y -= SPEED;
		transform.position = new Vector3(Camera_position.x, Camera_position.y, -10);
		if(Camera_position.y < Purpose_position.y){
			Camera_position = new Vector3(Purpose_position.x, Purpose_position.y, -10);
			down = false;
		}
	}
}
