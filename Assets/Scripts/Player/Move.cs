using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float vetical = 0.1f;
    public float horizontal = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start moveing");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            this.gameObject.transform.position += new Vector3(0f, vetical, 0f);
        if (Input.GetKey(KeyCode.DownArrow))
            this.gameObject.transform.position += new Vector3(0f, -1 * vetical, 0f);
        if (Input.GetKey(KeyCode.RightArrow))
            this.gameObject.transform.position += new Vector3(horizontal, 0f, 0f);
        if (Input.GetKey(KeyCode.LeftArrow))
            this.gameObject.transform.position += new Vector3(-1 * horizontal, 0f, 0f);
    }
}
