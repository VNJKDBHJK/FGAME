using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class menu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressText;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel(int scenceIndex)
    {
        StartCoroutine(AsyncLoadLevel(scenceIndex));
    }
    IEnumerator AsyncLoadLevel(int scenceIndex)//Э��
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenceIndex);//�첿���볡��
        loadingScreen.SetActive(true);

        while (!operation.isDone)//ȷ�����������
        {
            float progress = operation.progress / 0.9f;//������ʾֵ�ķ�Χ
            slider.value = progress;//��ʾ����������
            progressText.text = Mathf.FloorToInt(progress * 100f).ToString()+"%";//��ʾ����ֵ��
            yield return null;//Э�̺����ؼ�
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
