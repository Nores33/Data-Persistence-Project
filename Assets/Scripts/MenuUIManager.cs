using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]

public class MenuUIManager : MonoBehaviour
{
    public InputField playerNameInput;
    public TextMeshProUGUI bestScoreText;
    public string playerName;

    void Start()
    {
        playerNameInput.onEndEdit.AddListener(delegate { AddPlayerName(playerNameInput.text); });
        bestScoreText.text ="Best Score: " + PersistenceManager.Instance.highScorePlayer + ": " + PersistenceManager.Instance.highScore;
    }

    public void AddPlayerName(string player)
    {
        playerName = player;
        Debug.Log(playerName);
        PersistenceManager.Instance.player = playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
