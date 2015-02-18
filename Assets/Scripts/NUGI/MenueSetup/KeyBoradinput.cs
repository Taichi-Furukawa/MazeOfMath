using UnityEngine;
using System.Collections;

public class KeyBoradinput : MonoBehaviour {
	bool saveload = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(saveload ){
				saveload = false;
			}else{
				saveload = true;
				Application.LoadLevelAdditive("SaveLoad");
			}
		}

	}
}
