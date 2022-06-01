using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player playerInstance;
    private float dirX;
    private float moveSpeed = 10f;
    
    private Camera cam;
    private float screenHalfWidthInWorldSpace;
    public GameObject circle;
    public GameObject trigger;
    private bool basket = false;
    private void Awake()
    {
        playerInstance = this; //Singleton!
    }
    void Start()
    {
        cam = Camera.main;
        screenHalfWidthInWorldSpace = cam.aspect * cam.orthographicSize;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            basket = !basket;
            if(basket)
            {
                circle.SetActive(false);
                trigger.SetActive(true);
            }
            else
            {
                circle.SetActive(true);
                trigger.SetActive(false);
            }
        }
        if(transform.position.x < -screenHalfWidthInWorldSpace)
        {
            transform.position = new Vector3(-screenHalfWidthInWorldSpace + 0.5f, transform.position.y, transform.position.z);
        }
        if(transform.position.x > screenHalfWidthInWorldSpace)
        {
            transform.position = new Vector3(screenHalfWidthInWorldSpace - 0.5f, transform.position.y, transform.position.z);
        }
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        transform.Translate(Vector3.right * dirX * Time.deltaTime);
    }
}