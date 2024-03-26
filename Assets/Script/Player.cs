using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;
    private Vector2 targetPosition;

    public float tokensNum = 99999;

    public float moveSpeed = 5f;

    public bool jumping = false;

    public bool CouldMove = true;

    public bool onfloor = true;

    public LayerMask gridLayer; // 用于指定 Grid 所在的层级
    public float raycastDistance = 10f; // 射线的长度

    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CouldMove)
        {
            MoveToClickedPosition();
        }
        if (CouldMove)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime));
        }
        else
        {
            targetPosition = transform.position;
        }
        
    }

    void MoveToClickedPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        hit = Physics2D.Raycast(mousePosition, Vector2.down, Mathf.Infinity, gridLayer);

        if (onfloor == false)
        {
            if (hit.collider != null)
            {
                // 获取碰撞到的 Grid 的位置
                targetPosition = hit.point;

                // 输出位置信息，你也可以将其用于你的逻辑
                //Debug.Log("Grid Position: " + targetPosition);
            }

            if (targetPosition.y > transform.position.y)
            {
                targetPosition.y = transform.position.y;
            }
        }
        else 
        {
            targetPosition = new Vector2(mousePosition.x, transform.position.y);
        }

        // Face the direction of movement
        if (targetPosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip character to face left
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1); // Flip character to face right
        }

        
    }

    public void changeTarget(Vector2 stopPosition) 
    {
        targetPosition = new Vector2(stopPosition.x, transform.position.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grid")
        {
            //Debug.Log("1");
            CouldMove = true;
            jumping = false;
            onfloor = true;
            rb.gravityScale = 1.0f;
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Grid")
        {
            //Debug.Log("2");
            /*CouldMove = true;
            jumping = false;*/
            onfloor = true;
            rb.gravityScale = 1.0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grid")
        {
            //Debug.Log("2");
            /*CouldMove = true;
            jumping = false;*/
            targetPosition.y = hit.point.y;
            onfloor = false;

            //玩家在非跳跃状态下离开地面（下落状态），适当增加重力
            if(jumping == false)
            {
                rb.gravityScale = 15f;
            }
        }
    }
}
