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
				Debug.Log("SaveMenue SetDown");
				saveload = false;
			}else{
				Debug.Log("SaveMenue Setup");
				saveload = true;
				Application.LoadLevelAdditive("SaveLoad");
			}
		}

	}
}
