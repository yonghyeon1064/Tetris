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
        //PrintMap();
    }

    void SetMap() {
        for(int i=0; i<height; i++) {
            for (int j = 0; j < width; j++)
                map[i, j] = new Tile();
        }
    }

    //GameManager가 호출
    public bool CanBlockMove(float _x, float _y) {
        int x = (int)_x;
        int y = (int)_y;
        if (x < 0 || x >= width || y >= height)
            return false;
        else if (y < 0)
            return true;
        else
            return !map[y, x].isThereBlock;
    }

    void PrintMap() {
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++)
                Debug.Log(map[i, j].isThereBlock);
        }
    }
}
