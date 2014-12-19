using UnityEngine;
using System.Collections;

public class CharactorBehaviour : MonoBehaviour {
	//位置特定(他クラスから見て)
	public int matrix_i,matrix_j;
	
	//アニメーションに関する変数
	public float vertical_SPEED = 6.0f; //(20*2/3)
	public float horizontal_SPEED = 18.0f;
	public Vector2 Purpose_position;
	public Vector2 Self_position;

	public bool right = false;
	public bool left = false;
	public bool up = false;
	public bool down = false;
	public bool temp_flg = false;

	public bool move_state = false;
	public float scale_x;

	public string self_name;
	// Use this for initialization
	public void Start () {
		particleSystem.renderer.sortingLayerName = "Objects";
		particleSystem.renderer.sortingOrder = MapWillLoad.PositionMatrix.GetLength(0)-matrix_i;
		scale_x = transform.localScale.x;
	}
	
	// Update is called once per frame
	public void Update () {
		particleSystem.renderer.sortingOrder = MapWillLoad.PositionMatrix.GetLength(0)-matrix_i;
		if (right) {
			right_animation();
		}
		
		if(left){
			left_animation();
		}
		
		if (up) {
			up_animation();
		}
		
		if (down) {
			down_animation();
		}

	}

	public void right_move(){
		MapWillLoad.MaterialMatrix[matrix_i,matrix_j] = "None";
		matrix_j += 1;
		MapWillLoad.MaterialMatrix[matrix_i,matrix_j] = self_name;

		right = true;
		move_state = true;
		Purpose_position = Self_position;
		Purpose_position.x += MapWillLoad.CELL_SIZE;
		//画像反転処理
		Vector3 scale = transform.localScale;
		scale.x = scale_x;
		transform.localScale = scale;
	}

	public void left_move(){
		MapWillLoad.MaterialMatrix[matrix_i,matrix_j] = "None";
		matrix_j -= 1;
		MapWillLoad.MaterialMatrix[matrix_i,matrix_j] = self_name;

		left = true;
		move_state = true;
		Purpose_position = Self_position;
		Purpose_position.x -= MapWillLoad.CELL_SIZE;
		//画像反転処理
		Vector3 scale = transform.localScale;
		scale.x = -scale_x;
		transform.localScale = scale;
	}

	public void up_move(){
		MapWillLoad.MaterialMatrix[matrix_i,matrix_j] = "None";
		matrix_i += 1;
		MapWillLoad.MaterialMatrix[matrix_i,matrix_j] = self_name;

		up = true;
		move_state = true;
		Purpose_position = Self_position;
		Purpose_position.y += MapWillLoad.CELL_SIZE;
	}

	public void down_move(){
		MapWillLoad.MaterialMatrix[matrix_i,matrix_j] = "None";
		matrix_i -= 1;
		MapWillLoad.MaterialMatrix[matrix_i,matrix_j] = self_name;

		down = true;
		move_state = true;
		Purpose_position = Self_position;
		Purpose_position.y -= MapWillLoad.CELL_SIZE;
	}

	void right_animation(){
		Self_position.x += vertical_SPEED;
		if(Self_position.x < Purpose_position.x-MapWillLoad.CELL_SIZE/2){
			Self_position.y += vertical_SPEED;
		}
		if (Self_position.x > Purpose_position.x - MapWillLoad.CELL_SIZE / 2) {
			Self_position.y -= vertical_SPEED;		
		}
		transform.position = Self_position;
		if (Self_position.x > Purpose_position.x) {
			transform.position = Purpose_position;
			right = false;
			move_state = false;
		}
	}
	void left_animation(){
		Self_position.x -= vertical_SPEED;
		if (Self_position.x > Purpose_position.x + MapWillLoad.CELL_SIZE / 2) {
			Self_position.y += vertical_SPEED;
		}
		if (Self_position.x < Purpose_position.x + MapWillLoad.CELL_SIZE / 2) {
			Self_position.y -= vertical_SPEED;		
		}
		transform.position = Self_position;
		if (Self_position.x < Purpose_position.x) {
			transform.position = Purpose_position;
			left = false;
			move_state = false;
		}
	}
	void up_animation(){
		if (Self_position.y < Purpose_position.y + MapWillLoad.CELL_SIZE/2 && temp_flg == false) {
			Self_position.y += horizontal_SPEED;
		}
		
		if (temp_flg) {
			Self_position.y -= horizontal_SPEED;
		}
		
		if (Self_position.y > Purpose_position.y + MapWillLoad.CELL_SIZE/2) {
			temp_flg = true;
		}
		
		//Self_position.y += SPEED;
		transform.position = Self_position;
		
		if (Self_position.y < Purpose_position.y && temp_flg) {
			transform.position = Purpose_position;
			up = false;
			move_state = false;
		}
	}
	void down_animation(){
		if (Self_position.y < Purpose_position.y + MapWillLoad.CELL_SIZE *1.5f && temp_flg == false) {
			Self_position.y += horizontal_SPEED;
		}
		if (temp_flg) {
			Self_position.y -= horizontal_SPEED;
		}
		if (Self_position.y > Purpose_position.y + MapWillLoad.CELL_SIZE *1.5f) {
			temp_flg = true;
		}
		
		
		//Self_position.y -= SPEED;
		transform.position = Self_position;
		if (Self_position.y < Purpose_position.y && temp_flg) {
			transform.position = Purpose_position;
			down = false;
			move_state = false;
		}
	}

}
