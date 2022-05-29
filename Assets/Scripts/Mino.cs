using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino : MonoBehaviour
{
    //참조변수
    public GameObject block;
    GameObject block1;
    GameObject block2;
    GameObject block3;
    GameObject block4;
    Block bScr1;
    Block bScr2;
    Block bScr3;
    Block bScr4;


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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector3 position) {
        transform.position = position;
    }

    public void MakeMino(string name) {
        block1 = Instantiate(block, transform.position, Quaternion.identity);
        block2 = Instantiate(block, transform.position, Quaternion.identity);
        block3 = Instantiate(block, transform.position, Quaternion.identity);
        block4 = Instantiate(block, transform.position, Quaternion.identity);
        bScr1 = block1.GetComponent<Block>();
        bScr2 = block2.GetComponent<Block>();
        bScr3 = block3.GetComponent<Block>();
        bScr4 = block4.GetComponent<Block>();

        switch (name) {
            case "I":
                currentMinoType = MinoType.IMino;
                bScr1.SetRelation(-1.5f, 0.5f);
                bScr2.SetRelation(-0.5f, 0.5f);
                bScr3.SetRelation(0.5f, 0.5f);
                bScr4.SetRelation(1.5f, 0.5f);
                break;
            case "J":
                currentMinoType = MinoType.JMino;
                bScr1.SetRelation(-0.5f, -0.5f);
                bScr2.SetRelation(0.5f, -0.5f);
                bScr3.SetRelation(0.5f, 0.5f);
                bScr4.SetRelation(0.5f, 1.5f);
                break;
            case "L":
                currentMinoType = MinoType.LMino;
                bScr1.SetRelation(-0.5f, -0.5f);
                bScr2.SetRelation(-0.5f, 0.5f);
                bScr3.SetRelation(-0.5f, 1.5f);
                bScr4.SetRelation(0.5f, -0.5f);
                break;
            case "Z":
                currentMinoType = MinoType.ZMino;
                bScr1.SetRelation(-0.5f, -0.5f);
                bScr2.SetRelation(-0.5f, 0.5f);
                bScr3.SetRelation(0.5f, 0.5f);
                bScr4.SetRelation(0.5f, 1.5f);
                break;
            case "S":
                currentMinoType = MinoType.SMino;
                bScr1.SetRelation(-0.5f, 0.5f);
                bScr2.SetRelation(-0.5f, 1.5f);
                bScr3.SetRelation(0.5f, -0.5f);
                bScr4.SetRelation(0.5f, 0.5f);
                break;
            case "T":
                currentMinoType = MinoType.TMino;
                bScr1.SetRelation(-1.5f, -0.5f);
                bScr2.SetRelation(-0.5f, -0.5f);
                bScr3.SetRelation(-0.5f, 0.5f);
                bScr4.SetRelation(0.5f, -0.5f);
                break;
            case "O":
                currentMinoType = MinoType.OMino;
                bScr1.SetRelation(-0.5f, -0.5f);
                bScr2.SetRelation(-0.5f, 0.5f);
                bScr3.SetRelation(0.5f, -0.5f);
                bScr4.SetRelation(0.5f, 0.5f);
                break;
        }
        ResetPosAll();
    }

    void ResetPosAll() {
        bScr1.ResetPos(transform.position);
        bScr2.ResetPos(transform.position);
        bScr3.ResetPos(transform.position);
        bScr4.ResetPos(transform.position);
    }

    public void moveMino(string dir) {
        switch (dir) {
            case "r":
                transform.position = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                ResetPosAll();
                break;
            case "l":
                transform.position = new Vector3(transform.position.x - 1f, transform.position.y, 0);
                ResetPosAll();
                break;
            case "u":
                transform.position = new Vector3(transform.position.x, transform.position.y + 1f, 0);
                ResetPosAll();
                break;
            case "d":
                transform.position = new Vector3(transform.position.x, transform.position.y - 1f, 0);
                ResetPosAll();
                break;
        }
    }

    public void rotateMino(string dir) {
        if (currentMinoType == MinoType.OMino)
            return;
        switch (dir) {
            case "r":
                bScr1.RotateRelation("r");
                bScr2.RotateRelation("r");
                bScr3.RotateRelation("r");
                bScr4.RotateRelation("r");
                ResetPosAll();
                break;
            case "l":
                bScr1.RotateRelation("l");
                bScr2.RotateRelation("l");
                bScr3.RotateRelation("l");
                bScr4.RotateRelation("l");
                ResetPosAll();
                break;
        }
    }
}
