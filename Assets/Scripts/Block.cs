using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    float relationalX;
    float relationalY;

    // Start is called before the first frame update
    void Start() {

    }

    public void SetRelation(float x, float y) {
        relationalX = x;
        relationalY = y;
    }

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

    public void ResetPos(Vector3 mino) {
        transform.position = new Vector3(mino.x + relationalX, mino.y + relationalY, 0);
    }
    

}
