using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public Color[] colors = {Color.blue, Color.cyan, Color.green, Color.magenta, Color.red};
    Color PickColor;
    public float duration = 3f;
    public Camera cam;
    public static ChangeBackground instance;
    private void Awake()
    {
        instance = this;
    }
    public void ChangeBackgroundColor()
    {
        PickColor = colors[Random.Range(0, 5)];
        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(PickColor, PickColor, t);
    }
}
