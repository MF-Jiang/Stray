using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // ���������ں� 9,20,12,15
    public int[] ActionIndex = new int[] { 9, 20, 12, 15 };

    public GameObject Characters;

    public bool triggerable = true;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(triggerable && collision.tag == "Player")
        {
            //Debug.Log("HERE");
            collision.gameObject.GetComponent<Player>().CouldMove = false;

            Characters.GetComponent<Characters>().setCharacterSprite(ActionIndex);


        }
    }
}
