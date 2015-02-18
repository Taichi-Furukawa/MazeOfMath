using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapWillLoad : MonoBehaviour {
	public static int MAP_LENGTH_WIDTH = 30;
	public static int MAP_LENGTH_HEIGHT = 30;
	public static int CELL_SIZE = 40;
	public static Vector2[,] PositionMatrix= new Vector2[MAP_LENGTH_HEIGHT, MAP_LENGTH_WIDTH];
	public static string[,] MaterialMatrix ;//= new string[MAP_LENGTH_HEIGHT, MAP_LENGTH_WIDTH]; 
	public static Dungeon dungeon = new Dungeon(MAP_LENGTH_HEIGHT,MAP_LENGTH_WIDTH,3,5);
	public static List<GameObject> GameObjectList = new List<GameObject>();

	public GameObject floorPrefab;
	public GameObject playerPrefab;
	public GameObject skeletonPrefab;
	public GameObject main_cameraPrefab;
	public GameObject wallPrefab;
	public GameObject stairsPrefab;

	int PlayerRect;
	int StairsRect;

	int xpos = 0;
	int ypos = 0;

	void Start () {
		floorPrefab = (GameObject)Resources.Load("MapObjects/MapMaterial/floor");
		playerPrefab = (GameObject)Resources.Load ("Charactors/Player");
		skeletonPrefab = (GameObject)Resources.Load ("Charactors/Enemys/Skeleton");

		main_cameraPrefab = (GameObject)Resources.Load ("Camera/Main_Camera");
		wallPrefab = (GameObject)Resources.Load("MapObjects/MapMaterial/wall");
		stairsPrefab = (GameObject)Resources.Load("MapObjects/MapMaterial/stairs");

		for (int i=0; i<MAP_LENGTH_HEIGHT; i++) {
			ypos+=CELL_SIZE;
			xpos=0;
			for(int j=0;j<MAP_LENGTH_WIDTH;j++){
				xpos+=CELL_SIZE;
				GameObjectList.Add(floorPrefab);
				Instantiate(this.floorPrefab,new Vector3(xpos-(CELL_SIZE/2),ypos-(CELL_SIZE/2),-1),Quaternion.identity);
				PositionMatrix[i,j] = new Vector3(xpos-(CELL_SIZE/2),ypos-(CELL_SIZE/2),0+1);
			}
		}
		CreateMap();
	}
	
	// Update is called once per frame

	void Update () {

		
	}

	void CreateMap(){
		MaterialMatrix = dungeon.CreateDungeon();//ダンジョン生成
		//ダンジョンの壁をインスタンス
		for (int i=0; i<MAP_LENGTH_HEIGHT; i++) {
			for (int j=0; j<MAP_LENGTH_WIDTH; j++) {
				if(MaterialMatrix[i,j] == "Wall"){
					this.wallPrefab.particleSystem.renderer.sortingLayerName = "Objects";
					this.wallPrefab.GetComponent<SandWallBehaviour>().matrix_i = i;
					this.wallPrefab.GetComponent<SandWallBehaviour>().matrix_j = j;
					GameObjectList.Add(wallPrefab);
					Instantiate(this.wallPrefab,PositionMatrix[i,j],Quaternion.identity);
				}

			}
		}

		//Player生成とカメラ生成
		Player_instance();

		//階段の配置
		Stairs_instance();

		//敵の配置
		Enemys_instance();
	}

	void Player_instance(){
		//Playerを生成するダンジョンの区画をランダムで決める
		PlayerRect = UnityEngine.Random.Range(0,dungeon.RectList.Count);
		//区画内のPlayerの位置をランダムで決定(*中央がよいのか？)
		int PlayerRect_i = UnityEngine.Random.Range(dungeon.RectList[PlayerRect].room_bottom,dungeon.RectList[PlayerRect].room_top);
		int PlayerRect_j = UnityEngine.Random.Range(dungeon.RectList[PlayerRect].room_left,dungeon.RectList[PlayerRect].room_right);
		playerPrefab.GetComponent<PlayerBehaviour>().matrix_i = PlayerRect_i;//セットしてからインスタンス化
		playerPrefab.GetComponent<PlayerBehaviour>().matrix_j = PlayerRect_j;//セットしてからインスタンス化
		
		GameObjectList.Add(playerPrefab);
		GameObjectList.Add(main_cameraPrefab);

		Instantiate (this.playerPrefab,PositionMatrix[PlayerRect_i,PlayerRect_j],Quaternion.identity);//プレイヤーインスタンス
		Instantiate (this.main_cameraPrefab,PositionMatrix[PlayerRect_i,PlayerRect_j],Quaternion.identity);//カメラインスタンス

	}
	void Stairs_instance(){
		StairsRect = UnityEngine.Random.Range(0,dungeon.RectList.Count);
		while(StairsRect != PlayerRect) StairsRect = UnityEngine.Random.Range(0,dungeon.RectList.Count);
		int StairsRect_i = UnityEngine.Random.Range(dungeon.RectList[StairsRect].room_bottom+1,dungeon.RectList[StairsRect].room_top);
		int StairsRect_j = UnityEngine.Random.Range(dungeon.RectList[StairsRect].room_left+1,dungeon.RectList[StairsRect].room_right);
		stairsPrefab.GetComponent<StairsBehaviour>().matrix_i = StairsRect_i;//セットしてからインスタンス化
		stairsPrefab.GetComponent<StairsBehaviour>().matrix_j = StairsRect_j;//セットしてからインスタンス化
		GameObjectList.Add(stairsPrefab);

		Instantiate(this.stairsPrefab,PositionMatrix[StairsRect_i,StairsRect_j],Quaternion.identity);
	}
	void Enemys_instance(){
		int EnemyRect = UnityEngine.Random.Range(0,dungeon.RectList.Count);
		while(EnemyRect != PlayerRect && EnemyRect != StairsRect)EnemyRect = UnityEngine.Random.Range(0,dungeon.RectList.Count);//(!=なら同じ部屋に,==なら違う部屋に)

		int EnemyRect_i = UnityEngine.Random.Range(dungeon.RectList[EnemyRect].room_bottom,dungeon.RectList[EnemyRect].room_top);
		int EnemyRect_j = UnityEngine.Random.Range(dungeon.RectList[EnemyRect].room_left,dungeon.RectList[EnemyRect].room_right);
		skeletonPrefab.GetComponent<EnemyBehaviour>().matrix_i = EnemyRect_i;//セットしてからインスタンス化
		skeletonPrefab.GetComponent<EnemyBehaviour>().matrix_j = EnemyRect_j;//セットしてからインスタンス化
		GameObjectList.Add(skeletonPrefab);

		Instantiate (this.skeletonPrefab,PositionMatrix[EnemyRect_i,EnemyRect_j],Quaternion.identity);
	}
}
