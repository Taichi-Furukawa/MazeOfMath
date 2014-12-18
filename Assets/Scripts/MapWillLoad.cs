using UnityEngine;
using System.Collections;

public class MapWillLoad : MonoBehaviour {
	public static int MAP_LENGTH_WIDTH = 30;
	public static int MAP_LENGTH_HEIGHT = 30;
	public static int CELL_SIZE = 40;
	public static Vector2[,] PositionMatrix= new Vector2[MAP_LENGTH_HEIGHT, MAP_LENGTH_WIDTH];
	public static string[,] MaterialMatrix ;//= new string[MAP_LENGTH_HEIGHT, MAP_LENGTH_WIDTH]; 
	public static Dungeon dungeon = new Dungeon(MAP_LENGTH_HEIGHT,MAP_LENGTH_WIDTH,3,5);

	public GameObject floorPrefab;
	public GameObject playerPrefab;
	public GameObject main_cameraPrefab;
	public GameObject wallPrefab;

	int xpos = 0;
	int ypos = 0;

	void Start () {

		floorPrefab = (GameObject)Resources.Load("MapObjects/floor");
		playerPrefab = (GameObject)Resources.Load ("Charactors/Player");
		main_cameraPrefab = (GameObject)Resources.Load ("Camera/Main_Camera");
		wallPrefab = (GameObject)Resources.Load("MapObjects/wall");

		for (int i=0; i<MAP_LENGTH_HEIGHT; i++) {
			ypos+=CELL_SIZE;
			xpos=0;
			for(int j=0;j<MAP_LENGTH_WIDTH;j++){
				xpos+=CELL_SIZE;
				Instantiate(this.floorPrefab,new Vector3(xpos-(CELL_SIZE/2),ypos-(CELL_SIZE/2),-1),Quaternion.identity);
				PositionMatrix[i,j] = new Vector3(xpos-(CELL_SIZE/2),ypos-(CELL_SIZE/2),0+1);
			}
		}

		MaterialMatrix = dungeon.CreateDungeon();//ダンジョン生成
		//ダンジョンの壁をインスタンス
		for (int i=0; i<MAP_LENGTH_HEIGHT; i++) {
			for (int j=0; j<MAP_LENGTH_WIDTH; j++) {
				if(MaterialMatrix[i,j] == "Wall"){
					this.wallPrefab.particleSystem.renderer.sortingLayerName = "Objects";
					this.wallPrefab.GetComponent<SandWallBehaviour>().matrix_i = i;
					this.wallPrefab.GetComponent<SandWallBehaviour>().matrix_j = j;
					Instantiate(this.wallPrefab,PositionMatrix[i,j],Quaternion.identity);
				}

			}
		}
		//Playerを生成するダンジョンの区画をランダムで決める
		int PlayerRect = UnityEngine.Random.Range(0,dungeon.RectList.Count);
		//区画内のPlayerの位置をランダムで決定(*中央がよいのか？)
		int PlayerRect_i = UnityEngine.Random.Range(dungeon.RectList[PlayerRect].room_bottom,dungeon.RectList[PlayerRect].room_top);
		int PlayerRect_j = UnityEngine.Random.Range(dungeon.RectList[PlayerRect].room_left,dungeon.RectList[PlayerRect].room_right);
		playerPrefab.GetComponent<PlayerBehaviour>().matrix_i = PlayerRect_i;//セットしてからインスタンス化
		playerPrefab.GetComponent<PlayerBehaviour>().matrix_j = PlayerRect_j;//セットしてからインスタンス化

		Instantiate (this.playerPrefab,PositionMatrix[PlayerRect_i,PlayerRect_j],Quaternion.identity);
		Instantiate (this.main_cameraPrefab,PositionMatrix[PlayerRect_i,PlayerRect_j],Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {

	}
}
