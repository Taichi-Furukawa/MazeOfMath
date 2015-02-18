using UnityEngine;
using System.Collections;

public class StopTime : SystemStop {

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			base._pauser.Resume ();
			Destroy(gameObject);
		}
	}

}
