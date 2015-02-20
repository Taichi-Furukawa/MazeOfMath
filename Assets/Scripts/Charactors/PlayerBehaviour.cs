using UnityEngine;
using System.Collections;

public class PlayerBehaviour : CharactorBehaviour {
	public static int Player_i,Player_j;
	public static int Health = 5;
	// Use this for initialization
	void Start () {
		base.Start ();
		self_name = "Player";
		gameObject.name = self_name;
		Player_i = matrix_i;
		Player_j = matrix_j;

	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		Self_position = transform.position;
		if (move_state == false) {
			if (Input.GetKeyDown (KeyCode.RightArrow)) MoveDecision(matrix_i,matrix_j+1);
			else if (Input.GetKeyDown (KeyCode.LeftArrow)) MoveDecision(matrix_i,matrix_j-1);
			else if (Input.GetKeyDown (KeyCode.UpArrow)) MoveDecision(matrix_i+1,matrix_j);
			else if (Input.GetKeyDown (KeyCode.DownArrow)) MoveDecision(matrix_i-1,matrix_j);
		}
		//transform.position = Ppos;
	}

	void MoveDecision(int to_i,int to_j){
		if (MapWillLoad.MaterialMatrix [to_i, to_j] == "None" || MapWillLoad.MaterialMatrix [to_i, to_j] == "Stairs") {
			Debug.Log (MapWillLoad.MaterialMatrix [to_i, to_j]);

			if ((Player_i - to_i) == 0 && (Player_j - to_j) < 0)right_move ();
			else if ((Player_i - to_i) == 0 && (Player_j - to_j) > 0)left_move ();
			else if ((Player_i - to_i) < 0 && (Player_j - to_j) == 0)up_move ();
			else if ((Player_i - to_i) > 0 && (Player_j - to_j) == 0)down_move ();

		} else if (MapWillLoad.MaterialMatrix [to_i, to_j] == "E1") {
			Attack (1, MapWillLoad.MaterialMatrix [to_i, to_j]);
			Debug.Log ("bbb");
		}

		turn.turn_add();
		Player_i = matrix_i;
		Player_j = matrix_j;
	}
	

	void Attack(int offensive,string EnemyName){
		GameObject offensEnemy = GameObject.Find( EnemyName );
		offensEnemy.GetComponent<EnemyBehaviour> ().Health--;
	}

}
