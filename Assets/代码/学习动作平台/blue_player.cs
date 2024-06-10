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

    List<string> textList = new List<string>();//�����ַ���,ͷ�ļ���Ҫ���using System.Collections.Generic;

    bool textFinish;//��֤û�����������ǰ��R������ִ����һ�����

    int num;
    void Awake()//awake�����ж����ʼ����������ʹ��
    {
        GetTextFromFile(textFile);//��ȡ�ı��ĵ�
        indext = 0;
        num = indext;
    }

    private void OnEnable()//��һ��ʼ��ʱ����ʾ��һ��,onenable��start֮ǰ����,��start����awake,awake��oneable֮ǰʹ��
    {
        /*textLable.text = textList[indext];
        indext++;*/
        StartCoroutine(SetTextUI());//����
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
            panal.gameObject.SetActive(false);//���Ի�������indextֵ����
            indext = 0;
            num = indext;
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && textFinish == true)
        {
            /*textLable.text = textList[indext];
            indext++;*/
            StartCoroutine(SetTextUI());//����
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
        textList.Clear();//����ĵ�
        indext = 0;//����Ϊ0
        num = indext;

        var lineData = file.text.Split('\n');//���ı������и�

        foreach (var line in lineData)
        {
            textList.Add(line);//��ÿһ�м��ص��б���
        }
    }
    IEnumerator SetTextUI()//Э��
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

        for (int i = 0; i < textList[indext].Length; i++)//�����ȡ�ַ�,[indext]��ǰ��,.length��ǰ�г���
        {
            textLable.text += textList[indext][i];//ÿ���ַ�
            num = indext;
            yield return new WaitForSeconds(textSpeeed);//��������һ��һ�����ͣ�͵�ʱ��
        }
        textFinish = true;
        indext++;
        num = indext;
    }
}
