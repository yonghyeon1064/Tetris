using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //참조변수
    public GameObject mino;
    public GameObject map;
    Mino minoS;
    Map mapS;
    Vector3 startPos;

    //변수
    bool gameActive = true;
    IEnumerator descent;

    // Start is called before the first frame update
    void Awake()
    {
        minoS = mino.GetComponent<Mino>();
        mapS = map.GetComponent<Map>();

        startPos = new Vector3(4.5f, 1.5f, 0);
    }

    private void Start() {
        minoS.SetPosition(startPos);
        minoS.MakeMino("Z");

        descent = MinoDownCycle();
        StartCoroutine(descent);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    IEnumerator MinoDownCycle() {
        while (gameActive) {
            yield return new WaitForSeconds(2f);
            if(CheckMovePossible("d", false))
                minoS.moveMino("d");
            else {
                Debug.Log("Can't down");
            }
        }
    }

    //미노가 움직이는 것이 가능한가
    bool CheckMovePossible(string dir, bool isRotate) {
        bool result = true;
        for(int i=0; i<minoS.blockNum && result; i++) {
            //체크해야할 좌표를 인수로 입력
            if (!isRotate) {
                if (dir == "r")
                    result = result && mapS.CanBlockMove(minoS.worldPosArr[i].x + 1f, -1 * minoS.worldPosArr[i].y);
                else if (dir == "l")
                    result = result && mapS.CanBlockMove(minoS.worldPosArr[i].x - 1f, -1 * minoS.worldPosArr[i].y);
                else if (dir == "d")
                    result = result && mapS.CanBlockMove(minoS.worldPosArr[i].x, -1 * (minoS.worldPosArr[i].y - 1f));
            }
            else {
                minoS.GetRotateWorldPos(dir);
                result = result && mapS.CanBlockMove(minoS.rotateWorldPosArr[i].x, -1 * minoS.rotateWorldPosArr[i].y);
            }
        }
        return result;
    }

    void GetInput() {
        if (gameActive) {
            if (Input.GetKeyDown(KeyCode.D)) {
                //오른쪽
                if (CheckMovePossible("r", false))
                    minoS.moveMino("r");
            }
            else if (Input.GetKeyDown(KeyCode.A)) {
                //왼쪽
                if (CheckMovePossible("l", false))
                    minoS.moveMino("l");
            }
            else if (Input.GetKeyDown(KeyCode.S)) {
                //아래쪽
                StopCoroutine(descent);
                //minoS.moveMino("d");
                StartCoroutine(descent);
            }
            /*else if (Input.GetKeyDown(KeyCode.W)) {
                //위쪽
                minoS.moveMino("u");
            }*/

            if (Input.GetKeyDown(KeyCode.N)) {
                //왼쪽 회전
                if(CheckMovePossible("l", true))
                    minoS.rotateMino("l");
            }
            if (Input.GetKeyDown(KeyCode.M)) {
                //오른쪽 회전
                if (CheckMovePossible("r", true))
                    minoS.rotateMino("r");
            }
        }
    }
}
