using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //참조변수
    public GameObject mino;
    Mino minoS;

    //변수

    // Start is called before the first frame update
    void Awake()
    {
        minoS = mino.GetComponent<Mino>();
        minoS.SetPosition(new Vector3(4.5f, 1.5f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
