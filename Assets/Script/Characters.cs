using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{

    // 一个list用来存储拼写单词所需要的字母,list的长度是WordLength
    public int WordLength = 0;
    public List<GameObject> CharacterSprites;
    public GameObject Character;

    public void setCharacterSprite(int[] charindex)
    {
        CharacterSprites.Clear();
        //摧毁该物体下所有子物体
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 1; i < children.Length; i++)
        {
            // 摧毁子物体
            Destroy(children[i].gameObject);
        }

        WordLength = charindex.Length;

        // 把charindex这个数组随机打乱
        System.Random rng = new System.Random();
        for (int i = WordLength - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            int temp = charindex[i];
            charindex[i] = charindex[j];
            charindex[j] = temp;
        }

        // 制作WordLength个字母
        for (int i = 0; i < WordLength; i++)
        {
            GameObject character = Instantiate(Character, new Vector3(0, 0, 0), Quaternion.identity);
            character.transform.SetParent(this.transform);
            character.transform.localPosition = new Vector3(i * 1.5f, 0, 0);

            character.transform.GetComponent<Character>().SetCharacterIndex(charindex[i]);
            
            CharacterSprites.Add(character);
        }
    }


}
