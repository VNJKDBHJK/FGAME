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
    IEnumerator AsyncLoadLevel(int scenceIndex)//协程
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenceIndex);//异部载入场景
        loadingScreen.SetActive(true);

        while (!operation.isDone)//确认载入已完成
        {
            float progress = operation.progress / 0.9f;//限制显示值的范围
            slider.value = progress;//显示到进度条上
            progressText.text = Mathf.FloorToInt(progress * 100f).ToString()+"%";//显示到数值上
            yield return null;//协程函数必加
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
