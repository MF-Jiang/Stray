using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public int WordLength = 0;
    public List<GameObject> BlocksSprites;
    public GameObject Block;
    public GameObject Spell;

    public void setBlockSprite(int[] blockindex)
    {
        BlocksSprites.Clear();
        //摧毁该物体下所有子物体
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 1; i < children.Length; i++)
        {
            // 摧毁子物体
            Destroy(children[i].gameObject);
        }

        Spell.GetComponent<SpellingManager>().Blocks.Clear();


        WordLength = blockindex.Length;

        for (int i = 0; i < WordLength; i++)
        {
            GameObject block = Instantiate(Block, new Vector3(0, 0, 0), Quaternion.identity);
            block.transform.SetParent(this.transform);
            block.transform.localPosition = new Vector3(i * 1.5f, 0, 0);

            Spell.GetComponent<SpellingManager>().Blocks.Add(block);


            BlocksSprites.Add(block);
        }
    }


}
