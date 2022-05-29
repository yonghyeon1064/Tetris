using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    //참조변수

    //변수
    int height = 20, width = 10;
    Tile[,] map;

    // Start is called before the first frame update
    void Start()
    {
        map = new Tile[height, width];
        SetMap();
    }

    void SetMap() {
        for(int i=0; i<height; i++) {
            for (int j = 0; j < width; j++)
                map[i, j] = new Tile();
        }
    }

    //Argument 위치가 비어있는지 반환 (GameManager가 호출)
    public bool CanBlockMove(float _x, float _y) {
        int x = (int)_x;
        int y = (int)_y;
        if (x < 0 || x >= width || y >= height) //맵 바깥 처리
            return false;
        else if (y < 0) //맵 위일 때 처리
            return true;
        else
            return !map[y, x].isThereBlock;
    }

    //Argument 위치를 채움 (GameManager가 호출)
    public void FillTile(float _x, float _y, GameObject block) {
        int x = (int)_x;
        int y = (int)_y;
        map[y, x].block = block;
        map[y, x].isThereBlock = true;
    }

    //

}
