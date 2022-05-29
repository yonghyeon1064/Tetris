using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    float relationalX;
    float relationalY;

    //Block의 Mino에 대한 상대좌표 설정 (Mino가 호출)
    public void SetRelation(float x, float y) {
        relationalX = x;
        relationalY = y;
    }

    //Mino 좌표를 기준으로 상대좌표를 90도 회전 (Mino가 호출)
    public void RotateRelation(string dir) {
        float temp;
        switch (dir) {
            case "r":
                temp = relationalY;
                relationalY = -1 * relationalX;
                relationalX = temp;
                break;
            case "l":
                temp = relationalX;
                relationalX = -1 * relationalY;
                relationalY = temp;
                break;
        }
    }

    //현재의 상대좌표로 Block을 이동 (Mino가 호출)
    public void ResetPos(Vector3 mino) {
        transform.position = new Vector3(mino.x + relationalX, mino.y + relationalY, 0);
    }

    //현재의 상대좌표를 월드좌표로 바꿔 반환 (Mino가 호출)
    public Vector3 ReturnWorldPos(Vector3 center) {
        return new Vector3(center.x + relationalX, center.y + relationalY, 0);
    }

    //회전했을 때의 상대좌표를 월드좌표로 바꿔 반환 (Mino가 호출)
    public Vector3 ReturnRotateWorldPos(string dir, Vector3 center) {
        float x, y;
        if(dir == "r")
            return new Vector3(center.x + relationalY, center.y + relationalX * -1f);
        else if(dir == "l")
            return new Vector3(center.x + relationalY * -1f, center.y + relationalX);
        Debug.Log("Wrong input to ReturnRotateWorldPos() in Block.cs");
        return center;
    }
    

}
