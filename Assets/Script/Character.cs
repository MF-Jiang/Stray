using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //26¸ö×ÖÄ¸µÄÍ¼Æ¬
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
       //½±Í¼Æ¬»»³ÉµÚCharacterIndexÕÅÍ¼Æ¬
        sr.sprite = CharacterSprites[CharacterIndex];
    }
}
