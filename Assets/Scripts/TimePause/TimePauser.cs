using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ポーズ機能を提供します
/// </summary>
public class TimePauser 
{
	/// <summary>
	/// ポーズ状態にしたUIオブジェクト配列
	/// </summary>
	private List<UnityEngine.UI.Selectable> _pause_selectables = new List<UnityEngine.UI.Selectable> ();
	
	/// <summary>
	/// ポーズ状態にしたオブジェクト配列
	/// </summary>
	private List<Behaviour> _pause_objects = new List<Behaviour> ();

	TimeUI timeUI;
	
	/// <summary>
	/// 無視するオブジェクト
	/// </summary>
	private GameObject _excludeObject = null;
	/// <summary>
	/// 
	/// </summary>
	public TimePauser()
	{
	}
	
	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="excludeObject">無視するオブジェクト</param>
	public TimePauser( GameObject excludeObject )
	{
		this._excludeObject = excludeObject;
	}
	
	/// <summary>
	/// UI関係のオブジェクトを無効にします
	/// </summary>
	public void PauseUI()
	{
		Pause (UIObject ());
	}
	
	/// <summary>
	/// Game関係のオブジェクトを無効にします
	/// </summary>
	public void PauseGame()
	{
		Pause (GmObject ());
	}
	
	/// <summary>
	/// ポーズにしたオブジェクトを元に戻します
	/// </summary>
	public void Resume()
	{
		// UnityEngine.UI.Selectableを有効
		_pause_selectables.ForEach (o => o.interactable = true);
		
		// Behaviourを有効
		_pause_objects.ForEach (o => o.enabled = true);

		if (timeUI != null) {
			timeUI.Resume();
		}
		
	}
	
	/// <summary>
	/// 指定オブジェクトを無効化します
	/// </summary>
	/// <param name="objs">Objects.</param>
	private void Pause( GameObject[] objs )
	{
		TimeUI temp;
		foreach( var obj in objs ) {

			// 無効にする対象かどうか
			if (IsExclude (obj)) {
				continue;
			}
			if((temp = obj.GetComponent<TimeUI>())  != null){
				timeUI = temp;
				timeUI.Pause();
			}
			
			// UnityEngine.UI.Selectableを無効
			var pauseSelectable = Array.FindAll(obj.GetComponentsInChildren<UnityEngine.UI.Selectable>(), (cmp) => { return cmp.interactable; });
			_pause_selectables.AddRange( pauseSelectable );
			
			// Behaviourを無効
			var pauseBehavs = Array.FindAll(obj.GetComponentsInChildren<Behaviour>(), (cmp) => { return !(cmp is UnityEngine.EventSystems.UIBehaviour) && cmp.enabled; });
			_pause_objects.AddRange( pauseBehavs );
			

		}
		
		// 無効
		_pause_selectables.ForEach( o => o.interactable = false );
		_pause_objects.ForEach (o => o.enabled = false);
	}
	
	/// <summary>
	/// 例外的に処理をしないオブジェクトかどうか取得します
	/// </summary>
	/// <returns>無視する場合はtureを返します</returns>
	/// <param name="obj"></param>
	private bool IsExclude( GameObject obj )
	{
		// 外部指定の無視オブジェクト
		if (this._excludeObject == obj) {
			return true;
		}
		// カメラ
		if (obj.GetComponent<Camera> () != null) {
			return true;
		}
		// ライト
		if (obj.GetComponent<Light> () != null) {
			return true;
		}
		// イベントシステム
		if (obj.GetComponent<UnityEngine.EventSystems.EventSystem> () != null) {
			return true;
		}
		
		// MonoBehaviourのみで構成されたGameObject
		// どうやって判定するの？
		
		return false;
	}
	
	/// <summary>
	/// ルートオブジェクトを取得します
	/// </summary>
	private static GameObject[] Root()
	{
		return Array.FindAll( GameObject.FindObjectsOfType<GameObject> (), (item) => item.transform.parent == null);
	}
	
	/// <summary>
	/// UI関係のGameObjectを取得します
	/// </summary>
	/// <returns>The object.</returns>
	private static GameObject[] UIObject()
	{
		var uiObjects = new List<GameObject> ();
		foreach(Transform n in HierarchyRoot.GameGUI.transform){
			uiObjects.Add( n.gameObject);
		}
		return uiObjects.ToArray ();
	}
	
	/// <summary>
	/// Game関係のGameObjectを取得します
	/// </summary>
	/// <returns>The object.</returns>
	private static GameObject[] GmObject()
	{
		var gmObjects = new List<GameObject>();
		foreach(Transform n in HierarchyRoot.Charactors.transform){
			gmObjects.Add(n.gameObject);
		}
		return gmObjects.ToArray();
	}
}