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

        // ��������ʾ��Text�����
        textComponent.text = "Tokens Number: " + Player.GetComponent<Player>().tokensNum;
    }
}
