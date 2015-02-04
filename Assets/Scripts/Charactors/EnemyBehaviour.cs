using UnityEngine;
using System.Collections;

public class EnemyBehaviour : CharactorBehaviour {
	int now_turn;
	int old_turn;
	int player_i,player_j;

	bool random;

	// Use this for initialization
	public void Start () {
		base.Start ();
		now_turn = old_turn= turn.turn_count;
		random = true;
	}
	
	// Update is called once per frame
	public void Update () {
		Self_position = transform.position;
		now_turn = turn.turn_count;
		search_player();
		if(old_turn != now_turn){
			if(random){
				random_walk();
			}else{
				run_palyer();
			}
		}
		base.Update ();
		old_turn = now_turn;
		//transform.position = Ppos;
	}
	void run_palyer(){//経路探索すべきか→しない
		int min_dis = 9999,temp_dis;
		string move = "";
		//Debug.Log("run_palyer");

		if(matrix_in(matrix_i,matrix_j+1)  && MapWillLoad.MaterialMatrix[matrix_i,matrix_j+1] == "None"){
			temp_dis = Mathf.Abs(matrix_j+1 - player_j) + Mathf.Abs(matrix_i - player_i);
			////Debug.Log(temp_dis);
			if(min_dis >= temp_dis){
				min_dis = temp_dis;
				move = "right";
			}
		}
		if(matrix_in(matrix_i,matrix_j-1) && MapWillLoad.MaterialMatrix[matrix_i,matrix_j-1] == "None"){
			temp_dis = Mathf.Abs(matrix_j-1 - player_j) + Mathf.Abs(matrix_i - player_i);
			//Debug.Log(temp_dis);
			
			if(min_dis >= temp_dis){
				min_dis = temp_dis;
				move = "left";
			}
		}
		if(matrix_in(matrix_i-1,matrix_j) && MapWillLoad.MaterialMatrix[matrix_i-1,matrix_j] == "None"){
			temp_dis = Mathf.Abs(matrix_j - player_j) + Mathf.Abs(matrix_i-1 - player_i);
			//Debug.Log(temp_dis);
			if(min_dis >= temp_dis ){
				min_dis = temp_dis;
				move = "down";
			}
		}
		if(matrix_in(matrix_i+1,matrix_j) && MapWillLoad.MaterialMatrix[matrix_i+1,matrix_j] == "None"){
			temp_dis = Mathf.Abs(matrix_j - player_j) + Mathf.Abs(matrix_i+1 - player_i);
			if(min_dis >= temp_dis ){
				min_dis = temp_dis;
				move = "up";
			}
		}

		if(move == "right"){
			right_move();
			////Debug.Log("move right");
		}else if(move == "left"){
			left_move();
			////Debug.Log("move left");	
		}else if(move == "down"){
			down_move();
			////Debug.Log("move down");
		}else if(move == "up"){
			up_move();
			////Debug.Log("move down");
		}else{

		}
		random = true;
	}

	void search_player(){
		for(int i = matrix_i-3;i<matrix_i+4;i++){
			for(int j = matrix_j-3;j<matrix_j+4;j++){
				if(matrix_in(i,j)){
					if(MapWillLoad.MaterialMatrix[i,j] == "Player"){
						random = false;
						player_i = i;
						player_j = j;
					}
				}
			}
		}
	}
	bool matrix_in(int i,int j){
		int hight = MapWillLoad.MAP_LENGTH_HEIGHT-1;
		int widht = MapWillLoad.MAP_LENGTH_WIDTH-1;
		return (i >= 0 && i <= hight && j >= 0 && j <= widht);
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
