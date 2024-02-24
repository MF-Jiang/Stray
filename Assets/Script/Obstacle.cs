using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // 动作数组内涵 9,20,12,15  (JUMP)
    public int[] ActionIndex = new int[] { 9, 20, 12, 15 };

    public GameObject Characters;
    public GameObject Blocks;

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
            Blocks.GetComponent<Blocks>().setBlockSprite(ActionIndex);

        }
    }
}
