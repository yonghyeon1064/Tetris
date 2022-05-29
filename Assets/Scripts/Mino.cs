using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino : MonoBehaviour
{
    //참조변수
    public GameObject block;
    public GameObject[] blockArr;
    Block[] bScArr;
    public Vector3[] worldPosArr;
    public Vector3[] rotateWorldPosArr;

    //변수
    enum MinoType {
        IMino,
        JMino,
        LMino,
        ZMino,
        SMino,
        TMino,
        OMino
    }
    MinoType currentMinoType;

    //한 미노에 있는 Block의 수
    public int blockNum = 4;

    public void Awake() {
        blockArr = new GameObject[4];
        bScArr = new Block[4];
        worldPosArr = new Vector3[4];
        rotateWorldPosArr = new Vector3[4];
    }

    //Mino의 위치 설정 (GameManager가 호출)
    public void SetPosition(Vector3 position) {
        transform.position = position;
    }

    //새 Block을 만들어 새 Mino를 제작 (GameManager가 호출)
    public void MakeMino(string name) {
        for(int i=0; i < blockNum; i++)
            blockArr[i] = Instantiate(block, transform.position, Quaternion.identity);
        for (int i = 0; i < blockNum; i++)
            bScArr[i] = blockArr[i].GetComponent<Block>();

        switch (name) {
            case "I":
                currentMinoType = MinoType.IMino;
                bScArr[0].SetRelation(-1.5f, 0.5f);
                bScArr[1].SetRelation(-0.5f, 0.5f);
                bScArr[2].SetRelation(0.5f, 0.5f);
                bScArr[3].SetRelation(1.5f, 0.5f);
                break;
            case "J":
                currentMinoType = MinoType.JMino;
                bScArr[0].SetRelation(-0.5f, -0.5f);
                bScArr[1].SetRelation(0.5f, -0.5f);
                bScArr[2].SetRelation(0.5f, 0.5f);
                bScArr[3].SetRelation(0.5f, 1.5f);
                break;
            case "L":
                currentMinoType = MinoType.LMino;
                bScArr[0].SetRelation(-0.5f, -0.5f);
                bScArr[1].SetRelation(-0.5f, 0.5f);
                bScArr[2].SetRelation(-0.5f, 1.5f);
                bScArr[3].SetRelation(0.5f, -0.5f);
                break;
            case "Z":
                currentMinoType = MinoType.ZMino;
                bScArr[0].SetRelation(-0.5f, -0.5f);
                bScArr[1].SetRelation(-0.5f, 0.5f);
                bScArr[2].SetRelation(0.5f, 0.5f);
                bScArr[3].SetRelation(0.5f, 1.5f);
                break;
            case "S":
                currentMinoType = MinoType.SMino;
                bScArr[0].SetRelation(-0.5f, 0.5f);
                bScArr[1].SetRelation(-0.5f, 1.5f);
                bScArr[2].SetRelation(0.5f, -0.5f);
                bScArr[3].SetRelation(0.5f, 0.5f);
                break;
            case "T":
                currentMinoType = MinoType.TMino;
                bScArr[0].SetRelation(-1.5f, -0.5f);
                bScArr[1].SetRelation(-0.5f, -0.5f);
                bScArr[2].SetRelation(-0.5f, 0.5f);
                bScArr[3].SetRelation(0.5f, -0.5f);
                break;
            case "O":
                currentMinoType = MinoType.OMino;
                bScArr[0].SetRelation(-0.5f, -0.5f);
                bScArr[1].SetRelation(-0.5f, 0.5f);
                bScArr[2].SetRelation(0.5f, -0.5f);
                bScArr[3].SetRelation(0.5f, 0.5f);
                break;
        }
        GetWorldPos();
        ResetPosAll();
    }

    //Mino의 위치를 이동, Block들도 따라옴 (GameManager가 호출)
    public void moveMino(string dir) {
        if(dir == "r")
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y, 0);
        else if(dir == "l")
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y, 0);
        else if(dir == "u")
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f, 0);
        else if(dir == "d")
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, 0);
        GetWorldPos();
        ResetPosAll();
    }

    //Block들을 회전시킴 (GameManager가 호출)
    public void rotateMino(string dir) {
        if (currentMinoType == MinoType.OMino)
            return;
        
        if(dir == "r") {
            for(int i=0; i < blockNum; i++)
                bScArr[i].RotateRelation("r");
        }
        if(dir == "l") {
            for(int i=0; i< blockNum; i++)
                bScArr[i].RotateRelation("l");
        }
        GetWorldPos();
        ResetPosAll();
    }

    //회전했을때의 Block들의 월드 좌표를 받아옴 (GameManager가 호출)
    public void GetRotateWorldPos(string dir) {
        for (int i = 0; i < blockNum; i++)
            rotateWorldPosArr[i] = bScArr[i].ReturnRotateWorldPos(dir, transform.position);
    }

    //현재 Block들의 월드 좌표를 받아옴
    void GetWorldPos() {
        for(int i=0; i < blockNum; i++)
            worldPosArr[i] = bScArr[i].ReturnWorldPos(transform.position);
    }

    //현재 Block들을 자신의 상대좌표로 이동시킴
    void ResetPosAll() {
        for(int i=0; i<blockNum; i++)
            bScArr[i].ResetPos(transform.position);
    }
}
