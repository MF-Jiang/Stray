using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tokens : MonoBehaviour
{
    public GameObject Player;

    public Text textComponent;

    // Update is called once per frame
    void Update()
    {

        // 将数字显示在Text组件中
        textComponent.text = "Tokens Number: " + Player.GetComponent<Player>().tokensNum;
    }
}
