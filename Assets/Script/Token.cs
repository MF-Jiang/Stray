using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public bool used = false;

    private void Start()
    {
        //创建时读取文件改变used和显示情况
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            collision.GetComponent<Player>().tokensNum++;

            Destroy(gameObject);
        }
    }
}
