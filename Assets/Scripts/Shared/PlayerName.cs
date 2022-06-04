using UnityEngine;
using System;

using System.Text.RegularExpressions;
using TMPro;


public class PlayerName : MonoBehaviour
{
    public GameObject inputMenu;
    public GameObject pauseButton;
    private string playerInput;
    private string game;
    private int index;
    public PlayerData[] data;
    public TextMeshProUGUI warning;
    public TMP_InputField inputField;
    void Start()
    {
        Menu.OnGameOver += GetScene;
    }
    void OnDestroy()
    {
        Menu.OnGameOver -= GetScene;
    }
    private void GetScene(string sceneName)
    {
        game = sceneName;
        index = sceneName == "Baskets" ? 0 : 1;
        CompareScore();
    }
    private void CompareScore()
    {
        switch(index)
        {
            case 0:
                if(PlayerLevel.instance.score > data[0].highScore[2])
                {
                    inputMenu.SetActive(true);
                }
                else
                {
                    Menu.instance.PlayGame("Menu");
                }
                break;
            case 1:
                if(PlayerLevel.instance.score > data[1].highScore[2])
                {
                    inputMenu.SetActive(true);
                }
                else
                {
                    Menu.instance.PlayGame("Menu");
                }
                break;
        }
    }
    
    public void GetInput()
    {
        playerInput = inputField.text;
        CleanInput(playerInput);
        SetName();
    }
    static string CleanInput(string strIn)
    {
        // Replace invalid characters with empty strings.
        try 
        {
           return Regex.Replace(strIn, @"[^\w]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
        }
        // If we timeout when replacing invalid characters,
        // we should return Empty.
        catch (RegexMatchTimeoutException) {
           return String.Empty;
        }
    }
    void SetName()
    {
        if(playerInput.Length > 0 && playerInput.Length <= 16 && Regex.IsMatch(playerInput, @"[a-zA-Z]"))
        {
            data[index].playerName[3] = playerInput;
            data[index].highScore[3] = PlayerLevel.instance.score;
            Menu.instance.PlayGame("Menu");
            Time.timeScale = 1f;
        }
        else
        {
            warning.text = "please enter 1 to 16 letters";
        }
    }
}
