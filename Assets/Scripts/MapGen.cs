using UnityEngine;
using System.Collections;

public class MapGen : MonoBehaviour {
	public static int MAP_LENGTH_WIDTH = 20;
	public static int MAP_LENGTH_HEIGHT = 10;
	public static int CELL_SIZE = 100;

	public GameObject floorPrefab;

	int xpos = 0;
	int ypos = 0;

	void Start () {
		floorPrefab = (GameObject)Resources.Load("MapObjects/floor");
		for (int i=0; i<MAP_LENGTH_HEIGHT; i++) {
			ypos+=CELL_SIZE;
			xpos=0;
			for(int j=0;j<MAP_LENGTH_WIDTH;j++){
				xpos+=CELL_SIZE;
				Instantiate(this.floorPrefab,new Vector3(xpos-(CELL_SIZE/2),ypos-(CELL_SIZE/2),-1),Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
