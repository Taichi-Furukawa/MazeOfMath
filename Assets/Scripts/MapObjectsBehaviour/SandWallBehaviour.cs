using UnityEngine;
using System.Collections;

public class SandWallBehaviour : MonoBehaviour {
	public int matrix_i,matrix_j;
	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Objects";
		particleSystem.renderer.sortingOrder = MapWillLoad.PositionMatrix.GetLength(0)-matrix_i;
	}
	
	// Update is called once per frame
	void Update () {
		particleSystem.renderer.sortingOrder = MapWillLoad.PositionMatrix.GetLength(0)-matrix_i;
	}
}
