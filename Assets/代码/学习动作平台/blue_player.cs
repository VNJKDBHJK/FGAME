using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class blue_player : MonoBehaviour
{
    public GameObject panal;
    private bool ishear;
    //123
    public TMP_Text textLable;
    public Image faceImage;

    public TextAsset textFile;
    public int indext;
    public float textSpeeed;

    public Sprite face01, face02;

    List<string> textList = new List<string>();//储存字符串,头文件需要添加using System.Collections.Generic;

    bool textFinish;//保证没有完整输出完前按R键不会执行下一条语句

    int num;
    void Awake()//awake在所有对象初始化后立即被使用
    {
        GetTextFromFile(textFile);//获取文本文档
        indext = 0;
        num = indext;
    }

    private void OnEnable()//在一开始的时候显示第一行,onenable在start之前调用,将start换成awake,awake在oneable之前使用
    {
        /*textLable.text = textList[indext];
        indext++;*/
        StartCoroutine(SetTextUI());//调用
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ishear = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        ishear = false;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && indext == textList.Count)
        {
            panal.gameObject.SetActive(false);//当对话结束后将indext值重置
            indext = 0;
            num = indext;
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && textFinish == true)
        {
            /*textLable.text = textList[indext];
            indext++;*/
            StartCoroutine(SetTextUI());//调用
        }
        //321
        if (ishear)
        {
            panal.SetActive(true);
        }
        else
        {
            panal.SetActive(false);
            indext =num;
        }
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();//清空文档
        indext = 0;//序列为0
        num = indext;

        var lineData = file.text.Split('\n');//将文本按行切割

        foreach (var line in lineData)
        {
            textList.Add(line);//将每一行加载到列表当中
        }
    }
    IEnumerator SetTextUI()//协程
    {
        textFinish = false;
        textLable.text = "";
        switch (textList[indext].Trim().ToString())
        {
            case "A":
                faceImage.sprite = face01;
                indext += 1;
                num=indext;
                break;
            case "B":
                faceImage.sprite = face02;
                indext += 1;
                num = indext;
                break;

        }

        for (int i = 0; i < textList[indext].Length; i++)//逐个获取字符,[indext]当前行,.length当前行长度
        {
            textLable.text += textList[indext][i];//每个字符
            num = indext;
            yield return new WaitForSeconds(textSpeeed);//控制字体一个一个输出停滞的时间
        }
        textFinish = true;
        indext++;
        num = indext;
    }
}
