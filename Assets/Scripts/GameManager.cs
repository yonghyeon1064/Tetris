using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //참조변수
    public GameObject mino;
    public GameObject map;
    public GameObject restartButton;
    Mino minoS;
    Map mapS;
    Vector3 startPos;

    //변수
    bool gameActive = true;
    string[] minoList;
    int minoNum = 7;
    int currentMinoNum = 0;
    IEnumerator descent;

    // Start is called before the first frame update
    void Awake()
    {
        minoS = mino.GetComponent<Mino>();
        mapS = map.GetComponent<Map>();
        restartButton.SetActive(false);

        startPos = new Vector3(4.5f, 1.5f, 0);
        minoList = new string[] { "I", "J", "L", "Z", "S", "T", "O"};
        SwapMinoArrRandom();
    }

    private void Start() {
        minoS.SetPosition(startPos);
        minoS.MakeMino(NextMino());
        
        descent = MinoDownCycle();
        StartCoroutine(descent);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver() {
        restartButton.SetActive(true);
        gameActive = false;
    }

    public void EndGame() {
        Application.Quit();
    }

    //다음 미노 반환
    string NextMino() {
        if(currentMinoNum >= 7) {
            currentMinoNum = 0;
            SwapMinoArrRandom();
        }
        return minoList[currentMinoNum++];
    }

    //미노 목록 랜덤 스왑
    void SwapMinoArrRandom() {
        string temp;
        int random;
        for(int i=0; i<minoNum-1; i++) {
            random = Random.Range(i, 7);
            temp = minoList[random];
            minoList[random] = minoList[i];
            minoList[i] = temp;
        }
    }

    //미노가 시간마다 하강하게 하는 코루틴
    IEnumerator MinoDownCycle() {
        while (gameActive) {
            yield return new WaitForSeconds(1f);
            if(CheckMovePossible("d", false))
                minoS.moveMino("d");
            else {
                FixBlockToMap();
                yield return new WaitForSeconds(0.1f);
                if (gameActive) {
                    minoS.SetPosition(startPos);
                    minoS.MakeMino(NextMino());
                    mapS.CheckLineClear(); // 얘 이용해서 점수 계산 가능
                }
            }
        }
    }

    //미노가 움직이는 것이 가능한가 체크
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
    
    //Block 맵에 고정
    void FixBlockToMap() {
        for(int i=0; i<minoS.blockNum; i++)
            mapS.FillTile(minoS.worldPosArr[i].x, -1 * minoS.worldPosArr[i].y, minoS.blockArr[i]);
    }

    //플레이어 입력 처리
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
