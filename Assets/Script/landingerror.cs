using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landingerror : MonoBehaviour
{
    private Rigidbody2D rbO;

    // Start is called before the first frame update
    void Start()
    {
        rbO = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" && collision.gameObject.GetComponent<Player>().jumping)
        {
            collision.gameObject.GetComponent<Player>().jumping = false;
            collision.gameObject.GetComponent<Player>().changeTarget(collision.transform.position);
            collision.gameObject.GetComponent<Player>().CouldMove = true;
        }
    }
}
