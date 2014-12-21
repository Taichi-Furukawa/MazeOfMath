using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Dungeon{
	public int minRoomSize;
	public int maxRoomSize;
	public int mapWidth;
	public int mapHeight;
	public string[,] mapData;
	public List<DungeonRect> RectList;

	public Dungeon(int in_mapHeight,int in_mapWidth,int in_minRoomSize,int in_maxRoomSize){
		minRoomSize = in_minRoomSize;
		maxRoomSize = in_maxRoomSize;
		mapHeight = in_mapHeight;
		mapWidth = in_mapWidth;


		mapData = new string[mapHeight,mapWidth];
		RectList = new List<DungeonRect>();
	}
	public string[,] CreateDungeon(){
		Map_AllWall();//全部壁にする
		RectList.Clear();
		RectList.Add(CreateRect(1,mapHeight-1,mapWidth-1,1));//大きなRectを作成

		bool flag = false;
		if(UnityEngine.Random.Range(0,2) == 1) flag = true;

		SplitRect(flag);

		CreateRoom();
		//FillRect();
		FillRoom();

		setRoomBool();
		ConnectRect();
		PrintRect();
		//ConnectRoom();


		return mapData;
	}

	void ConnectRect(){

		for(int n = 0;n<RectList.Count;n++){
			DungeonRect rectA = RectList[n];
            
            int min_left_dis = 10000;
            int left = 0;
			int min_right_dis = 10000;
            int right = 0;
			int min_top_dis = 10000;
            int top = 0;
			int min_bottom_dis = 10000;
            int bottom = 0;

            int Ax = (rectA.room_right - rectA.room_left)/2 + rectA.room_left;
            int Ay = (rectA.room_top - rectA.room_bottom)/2 + rectA.room_bottom;



			for(int m = 0;m<RectList.Count;m++){
				if(n != m){//自分以外
                    DungeonRect rectB = RectList[m];

					int Bx = (rectB.room_right - rectB.room_left) / 2 + rectB.room_left;
					int By = (rectB.room_top - rectB.room_bottom) / 2 + rectB.room_bottom;
            		int temp_dis = 0;

					if(rectA.left && rectB.right){//自分の左が接続
                        temp_dis = (Ax - Bx) + Math.Abs(Ay - By);
                        if (temp_dis < min_left_dis) {
                            left = m;
                            min_left_dis = temp_dis;
                        }
                    }
                    if (rectA.right && rectB.left){
                        temp_dis = (Bx - Ax) + Math.Abs(Ay - By);
                        if (temp_dis < min_right_dis) {
                            right = m;
                            min_right_dis = temp_dis;
                        }
					}
                    if (rectA.top && rectB.bottom){
                        temp_dis = (By - Ay) + Math.Abs(Ax - Bx);
                        if (temp_dis < min_top_dis) {
                            top = m;
                            min_top_dis = temp_dis;
                        }
					}
                    if (rectA.bottom && rectB.top){
                        temp_dis = (Ay - By) + Math.Abs(Ax - Bx);
                        if (temp_dis < min_bottom_dis)
                        {
                            bottom = m;
                            min_bottom_dis = temp_dis;
                        }
					}
				}
			}
            //自分以外について調べ終わる．
            if (left != 0) {
                ConnectRoom(rectA, RectList[left],"left");
                rectA.left = false;
                RectList[left].right = false;
            }
            if (right != 0) {
                ConnectRoom(rectA, RectList[right],"right");
                rectA.right = false;
                RectList[right].left = false;
            }
            if (top != 0) {
                ConnectRoom(rectA, RectList[top],"top");
                rectA.top = false;
                RectList[top].bottom = false;
            }
            if (bottom != 0) {
                ConnectRoom(rectA, RectList[bottom],"bottom");
                rectA.bottom = false;
                RectList[bottom].top = false;
            }
		}
	}

    void ConnectRoom(DungeonRect rectA, DungeonRect rectB,string str) {
    	//Debug.Log("ConnectRoom");
    	int y1,y2,x;
    	int x1,x2,y;
    	if(UnityEngine.Random.Range(0,5) <= 5){
		    if (str.Equals("left")) {
				//Debug.Log("ConnectRoom left");
		        y1 = UnityEngine.Random.Range(rectA.room_bottom+1,rectA.room_top-1);
		    	y2 = UnityEngine.Random.Range(rectB.room_bottom+1,rectB.room_top-1);
		    	x = UnityEngine.Random.Range(rectB.room_right+1,rectA.room_left-1);

		    	for(int i = rectB.room_right;i<x+1;i++){
		    		mapData[y2,i] = "None";
		    	}
		    	for(int i = x;i<rectA.room_left;i++){
		    		mapData[y1,i] = "None";
		    	}
		    	if(y2 < y1){
		    		int temp = y2;
		    		y2 = y1;
		    		y1 = temp;
		    	}
		    	for(int i =y1; i<y2 ;i++){
		    		mapData[i,x] = "None";
		    	}


		    }
		    if (str.Equals("right")) { 
				//Debug.Log("ConnectRoom right");
		        y1 = UnityEngine.Random.Range(rectA.room_bottom+1,rectA.room_top-1);
		    	y2 = UnityEngine.Random.Range(rectB.room_bottom+1,rectB.room_top-1);
		    	x = UnityEngine.Random.Range(rectA.room_right+1,rectB.room_left-1);
		    	for(int i=rectA.room_right;i<x+1;i++){
		    		mapData[y1,i] = "None";
		    	}
		    	for(int i =x;i<rectB.room_left+1;i++){
		    		mapData[y2,i] = "None";
		    	}
		    	if(y2 < y1){
		    		int temp = y2;
		    		y2 = y1;
		    		y1 = temp;
		    	}
		    	for(int i =y1; i<y2 ;i++){
		    		mapData[i,x] = "None";
		    	}
		    }
		    if (str.Equals("top")) { 
				//Debug.Log("ConnectRoom top");
				x1 = UnityEngine.Random.Range(rectA.room_left+1,rectA.room_right-1);
				x2 = UnityEngine.Random.Range(rectB.room_left+1,rectB.room_right-1);
				y = UnityEngine.Random.Range(rectA.room_top+1,rectB.room_bottom-1);

				for(int i = rectA.room_top;i<y+1;i++){
					mapData[i,x1] = "None";
				}
				for(int i = y;i<rectB.room_bottom+1;i++){
					mapData[i,x2] = "None";
				}
				if(x2 < x1){
					int temp = x2;
					x2 = x1;
					x1 = temp;
				}
				for(int i = x1;i<x2; i++){
					mapData[y,i] = "None";
				}


		    
		    }
		    if (str.Equals("bottom")) { 
				//Debug.Log("ConnectRoom bottom");
				x1 = UnityEngine.Random.Range(rectA.room_left+1,rectA.room_right-1);
				x2 = UnityEngine.Random.Range(rectB.room_left+1,rectB.room_right-1);
				y = UnityEngine.Random.Range(rectB.room_top+1,rectA.room_bottom-1);

				for(int i = rectB.room_top;i<y+1;i++){
					mapData[i,x1] = "None";
				}
				for(int i = y;i<rectA.room_bottom+1;i++){
					mapData[i,x2] = "None";
				}
				if(x2 < x1){
					int temp = x2;
					x2 = x1;
					x1 = temp;
				}
				for(int i = x1;i<x2; i++){
					mapData[y,i] = "None";
				}
		    
		    }
    	}
    }


	void setRoomBool(){
		for(int n = 0;n<RectList.Count;n++){
			RectList[n].left = (RectList[n].rect_left != 1);
			
			RectList[n].right = (RectList[n].rect_right != mapWidth-1);

			RectList[n].bottom = (RectList[n].rect_bottom != 1);

			RectList[n].top = (RectList[n].rect_bottom != mapHeight-1);
		}
	}

	void CreateRoom(){
		DungeonRect rect;
		for(int i = 0;i<RectList.Count; i++){
			////Debug.Log("Create Room");
			rect = RectList[i];

			int max_width = rect.getRectWidth();//Rectに入る最大roomサイズ
			int max_height = rect.getRectHeight();
			////Debug.Log("max width = "+max_width+" max_height = "+max_height);

			int room_width = UnityEngine.Random.Range(minRoomSize,max_width-2);
			int room_height = UnityEngine.Random.Range(minRoomSize,max_height-2);
			////Debug.Log("room width = "+room_width+" room_height = "+room_height);


			int room_left = rect.rect_left + UnityEngine.Random.Range(1, rect.getRectWidth() - room_width);
			int room_top  = rect.rect_top - UnityEngine.Random.Range(1, rect.getRectHeight() - room_height);
			int room_rigth = room_left + room_width;
			int room_bottom = room_top - room_height;

			RectList[i].setRoom(room_left,room_top,room_rigth,room_bottom);


		}
	}


	void PrintRect(){
		////Debug.Log("Print Rect" + RectList.Count);

		for(int i = 0;i<RectList.Count;i++){
			////Debug.Log("rect left = "+RectList[i].rect_left+" top = "+RectList[i].rect_top+" right = "+RectList[i].rect_right+" bottom = "+RectList[i].rect_bottom);
			////Debug.Log("room left = "+RectList[i].room_left+" top = "+RectList[i].room_top+" right = "+RectList[i].room_right+" bottom = "+RectList[i].room_bottom);
			////Debug.Log(RectList[i].getRectWidth());
			////Debug.Log(RectList[i].left);
			
		}
	}

	void FillRect(){
		for(int n = 0;n<RectList.Count;n++){
			for(int i = RectList[n].rect_bottom; i < RectList[n].rect_top; i++){
				for(int j = RectList[n].rect_left; j < RectList[n].rect_right; j++){
					mapData[i,j] = "None";
				}
			}
		}
	}

	void FillRoom(){
		for(int n = 0;n<RectList.Count;n++){
			for(int i = RectList[n].room_bottom; i < RectList[n].room_top; i++){
				for(int j = RectList[n].room_left; j < RectList[n].room_right; j++){
					mapData[i,j] = "None";
				}
			}
		}
	}

	void SplitRect(bool isVertical){
		////Debug.Log("SplitRect");
		List<DungeonRect> new_RectList = new List<DungeonRect>();
		////Debug.Log(RectList.Count);
		int count_newRect = 0;
		for(int i = 0;i<RectList.Count;i++){//すべてのRectに対して行う
			DungeonRect parent = RectList[i];
			////Debug.Log("left = "+parent.rect_left+" top = "+parent.rect_top+" right = "+parent.rect_right+" bottom = "+parent.rect_bottom);

			DungeonRect rectA = new DungeonRect();
			DungeonRect rectB = new DungeonRect();

			if(isVertical){//縦分割時
				////Debug.Log("Vertical");
				if(parent.getRectWidth() >= (minRoomSize + 3)*2+1){//(最小の部屋区分 + 壁2) * 2 + 通路1のスペースがあるとき
					int point = UnityEngine.Random.Range(parent.rect_left + (minRoomSize + 3), parent.rect_right - (minRoomSize + 2 + 1));//右側のrectAの右座標を決定(+1は通路分)
					rectA.setRect(parent.rect_left, parent.rect_top, point, parent.rect_bottom );
					rectB.setRect(point + 1, parent.rect_top, parent.rect_right, parent.rect_bottom);
					new_RectList.Add(rectA);
					new_RectList.Add(rectB);
					count_newRect += 2;
				}else{
					new_RectList.Add(parent);
				}
			}else{//横分割時
				////Debug.Log("Horizontal");
				if(parent.getRectHeight() >= (minRoomSize + 3)*2+1){//(最小の部屋区分 + 壁2) * 2 + 通路1のスペースがあるとき
					int point = UnityEngine.Random.Range(parent.rect_bottom + (minRoomSize + 3), parent.rect_top - (minRoomSize + 2 + 1));
					rectA.setRect(parent.rect_left, parent.rect_top, parent.rect_right, point);
					rectB.setRect(parent.rect_left, point - 1,parent.rect_right, parent.rect_bottom);
					new_RectList.Add(rectA);
					new_RectList.Add(rectB);
					count_newRect += 2;
				}else{
					new_RectList.Add(parent);
				}

			}
		}
		
		if(count_newRect != 0){
			RectList = new_RectList;
			SplitRect(!isVertical);
		}

	}



	DungeonRect CreateRect(int left,int top,int right,int bottom){
		DungeonRect rect = new DungeonRect();
		rect.setRect(left,top,right,bottom);
		return rect;
	}

	void Map_AllWall(){
		//Debug.Log("MAP is All wall");
		for(int i =0;i<mapHeight;i++){
			for(int j = 0;j<mapWidth;j++){
				mapData[i,j] = "Wall";
			}
		}
	}


}
