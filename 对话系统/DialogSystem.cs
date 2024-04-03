using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.uI;
public class DialogSystem : MonoBehaviour
[Header("UI组件")]
public Text textLabel;
public Image faceImage;

[Header("文本文件")]
public TextAsset textFile;
public int index;
public float textSpeed;

[Header("头像")]
public Sprite face01, face02;

bool textFinished;
bool cancelTyping;

List<string> textList = new List<string>();

void Awake(){
    GetTextFormFile(textFile);
}

privete void OnEnable(){
    // textLabel.text = textList[index];
    // index++;
    textFinished = true;
    StartCoroutine(setTextUI);
}

// Update is called once per framevoid Update()
void Update(){
    if(Input.GetKeyDown(KeyCode.R) && index == textList.Count){
        gameObject.SetActive(false);
        index = 0;
        return;
    }
    // if(Input.GetKeyDown(KeyCode.R) && textFinished){
    //     // textLabel.text=textList[index];
    //     // index++;
    //     StartCoroutine(setTextUI);
    // }
    if(Input. GetKeyDown(KeyCod.R)){
        if(textFinished && !cancelTyping){
            StartCoroutine(SetTextUI());
        }else if (!textFinished){
            cancelTyping = true;
        }
    }
}

void GetTextFormFile(TextAsset file){
    textList.Clear();
    index = 0;

    var lineDate = file.text.Split('\n');

    foreach(var line in lineDate){
        textList.Add(line);
    }
}

IEnumerator SetTextUI(){
    textFinished= fakse;
    textLabel.text = "";

    switch(textList{index}){
        case"A":
            faceImage.sprite = face01;
            index++;
            break;
        case"B":
            faceImage.sprite = face02;
            index++;
            break;        
    }

    // for(int i=0; i<tetxtList[index],Length; i++){
    //     textLabel.text += textList[index][i];

    //     yield return new WaitForSeconds(textSpeed);
    // }
    int letter = 0;
    while(!cancelTyping && letter< textList[index].Length-1){
        textLabel.text += textList[index][letter];
        letter++;
        yield return new WaitForSeconds(textSpeed);
    }
    textLabel.text = textList[index];
    cancelTyping = false;
    textFinished = true;
    index++;
}