using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public int WordLength = 0;
    public List<GameObject> BlocksSprites;
    public GameObject Block;

    public void setBlockSprite(int[] blockindex)
    {
        WordLength = blockindex.Length;

        for (int i = 0; i < WordLength; i++)
        {
            GameObject block = Instantiate(Block, new Vector3(0, 0, 0), Quaternion.identity);
            block.transform.SetParent(this.transform);
            block.transform.localPosition = new Vector3(i * 1.5f, 0, 0);
            BlocksSprites.Add(block);
        }
    }


}
