using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //참조변수
    public GameObject mino;
    Mino minoS;

    //변수
    IEnumerator descent;

    // Start is called before the first frame update
    void Awake()
    {
        minoS = mino.GetComponent<Mino>();
        minoS.SetPosition(new Vector3(4.5f, 1.5f, 0));
        minoS.MakeMino("Z");
    }

    private void Start() {
        descent = MinoDownCycle();
        StartCoroutine(descent);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    IEnumerator MinoDownCycle() {
        while (true) {
            yield return new WaitForSeconds(2f);
            minoS.moveMino("d");
        }
    }

    void GetInput() {
        if(Input.GetKeyDown(KeyCode.D)) {
            //오른쪽
            minoS.moveMino("r");
        }
        else if(Input.GetKeyDown(KeyCode.A)) {
            //왼쪽
            minoS.moveMino("l");
        }
        else if(Input.GetKeyDown(KeyCode.W)) {
            //위쪽
            //minoS.moveMino("u");
        }
        else if(Input.GetKeyDown(KeyCode.S)) {
            //아래쪽
            StopCoroutine(descent);
            //minoS.moveMino("d");
            StartCoroutine(descent);
        }

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
