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
            minoS.moveMino("d");
        }
    }

    void GetInput() {
        if (gameActive) {
            if (Input.GetKeyDown(KeyCode.D)) {
                //오른쪽
                minoS.moveMino("r");
            }
            else if (Input.GetKeyDown(KeyCode.A)) {
                //왼쪽
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
                minoS.rotateMino("l");
            }
            if (Input.GetKeyDown(KeyCode.M)) {
                //오른쪽 회전
                minoS.rotateMino("r");
            }
        }
    }
}
