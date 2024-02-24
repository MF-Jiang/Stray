using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //26¸ö×ÖÄ¸µÄÍ¼Æ¬
    public Sprite[] CharacterSprites;

    public int CharacterIndex;

    //private SpriteRenderer sr;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       //½±Í¼Æ¬»»³ÉµÚCharacterIndexÕÅÍ¼Æ¬
        //sr.sprite = CharacterSprites[CharacterIndex];
        img.sprite = CharacterSprites[CharacterIndex];
    }

    public void SetCharacterIndex(int index)
    {
        CharacterIndex = index;
    }
}
