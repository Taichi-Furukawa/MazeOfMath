using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
	//プレイヤーの位置特定(他クラスから見て)
	public int matrix_i,matrix_j;

	//アニメーションに関する変数
	float vertical_SPEED = 6.0f; //(20*2/3)
	float horizontal_SPEED = 18.0f;
	Vector2 Purpose_position;
	Vector2 Player_position;
	bool move_state = false;
	bool right = false;
	bool left = false;
	bool up = false;
	bool down = false;
	bool temp_flg = false;

	//画像反転に使う
	float scale_x;
	
	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Objects";
		particleSystem.renderer.sortingOrder = MapWillLoad.PositionMatrix.GetLength(0)-matrix_i;
		scale_x = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		particleSystem.renderer.sortingOrder = MapWillLoad.PositionMatrix.GetLength(0)-matrix_i;
		Player_position = transform.position;
		if (move_state == false) {
			if (Input.GetKeyDown (KeyCode.RightArrow) && MapWillLoad.MaterialMatrix[matrix_i,matrix_j+1] != "Wall") {
				//画像移動処理
				matrix_j += 1;
				right = true;
				move_state = true;
				Purpose_position = Player_position;
				Purpose_position.x += MapWillLoad.CELL_SIZE;
				//画像反転処理
				Vector3 scale = transform.localScale;
				scale.x = scale_x;
				transform.localScale = scale;
			
			} else if (Input.GetKeyDown (KeyCode.LeftArrow) && MapWillLoad.MaterialMatrix[matrix_i,matrix_j-1] != "Wall") {
				//画像移動処理
				matrix_j -= 1;
				left = true;
				move_state = true;
				Purpose_position = Player_position;
				Purpose_position.x -= MapWillLoad.CELL_SIZE;
				//画像反転処理
				Vector3 scale = transform.localScale;
				scale.x = -scale_x;
				transform.localScale = scale;

			} else if (Input.GetKeyDown (KeyCode.UpArrow) && MapWillLoad.MaterialMatrix[matrix_i+1,matrix_j] != "Wall") {
				//画像移動処理
				matrix_i += 1;
				up = true;
				move_state = true;
				Purpose_position = Player_position;
				Purpose_position.y += MapWillLoad.CELL_SIZE;
				temp_flg = false;

			} else if (Input.GetKeyDown (KeyCode.DownArrow) && MapWillLoad.MaterialMatrix[matrix_i-1,matrix_j] != "Wall") {
				//画像移動処理
				matrix_i -= 1;
				down = true;
				move_state = true;
				Purpose_position = Player_position;
				Purpose_position.y -= MapWillLoad.CELL_SIZE;
				temp_flg = false;

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

	public void set_matrix_ij(int i,int j){
		matrix_i = i;
		matrix_j = j;
	}
	
	void right_move(){
		Player_position.x += vertical_SPEED;
		if(Player_position.x < Purpose_position.x-MapWillLoad.CELL_SIZE/2){
			Player_position.y += vertical_SPEED;
		}
		if (Player_position.x > Purpose_position.x - MapWillLoad.CELL_SIZE / 2) {
			Player_position.y -= vertical_SPEED;		
		}
		transform.position = Player_position;
		if (Player_position.x > Purpose_position.x) {
			transform.position = Purpose_position;
			right = false;
			move_state = false;
		}
	}
	void left_move(){
		Player_position.x -= vertical_SPEED;
		if (Player_position.x > Purpose_position.x + MapWillLoad.CELL_SIZE / 2) {
			Player_position.y += vertical_SPEED;
		}
		if (Player_position.x < Purpose_position.x + MapWillLoad.CELL_SIZE / 2) {
			Player_position.y -= vertical_SPEED;		
		}
		transform.position = Player_position;
		if (Player_position.x < Purpose_position.x) {
			transform.position = Purpose_position;
			left = false;
			move_state = false;
		}
	}
	void up_move(){
		if (Player_position.y < Purpose_position.y + MapWillLoad.CELL_SIZE/2 && temp_flg == false) {
			Player_position.y += horizontal_SPEED;
		}

		if (temp_flg) {
			Player_position.y -= horizontal_SPEED;
		}

		if (Player_position.y > Purpose_position.y + MapWillLoad.CELL_SIZE/2) {
			temp_flg = true;
		}

		//Player_position.y += SPEED;
		transform.position = Player_position;

		if (Player_position.y < Purpose_position.y && temp_flg) {
			transform.position = Purpose_position;
			up = false;
			move_state = false;
		}
	}
	void down_move(){
		if (Player_position.y < Purpose_position.y + MapWillLoad.CELL_SIZE *1.5f && temp_flg == false) {
			Player_position.y += horizontal_SPEED;
		}
		if (temp_flg) {
			Player_position.y -= horizontal_SPEED;
		}
		if (Player_position.y > Purpose_position.y + MapWillLoad.CELL_SIZE *1.5f) {
			temp_flg = true;
		}


		//Player_position.y -= SPEED;
		transform.position = Player_position;
		if (Player_position.y < Purpose_position.y && temp_flg) {
			transform.position = Purpose_position;
			down = false;
			move_state = false;
		}
	}

}
