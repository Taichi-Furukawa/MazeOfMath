using UnityEngine;
using System.Collections;
using System;

public class DungeonRect{
	public int rect_left;
	public int rect_right;
	public int rect_top;
	public int rect_bottom;

	public int room_left;
	public int room_right;
	public int room_top;
	public int room_bottom;

	public bool left;
	public bool top;
	public bool right;
	public bool bottom;


	public DungeonRect(){

	}

	public void setRect(int left,int top,int right,int bottom){
		rect_left = left;
    	rect_top = top;
      	rect_right = right;
      	rect_bottom = bottom;
	}

	public void setRoom(int left,int top,int right,int bottom){
		room_left = left;
      	room_top = top;
      	room_right = right;
      	room_bottom = bottom;
	}
	public int getRectWidth(){
		return Math.Abs(rect_right - rect_left);
	}

	public int getRectHeight(){
		return Math.Abs(rect_bottom - rect_top);
	}

	public int getRoomWidth(){
		return Math.Abs(room_right - room_left);
	}

	public int getRoomHeight(){
		return Math.Abs(room_bottom - room_top);
	}


}
