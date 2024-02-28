using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float zoomSize;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Character>().type == CharacterType.Normal) 
        {
            transform.localScale = new Vector3(zoomSize, zoomSize, 1.0f);
        }
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Character>().type == CharacterType.Normal) 
        {
            transform.localScale = Vector3.one;

        }
            
    }
}

