using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class HighScores : MonoBehaviour, System.IComparable
{
    public PlayerData[] data;
    private string[] names = new string[6];
    private int[] scores = new int[6];
    public TextMeshProUGUI[] UGUIs;
    private void Start()
    {
        Debug.Log("names length = " + names.Length);
        Debug.Log("scores length = " + scores.Length);
        for (int i = 0; i < data.Length; i++)
        {
            switch(data[i].gameName)
            {
                case "Basket": //0, 1, 2
                    AssignArrayElements(i);
                    break;
                case "Blocks": //3, 4, 5
                    AssignArrayElements(i);
                    break;
            }
        }
        
        StartCoroutine("DelayedStart");
    }
    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1f);
        RankScores(0);
        RankScores(3);
        for (int i = 0; i < data.Length; i++)
        {
            switch(data[i].gameName)
            {
                case "Basket": //0, 1, 2
                    UGUIs[i].text = names[i];
                    UGUIs[i + 3].text = scores[i] + "";
                    break;
                case "Blocks": //3, 4, 5
                    UGUIs[i + 3].text = names[i];
                    UGUIs[i + 6].text = scores[i] + "";
                    break;
            }
        }
        
    }
    private void AssignArrayElements(int i)
    {
        names[i] = data[i].playerName;
        scores[i] = data[i].highScore;
    }
    private void RankScores(int i)
    {
        System.Array.Sort(names, scores, i, 3);
        System.Array.Reverse(names);
        System.Array.Reverse(scores);
    }
    private void CheckHighScore()
    {
        switch (SceneManager.GetActiveScene().ToString())
        {
            case "Basket":
            for (int i = 3; i > 0; i--)
            {
                CompareTo(scores[i]);
            }
                break;
            case "Blocks":
            for (int i = 3; i < data.Length; i++)
            {
            
            }
                break;
        }
    }

    public int CompareTo(object obj)
    {
        return PlayerLevel.instance.score.CompareTo(obj);
    }
}
