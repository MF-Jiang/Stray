using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{

    // һ��list�����洢ƴд��������Ҫ����ĸ,list�ĳ�����WordLength
    public int WordLength = 0;
    public List<GameObject> CharacterSprites;
    public GameObject Character;

    public void setCharacterSprite(int[] charindex)
    {
        CharacterSprites.Clear();
        //�ݻٸ�����������������
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 1; i < children.Length; i++)
        {
            // �ݻ�������
            Destroy(children[i].gameObject);
        }

        WordLength = charindex.Length;

        // ��charindex��������������
        System.Random rng = new System.Random();
        for (int i = WordLength - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            int temp = charindex[i];
            charindex[i] = charindex[j];
            charindex[j] = temp;
        }

        // ����WordLength����ĸ
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
