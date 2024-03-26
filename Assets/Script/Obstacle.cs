using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Obstacle : MonoBehaviour
{
    // ���������ں� 9,20,12,15  (JUMP)
    public int[] ActionIndex = new int[] { 9, 20, 12, 15 };

    public GameObject Player;

    public GameObject SpellPanel;

    public GameObject Characters;
    public GameObject Blocks;

    public Transform fallPoint;

    public bool triggerable = true;

    public float height = 10f;
    public float leapingforce = 10f;

    private Rigidbody2D rbO;

    // Start is called before the first frame update
    void Start()
    {
        rbO = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpell();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��һ�δ���
        if(triggerable && collision.tag == "Player")
        {
            //Debug.Log("HERE");
            collision.gameObject.GetComponent<Player>().CouldMove = false;
            collision.gameObject.GetComponent<Player>().changeTarget(transform.position);
            SpellPanel.SetActive(true);


            
            int[] InitIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25 };

            Characters.GetComponent<Characters>().setCharacterSprite(InitIndex);
            Blocks.GetComponent<Blocks>().setBlockSprite(ActionIndex);

        }
        // �Ժ󴥷�
        if (!triggerable && collision.tag == "Player")
        {
            //��ֹͣ����
            collision.gameObject.GetComponent<Player>().CouldMove = false;
            collision.gameObject.GetComponent<Player>().changeTarget(transform.position);


            // JUMP ���ActionIndex���ǲ���9, 20, 12, 15
            if (ActionIndex[0] == 9 && ActionIndex[1] == 20 && ActionIndex[2] == 12 && ActionIndex[3] == 15)
            {
                //collision.gameObject.GetComponent<Player>().changeTarget(fallPoint.position);
                collision.gameObject.GetComponent<Player>().jumping = true;
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

                if(rb != null) 
                {
                    Debug.Log("JUMP");
                    Vector2 direction = (fallPoint.position - collision.transform.position).normalized;

                    Vector2 middlePoint = (collision.transform.position + fallPoint.position) / 2f;
                    middlePoint += Vector2.up * height;

                    Vector2 start = collision.transform.position;
                    Vector2 end = fallPoint.position;
                    float t = 0.5f; // �����м��Ĳ���tֵ
                    Vector2 bezierPoint = Mathf.Pow(1 - t, 2) * start + 2 * (1 - t) * t * middlePoint + Mathf.Pow(t, 2) * end;

                    // �������߷���
                    Vector2 curveDirection = (bezierPoint - (Vector2)collision.transform.position).normalized;

                    // �������ʹ��������ߵ��䵽Ŀ������
                    rb.velocity = curveDirection * leapingforce;

                    // Face the direction of movement
                    if (fallPoint.position.x < collision.transform.position.x)
                    {
                        collision.transform.localScale = new Vector3(-1, 1, 1); // Flip character to face left
                    }
                    else
                    {
                        collision.transform.localScale = new Vector3(1, 1, 1); // Flip character to face right
                    }

                }


            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!triggerable && collision.tag == "Player")
        {
            //��ֹͣ����
            collision.gameObject.GetComponent<Player>().CouldMove = false;
            collision.gameObject.GetComponent<Player>().changeTarget(transform.position);


            // JUMP ���ActionIndex���ǲ���9, 20, 12, 15
            if (ActionIndex[0] == 9 && ActionIndex[1] == 20 && ActionIndex[2] == 12 && ActionIndex[3] == 15)
            {
                //collision.gameObject.GetComponent<Player>().changeTarget(fallPoint.position);
                collision.gameObject.GetComponent<Player>().jumping = true;
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    Debug.Log("JUMP");
                    Vector2 direction = (fallPoint.position - collision.transform.position).normalized;

                    Vector2 middlePoint = (collision.transform.position + fallPoint.position) / 2f;
                    middlePoint += Vector2.up * height;

                    Vector2 start = collision.transform.position;
                    Vector2 end = fallPoint.position;
                    float t = 0.5f; // �����м��Ĳ���tֵ
                    Vector2 bezierPoint = Mathf.Pow(1 - t, 2) * start + 2 * (1 - t) * t * middlePoint + Mathf.Pow(t, 2) * end;

                    // �������߷���
                    Vector2 curveDirection = (bezierPoint - (Vector2)collision.transform.position).normalized;

                    // �������ʹ��������ߵ��䵽Ŀ������
                    rb.velocity = curveDirection * leapingforce;

                    // Face the direction of movement
                    if (fallPoint.position.x < collision.transform.position.x)
                    {
                        collision.transform.localScale = new Vector3(-1, 1, 1); // Flip character to face left
                    }
                    else
                    {
                        collision.transform.localScale = new Vector3(1, 1, 1); // Flip character to face right
                    }

                }


            }

        }
    }

    private void CheckSpell() 
    { 
        if(SpellPanel.activeInHierarchy)
        {
            // ��ȡBlocks�µ�����Block,�ж��ǲ���ȫ��������ĸ
            bool isAllHasCharacter = true;
            foreach (var block in Blocks.GetComponent<Blocks>().BlocksSprites)
            {
                if (!block.GetComponent<Block>().hasCharacter)
                {
                    isAllHasCharacter = false;
                }
            }


            if (isAllHasCharacter)
            {
                // ��ȡBlocks�µ�����Block����ĸ������
                List<int> answer = new List<int>();
                
                foreach (var block in Blocks.GetComponent<Blocks>().BlocksSprites)
                {
                    answer.Add(block.GetComponent<Block>().character.GetComponent<Character>().CharacterIndex);
                }
                // �ж��ǲ�����ȷ�ĵ��ʣ��Ա����к������ÿһλ�ǲ���һ���ģ�
                bool isCorrect = true;
                for (int i = 0; i < answer.Count; i++)
                {
                    if (answer[i] != ActionIndex[i])
                    {
                        Debug.Log("Answer Wrong");
                        isCorrect = false;
                    }
                }
                if (isCorrect)

                {
                    Debug.Log("Answer Correct");
                    if(Player.GetComponent<Player>().tokensNum >= answer.Count)
                    {
                        Player.GetComponent<Player>().tokensNum = Player.GetComponent<Player>().tokensNum - answer.Count;
                        triggerable = false;
                    }
                   
                    Player.GetComponent<Player>().CouldMove = true;
                    SpellPanel.SetActive(false);
                    
                }
                else
                {
                    Player.GetComponent<Player>().CouldMove = true;
                    SpellPanel.SetActive(false);
                }
            }

        }
    }

    private void OnDrawGizmos()
    {
        if (fallPoint != null)
        {
            // ���Ʊ���������
            Gizmos.color = Color.red;
            Vector2 start = transform.position;
            Vector2 end = fallPoint.position;
            Vector2 middlePoint = (start + end) / 2f;
            middlePoint += Vector2.up * height;
            Gizmos.DrawLine(start, middlePoint);
            Gizmos.DrawLine(middlePoint, end);
        }
    }
}
