using UnityEngine;
using System.Collections;

public class PlayerBehaviour : CharactorBehaviour {
	// Use this for initialization
	void Start () {
		base.Start ();
		self_name = "Player";
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		Self_position = transform.position;
		if (move_state == false) {
			if (Input.GetKeyDown (KeyCode.RightArrow) && MapWillLoad.MaterialMatrix[matrix_i,matrix_j+1] == "None") {
				//画像移動処理
				Interfaces.turn_add();
				right_move();
			} else if (Input.GetKeyDown (KeyCode.LeftArrow) && MapWillLoad.MaterialMatrix[matrix_i,matrix_j-1] == "None") {
				Interfaces.turn_add();
				left_move();
			} else if (Input.GetKeyDown (KeyCode.UpArrow) && MapWillLoad.MaterialMatrix[matrix_i+1,matrix_j] == "None") {
				Interfaces.turn_add();
				up_move();
			} else if (Input.GetKeyDown (KeyCode.DownArrow) && MapWillLoad.MaterialMatrix[matrix_i-1,matrix_j] == "None") {;
				Interfaces.turn_add();
				down_move();
			}
		}
		//transform.position = Ppos;
	}

}
