using UnityEngine;
using System.Collections;

public class TimeUI : MonoBehaviour {

	public static float time_limet = 10;
	public static float time = 0,start_time;

	int now_turn;
	int old_turn;

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

		float temp = Time.time - start_time;
		sprite.fillAmount = 1 -  temp / time_limet;
		if(temp > time_limet)	 start_time = Time.time;
		
		if(now_turn != old_turn) start_time = Time.time;

		old_turn = now_turn;

	}	
}
