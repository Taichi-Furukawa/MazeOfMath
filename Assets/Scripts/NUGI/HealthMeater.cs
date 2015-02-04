using UnityEngine;
using System.Collections;

public class HealthMeater : MonoBehaviour {

	// Use this for initialization
	UILabel label;
	void Start () {
		label = GetComponent<UILabel> ();
	}
	
	// Update is called once per frame
	void Update () {
		label.text = PlayerBehaviour.Health.ToString();
	}
}
