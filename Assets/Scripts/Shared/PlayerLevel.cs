using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class PlayerLevel : MonoBehaviour
{
    [MenuItem("PlayerData/DeletePlayerPrefs")]
    static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public Slider experienceMeter;
    public TextMeshProUGUI playerLevelTMP;
    public TextMeshProUGUI levelLoaded;
    public TextMeshProUGUI scoreCountTMP;
    public static int currentExp;
    public static int lifetimeExp;
    public static int expNeeded;
    public static int playerLevel = 0;
    public int score;
    float duration = 2.0f;
    float startTime;
    private float t = 0f;
    private const float e = 2.71828f;
    private bool firstStart;
    public static PlayerLevel instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerLevel = PlayerPrefs.GetInt("playerLevel", playerLevel);
        firstStart = playerLevel == 0 ? true : false;
        if(firstStart)
        {
            playerLevel = 1;
            PlayerPrefs.SetInt("playerLevel", playerLevel);
            expNeeded = 10;
            PlayerPrefs.SetInt("expNeeded", expNeeded);
        }
        else
        {
            expNeeded = PlayerPrefs.GetInt("expNeeded", expNeeded);
            currentExp = PlayerPrefs.GetInt("currentExp", currentExp);
            levelLoaded.text = "welcome back";
            Invoke("LevelRestored", 3f);
        }
        playerLevelTMP.text = playerLevel + "";
        experienceMeter.maxValue = expNeeded;
        experienceMeter.value = currentExp;
    }
    void Update()
    {
        UpdateExpBar(); 
    }
    public void UpdateExpBar()
    {
        Debug.Log("UpdateExpBar called");
        if(expNeeded >= currentExp && !IsInvoking("NextLevel"))
        {
            Debug.Log("Smoothstepping");
            float t = (Time.time - startTime) / duration;
            experienceMeter.value = Mathf.SmoothStep(experienceMeter.value, currentExp, t);
        }        
    }
    public void IncrementScore()
    {
        currentExp += playerLevel;
        startTime = Time.time;
        lifetimeExp += playerLevel;
        scoreCountTMP.text = ++score + "";
        PlayerPrefs.SetInt("currentExp", currentExp);
        PlayerPrefs.SetInt("lifetimeExp", lifetimeExp);
        PlayerPrefs.SetInt("expNeeded", expNeeded);
        PlayerPrefs.SetInt("playerLevel", playerLevel);
        if(expNeeded <= currentExp)
        {
            StartCoroutine("NextLevel");
        }
    }
    
    public IEnumerator NextLevel()
    {
        playerLevel += 1;
        t = 0f;
        ChangeBackground.instance.ChangeBackgroundColor();
        currentExp = 0;
        SetExpNeeded();
        experienceMeter.maxValue = expNeeded;
        experienceMeter.value = currentExp;
        playerLevelTMP.text = playerLevel + "";
        PlayerPrefs.SetInt("playerLevel", playerLevel);
        PlayerPrefs.SetInt("currentExp", currentExp);
        PlayerPrefs.SetInt("expNeeded", expNeeded);
        yield return null;
    }
    void SetExpNeeded()
    {
        expNeeded = (playerLevel * 10 * Mathf.FloorToInt(Mathf.Log(Mathf.Pow(e, playerLevel))));
    }
    void LevelRestored()
    {
        levelLoaded.text = "your bonus is " + playerLevel;
        Invoke("ClearText", 3f);
    }
    void ClearText()
    {
        levelLoaded.text = "";
    }
}