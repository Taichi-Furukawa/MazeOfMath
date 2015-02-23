using UnityEngine;
using System.Collections;

public class TimeUI : MonoBehaviour {

	public static float time_limet = 3;
	public static float time = 0,start_time;

	float now_turn;
	float old_turn;
	float past_time;

	bool isPause = false;

	UISprite sprite;
	// Use this for initialization
	void Start () {
		start_time = Time.time;
		sprite = this.GetComponent<UISprite>();
		now_turn = old_turn= turn.turn_count;
	}
	
	// Update is called once per frame
	void Update () {
		now_turn = turn.turn_count;
		time = Time.time;
		past_time = time - start_time;
		sprite.fillAmount = 1 - past_time / time_limet;

		if (past_time > time_limet) {
			start_time = Time.time;
			turn.turn_add ();
		}

		if (now_turn != old_turn)
			start_time = Time.time;

		old_turn = now_turn;
		
	}

	public void Pause(){
		//よく考えたら必要な処理がない
	}

	public void Resume(){
		start_time = Time.time - past_time;
	}
}
