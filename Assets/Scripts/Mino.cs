using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino : MonoBehaviour
{
    public GameObject block;
    GameObject block1;
    GameObject block2;
    GameObject block3;
    GameObject block4;

    // Start is called before the first frame update
    void Start()
    {
        block1 = Instantiate(block, transform.position + new Vector3(-1.5f, 0.5f, 0), Quaternion.identity);
        block2 = Instantiate(block, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.identity);
        block3 = Instantiate(block, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
        block4 = Instantiate(block, transform.position + new Vector3(1.5f, 0.5f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector3 position) {
        transform.position = position;
    }
}
