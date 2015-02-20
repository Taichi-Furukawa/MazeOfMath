using UnityEngine;
using System.Collections;

public class HierarchyRoot : MonoBehaviour {
	static public GameObject GameGUI;
	
	GameObject MapObjectsPrefab;
	GameObject MenueSetupPrefab;
	GameObject CharactorsPrefab;
	

	static public GameObject Charactors;
	static public GameObject MapObjects;
	static public GameObject MenueSetup;
	// Use this for initialization
	void Start () {
		GameGUI = GameObject.Find ("GameGUI");
	 	
		CharactorsPrefab = (GameObject)Resources.Load("HierarchyRoot/Charactors");
		Charactors = (GameObject)Instantiate (CharactorsPrefab, Vector2.zero, Quaternion.identity);
		Charactors.name = "Charactors";

		MapObjectsPrefab = (GameObject)Resources.Load("HierarchyRoot/MapObjects");
		MapObjects = (GameObject)Instantiate (MapObjectsPrefab, Vector2.zero, Quaternion.identity);
		MapObjects.name = "MapObjects";

	 	MenueSetupPrefab = (GameObject)Resources.Load("HierarchyRoot/MenueSetup");
		MenueSetup = (GameObject)Instantiate (MenueSetupPrefab, Vector2.zero, Quaternion.identity);
		MenueSetup.name = "MenueSetup";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
