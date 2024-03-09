using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // ���������ں� 9,20,12,15  (JUMP)
    public int[] ActionIndex = new int[] { 9, 20, 12, 15 };

    public GameObject Player;

    public GameObject SpellPanel;

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
        CheckSpell();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��һ�δ���
        if(triggerable && collision.tag == "Player")
        {
            //Debug.Log("HERE");
            collision.gameObject.GetComponent<Player>().CouldMove = false;
            SpellPanel.SetActive(true);


            
            int[] InitIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25 };

            Characters.GetComponent<Characters>().setCharacterSprite(InitIndex);
            Blocks.GetComponent<Blocks>().setBlockSprite(ActionIndex);

        }
        // �Ժ󴥷�
        if (!triggerable && collision.tag == "Player")
        { 
            
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
                        isCorrect = false;
                    }
                }
                if (isCorrect)
                {
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
}
