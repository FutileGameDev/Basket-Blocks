using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Color[] colors = {Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow};
    Color pickColor;

    //public static Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax, float alphaMin, float alphaMax);
    public float duration = 3f;
    public Camera cam;
    private Renderer rend;
    private float timer = 5f;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine("ChangeColor");
    }

    // Update is called once per frame
    private IEnumerator ChangeColor()
    {
        pickColor = colors[Random.Range(0, 5)];
        
        float t = Mathf.PingPong(Time.time, duration) / duration;

        while(timer >= 0)
        {
            if(pickColor != cam.backgroundColor)
            {
                rend.material.color = Color.Lerp(rend.material.color, pickColor, t);
            }
            else
            {
                pickColor = colors[Random.Range(0, 5)];
            }
            timer -= Time.deltaTime;
            yield return null;
        }
        timer = 5f;
        StartCoroutine("ChangeColor");
    }
}
