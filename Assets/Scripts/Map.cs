using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    //참조변수
    GameObject gm;
    GameManager gMS;

    //변수
    int height = 20, width = 10;
    Tile[,] map;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
        gMS = gm.GetComponent<GameManager>();
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
        if (y < 0) {
            gMS.GameOver();
            return;
        }
        map[y, x].block = block;
        map[y, x].isThereBlock = true;
    }


    int[] clearHeight = new int[4];
    int clearNum = 0;
    //Line Clear 체크 후 삭제, 삭제 된 라인 수 반환
    public int CheckLineClear() {
        bool isThisLineCleared = false;

        //line clear 하나 체크 후 4번째는 break 하기 위한 변수
        bool oneLineDetected = false;
        int detectedHeight = 0;

        clearNum = 0;
        for(int y=0; y<height; y++) {
            if(height == detectedHeight + 4 && oneLineDetected) {
                break;
            }

            isThisLineCleared = true;
            for(int x=0; x<width; x++) {
                if (!map[y, x].isThereBlock) {
                    isThisLineCleared = false;
                    break;
                }
            }
            if (isThisLineCleared) {
                oneLineDetected = true;
                detectedHeight = y;
                clearHeight[clearNum] = y;
                clearNum++;
                isThisLineCleared = false;
            }
        }
        int result = clearNum;
        if(clearNum > 0) {
            LineClear();
        }
        return result;
    }

    void LineClear() {
        for(int i=0; i<clearNum; i++) {
            
            //Line Clear
            for (int j = 0; j < width; j++) {
                Destroy(map[clearHeight[i], j].block);
                map[clearHeight[i], j].block = null;
                map[clearHeight[i], j].isThereBlock = false;
            }

            //윗 Line 들 한칸 씩 내리기
            for(int j = clearHeight[i]-1; j >= 0; j--) {
                for(int k=0; k<width; k++) {
                    if(map[j, k].block != null) {
                        map[j + 1, k].isThereBlock = map[j, k].isThereBlock;
                        map[j + 1, k].block = map[j, k].block;
                        map[j, k].isThereBlock = false;
                        map[j, k].block = null;
                        map[j + 1, k].block.transform.position = map[j + 1, k].block.transform.position + new Vector3(0, -1, 0);
                    }
                }
            }
        }
        clearNum = 0;
    }

}
