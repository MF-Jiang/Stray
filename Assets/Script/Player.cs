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

    public LayerMask gridLayer; // ����ָ�� Grid ���ڵĲ㼶
    public float raycastDistance = 10f; // ���ߵĳ���

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

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.down, Mathf.Infinity, gridLayer);

        if (hit.collider != null)
        {
            // ��ȡ��ײ���� Grid ��λ��
            targetPosition = hit.point;

            // ���λ����Ϣ����Ҳ���Խ�����������߼�
            //Debug.Log("Grid Position: " + targetPosition);
        }

        //targetPosition = new Vector2(mousePosition.x, transform.position.y);

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
}
