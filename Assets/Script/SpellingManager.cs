using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpellingManager : MonoSingleton<SpellingManager>
{
    // 获取block的数组
    public List<GameObject> Blocks;

    public GameObject waitCharacter;

    public GameObject ArrowPrefab;
    private GameObject Arrow;

    public Transform canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            DestroyArrow();
            waitCharacter = null;
            foreach (var block in Blocks)
            {
                block.GetComponent<Block>().SummonBlock.SetActive(false);
            }
        }
    }

    public void SummonRequest(GameObject _Character)
    {
        bool hasEmpty = false;

        foreach (var block in Blocks)
        {
            if(block.GetComponent<Block>().hasCharacter == false)
            {
                hasEmpty = true;
                // 让这个block发光
                block.GetComponent<Block>().SummonBlock.SetActive(true);
            }
        }

        if (hasEmpty)
        {
            waitCharacter = _Character;
            CreatArrow(_Character.transform, ArrowPrefab);
        }
    }

    public void SummonConfirm(Transform _block)
    {
        Summon(waitCharacter, _block);
        foreach (var block in Blocks)
        {
            block.GetComponent<Block>().SummonBlock.SetActive(false);
        }
    }

    public void Summon(GameObject _waitCharacter, Transform _block)
    {
        

        // 复制一个waitCharacter
        GameObject Copy = Instantiate(_waitCharacter);
        


        Copy.transform.SetParent(_block);
        Copy.transform.localPosition = Vector3.zero;
        Copy.GetComponent<Character>().type = CharacterType.inBlock;
        _block.GetComponent<Block>().hasCharacter = true;
        _block.GetComponent<Block>().character = Copy;

        /*Transform transformToReset = _block.GetComponent<Block>().character.transform;
        transformToReset.position = Vector3.zero;
        transformToReset.localScale = Vector3.one;*/


        /*_waitCharacter.transform.SetParent(_block);
        _waitCharacter.transform.localPosition = Vector3.zero;
        _waitCharacter.GetComponent<Character>().type = CharacterType.inBlock;
        _block.GetComponent<Block>().hasCharacter = true;*/


        //_block.GetComponent<Block>().character = _waitCharacter
        DestroyArrow();


    }

    public void CreatArrow(Transform _startPoint, GameObject _prefab)
    { 
        DestroyArrow();
        //Debug.Log(_startPoint);
        Arrow = GameObject.Instantiate(_prefab, canvas);
        Arrow.GetComponent<Arrow>().SetStartPoint(new Vector2(_startPoint.position.x, _startPoint.position.y));
    }

    public void DestroyArrow()
    {
        Destroy(Arrow);
    }
}
