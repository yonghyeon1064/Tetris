using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    float relationalX;
    float relationalY;

    //Mino가 호출
    public void SetRelation(float x, float y) {
        relationalX = x;
        relationalY = y;
    }

    //Mino가 호출
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

    //Mino가 호출
    public void ResetPos(Vector3 mino) {
        transform.position = new Vector3(mino.x + relationalX, mino.y + relationalY, 0);
    }

    //Mino가 호출
    public Vector3 ReturnWorldPos(Vector3 center) {
        return new Vector3(center.x + relationalX, center.y + relationalY, 0);
    }
    

}
