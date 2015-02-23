using UnityEngine;
using System.Collections;

public class KeyBoradinput : MonoBehaviour {
	bool saveload = false;
	bool inventory = false;
	bool isMenue = false;
	GameObject SaveLoad;
	GameObject Inventory;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (saveload) {
				saveload = false;
				isMenue = false;
				GameObject obj = GameObject.Find ("SaveLoad");
				obj.GetComponent<SystemStop>()._pauser.Resume();
				Destroy(obj);
			} else {
				if(!isMenue){
					saveload = true;
					isMenue = true;
					Application.LoadLevelAdditive ("SaveLoad");
				}
			}
		
		} else if (Input.GetKeyDown (KeyCode.A)) {
			if (inventory) {
				inventory = false;
				isMenue = false;
				GameObject obj = GameObject.Find ("Inventory");
				obj.GetComponent<SystemStop>()._pauser.Resume();
				Destroy(obj);
			} else {
				if(!isMenue){
					inventory = true;
					isMenue = true;
					Application.LoadLevelAdditive ("Inventory");
				}
			}
		}


	}
}
