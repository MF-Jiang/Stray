using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public bool used = false;

    private void Start()
    {
        //����ʱ��ȡ�ļ��ı�used����ʾ���
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
