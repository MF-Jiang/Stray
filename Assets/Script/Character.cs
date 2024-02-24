using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //26����ĸ��ͼƬ
    public Sprite[] CharacterSprites;

    public int CharacterIndex;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        CharacterIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
       //��ͼƬ���ɵ�CharacterIndex��ͼƬ
        sr.sprite = CharacterSprites[CharacterIndex];
    }
}
