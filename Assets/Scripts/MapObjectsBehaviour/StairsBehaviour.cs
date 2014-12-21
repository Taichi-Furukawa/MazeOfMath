using UnityEngine;
using System.Collections;

public class StairsBehaviour : MonoBehaviour {
	public int matrix_i,matrix_j;
	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Objects";
		particleSystem.renderer.sortingOrder = MapWillLoad.PositionMatrix.GetLength(0)-matrix_i;
		MapWillLoad.MaterialMatrix[matrix_i,matrix_j] = "Stairs";

	}
	
	// Update is called once per frame
	void Update () {
		particleSystem.renderer.sortingOrder = MapWillLoad.PositionMatrix.GetLength(0)-matrix_i;
		if(matrix_i == PlayerBehaviour.Player_i && matrix_j == PlayerBehaviour.Player_j){
			//Debug.Log("Stairs");
			//MapWillLoad.MaterialMatrix =  MapWillLoad.dungeon.CreateDungeon();
			Application.LoadLevel("initScene");
		}
	}


}