using UnityEngine;
using System.Collections;

public class EnemyBehaviour : CharactorBehaviour {
	int now_turn;
	int old_turn;
	
	bool random;

	// Use this for initialization
	public void Start () {
		base.Start ();
		now_turn = old_turn= Interfaces.turn_count;
		random = true;
	}
	
	// Update is called once per frame
	public void Update () {
		Self_position = transform.position;
		now_turn = Interfaces.turn_count;
		if(old_turn != now_turn){
			if(random){
				random_walk();
			}else{

			}
		}
		base.Update ();
		old_turn = now_turn;
		//transform.position = Ppos;
	}
	void search_player(){
		
	}

	void random_walk(){
		int rand = UnityEngine.Random.Range(0,4);
		bool retry = false;
		switch(rand){
		case 0:
			if(MapWillLoad.MaterialMatrix[matrix_i,matrix_j+1] == "None"){
				right_move();
			}else{
				retry = true;
			}
			break;
		case 1:
			if(MapWillLoad.MaterialMatrix[matrix_i,matrix_j-1] == "None"){
				left_move();
			}else{
				retry = true;
			}
			break;
		case 2:
			if(MapWillLoad.MaterialMatrix[matrix_i+1,matrix_j] == "None"){
				up_move();
			}else{
				retry = true;
			}
			break;
		case 3:
			if(MapWillLoad.MaterialMatrix[matrix_i-1,matrix_j] == "None"){
				down_move();
			}else{
				retry = true;
			}
			break;
		}

		if(retry){
			random_walk();
		}


	}

	void chase_walk(){
		
	}

}
