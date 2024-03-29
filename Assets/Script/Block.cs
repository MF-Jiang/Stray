using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IPointerDownHandler
{
    public bool hasCharacter = false;
    public GameObject character;

    public GameObject SummonBlock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (character != null) 
        {
            character.transform.localPosition = Vector3.zero;
            character.transform.rotation = Quaternion.identity;

            character.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100); 

            character.transform.localScale = new Vector3(1, 1, character.transform.localScale.z); ;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        /*if(!hasCharacter && SummonBlock.activeInHierarchy)
        {
            SpellingManager.Instance.SummonConfirm(transform);
        }*/

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!hasCharacter && SummonBlock.activeInHierarchy)
            {
                SpellingManager.Instance.SummonConfirm(transform);
            }
        }
    }
}
