using UnityEngine;
using System.Collections;

public class PlayerBehaviour : CharactorBehaviour {
	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		Self_position = transform.position;
		if (move_state == false) {
			if (Input.GetKeyDown (KeyCode.RightArrow) && MapWillLoad.MaterialMatrix[matrix_i,matrix_j+1] != "Wall") {
				//画像移動処理
				right_move();
			} else if (Input.GetKeyDown (KeyCode.LeftArrow) && MapWillLoad.MaterialMatrix[matrix_i,matrix_j-1] != "Wall") {
				left_move();
			} else if (Input.GetKeyDown (KeyCode.UpArrow) && MapWillLoad.MaterialMatrix[matrix_i+1,matrix_j] != "Wall") {
				up_move();
			} else if (Input.GetKeyDown (KeyCode.DownArrow) && MapWillLoad.MaterialMatrix[matrix_i-1,matrix_j] != "Wall") {;
				down_move();
			}
		}
		//transform.position = Ppos;
	}

}
