using UnityEngine;
using System.Collections;

public class MapGen : MonoBehaviour {
	public static int MAP_LENGTH_WIDTH = 20;
	public static int MAP_LENGTH_HEIGHT = 10;
	public static int CELL_SIZE = 100;
	public static Vector2[,] PositionMatrix= new Vector2[MAP_LENGTH_HEIGHT, MAP_LENGTH_WIDTH];


	public GameObject floorPrefab;
	public GameObject playerPrefab;
	public GameObject main_cameraPrefab;

	int xpos = 0;
	int ypos = 0;

	void Start () {
		floorPrefab = (GameObject)Resources.Load("MapObjects/floor");
		playerPrefab = (GameObject)Resources.Load ("Charactors/Player");

		for (int i=0; i<MAP_LENGTH_HEIGHT; i++) {
			ypos+=CELL_SIZE;
			xpos=0;
			for(int j=0;j<MAP_LENGTH_WIDTH;j++){
				xpos+=CELL_SIZE;
				Instantiate(this.floorPrefab,new Vector3(xpos-(CELL_SIZE/2),ypos-(CELL_SIZE/2),-1),Quaternion.identity);
				PositionMatrix[i,j] = new Vector2(xpos-(CELL_SIZE/2),ypos-(CELL_SIZE/2));
			}
		}

		Instantiate (this.playerPrefab,PositionMatrix[5,10],Quaternion.identity);
		main_cameraPrefab = (GameObject)Resources.Load ("Camera/Main_Camera");
		Instantiate (this.main_cameraPrefab,PositionMatrix[5,10],Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {

	}
}
