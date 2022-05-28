using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    //참조변수

    //변수
    int height = 20, width = 10;
    int[,] map;

    // Start is called before the first frame update
    void Start()
    {
        map = new int[height, width];
        SetMap();
        PrintMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetMap() {
        for(int i=0; i<height; i++) {
            for (int j = 0; j < width; j++)
                map[i,j] = 0;
        }
    }

    void PrintMap() {
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++)
                Debug.Log(map[i, j]);
        }
    }
}
