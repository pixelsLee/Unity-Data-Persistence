using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public TextMeshProUGUI bestSore;
    public TMP_InputField playerInput;
    void Start()
    {
        bestSore.text = $"Best Score {MenuManager.Instance.bestPlayerName}: {MenuManager.Instance.bestScore}";
        playerInput.text = MenuManager.Instance.playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); // Quit Editor Play Mode
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void EnterName(string value)
    {
        // 设置玩家名称
        MenuManager.Instance.playerName = value;
    }
}
