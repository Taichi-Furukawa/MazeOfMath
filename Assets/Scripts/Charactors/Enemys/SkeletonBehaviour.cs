using UnityEngine;
using System.Collections;

public class SkeletonBehaviour : EnemyBehaviour {

	// Use this for initialization
	void Start () {
		base.Start ();
		self_name = "E1";
		name = self_name;
		MapWillLoad.MaterialMatrix[matrix_i,matrix_j] = "E1";
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		now_turn = turn.turn_count;
		search_player();
		if(old_turn != now_turn){
			if(random){
				//random_walk();
			}else{
				//run_palyer();
			}
		}
		old_turn = now_turn;
	}
}
