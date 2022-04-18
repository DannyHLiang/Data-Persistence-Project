using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class IntroScreen : MonoBehaviour
{
    public InputField userName;
    public Text HighScore;

    private void Start()
    {
        UiManager.Instance.LoadScore();
        Debug.Log(UiManager.Instance.Name);
        Debug.Log(UiManager.Instance.Score);
        HighScore.text = $"HighScore: {UiManager.Instance.Name} {UiManager.Instance.Score}";
    }

    public void StartButton()
    {
        if(userName.text != "")
        {
            UiManager.Instance.NewUser = userName.text;
            SceneManager.LoadScene(1);

        }
    }

    public void Exit()
    {
        UiManager.Instance.SaveScore();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        
        #else
        Application.Quit();
        #endif
    }
}
