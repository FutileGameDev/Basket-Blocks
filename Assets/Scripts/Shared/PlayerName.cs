using UnityEngine;
using System;
using System.Text.RegularExpressions;
using TMPro;


public class PlayerName : MonoBehaviour
{
    public GameObject inputMenu;
    public GameObject pauseButton;
    private string playerInput;
    private int index;
    public PlayerData[] data;
    public TextMeshProUGUI warning;
    public TMP_InputField inputField;
    void Start()
    {
        Time.timeScale = 0f;
        //Menu.OnGameOver += CheckHighScore();
    }
    void OnDestroy()
    {
        //Menu.OnGameOver -= CheckHighScore();
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
            data[index].playerName = playerInput;
            pauseButton.SetActive(true);
            inputMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            warning.text = "please enter 1 to 16 letters";
        }
    }
}
