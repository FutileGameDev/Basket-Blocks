using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public string gameName;
    public string[] playerName = new string[4];
    public int[] highScore = new int[4];
}
