using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class HighScores : MonoBehaviour
{
    public PlayerData[] data;
    private string[] names = new string[8];
    private int[] scores = new int[8];
    public TextMeshProUGUI[] UGUIs;
    private int length;
    private void Start()
    {
        UpdateArrays();
    }
    private void UpdateArrays()
    {
        for (int i = 0; i < data.Length; i++)
        {
            switch(data[i].gameName)
            {
                case "Basket": //0
                    length = 4;
                    AssignArrayElements(i); //0, 1, 2, 3
                    break;
                case "Blocks": //1
                    length = 8;
                    AssignArrayElements(i, 4); //4, 5, 6, 7
                    break;
            }
        }
        StartCoroutine("UpdateUI");
    }
    private IEnumerator UpdateUI()
    {
        yield return new WaitForSeconds(1f);
        RankScores(0);
        RankScores(4);
        for (int i = 0; i < data.Length; i++)
        {
            switch(data[i].gameName)
            {
                case "Basket": //0
                    for (int j = 0; j < 3; j++)
                    {
                        UGUIs[j].text = names[j]; //0, 1, 2 //0, 1, 2
                        UGUIs[j + 3].text = scores[j] + ""; //3, 4, 5 //0, 1, 2
                    }
                    break;
                case "Blocks": //1
                    for (int j = 6; j < 9; j++)
                    {
                        UGUIs[j].text = names[j - 2]; //6, 7, 8 //4, 5, 6
                        UGUIs[j + 3].text = scores[j - 2] + ""; //9, 10, 11 //4, 5, 6
                    }
                    break;
            }
        }
    }
    private void AssignArrayElements(int i, int k = 0)
    {
        for (int j = length - 4; j < length; j++)
        {
            names[j] = data[i].playerName[j - k];
            scores[j] = data[i].highScore[j - k];
        }
    }
    private void RankScores(int start)
    {
        System.Array.Sort(scores, names, start, 4);
        System.Array.Reverse(names, start, 4);
        System.Array.Reverse(scores, start, 4);
    }
    private void CheckHighScore()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Basket":
                data[0].highScore[3] = PlayerLevel.instance.score;
                break;
            case "Blocks":
                data[1].highScore[3] = PlayerLevel.instance.score;
                break;
        }
    }
}
