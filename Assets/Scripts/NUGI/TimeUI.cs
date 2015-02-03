using UnityEngine;
using System.Collections;

public class TimeUI : MonoBehaviour {

	public float time_limet = 10;
	float time = 0,start_time;

	UISprite sprite;
	// Use this for initialization
	void Start () {
		start_time = Time.time;
		sprite = this.GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
		float temp = Time.time - start_time;
		sprite.fillAmount = 1 -  temp / time_limet;
		if(temp > time_limet){
			 start_time = Time.time;
		}	
	}
}
