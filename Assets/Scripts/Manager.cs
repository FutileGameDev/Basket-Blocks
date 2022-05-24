using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private float countdown1 = 0;
    private float countdown2 = 0;
    private float countdown3 = 0;
    private string[] toys = {"Bear", "Monkey", "Penguin", "Pig", "Rabbit", "Sheep"};
    public AudioClip[] sounds = new AudioClip[15];
    public string[] collectEffects = {"Pop", "Hug", "Banana", "Suit", "Pen", "Ears", "Wool", "Iceman"};
    ObjectPooler objectPooler;
    public static Manager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        countdown1 -= Time.deltaTime;
        countdown2 -= Time.deltaTime;
        countdown3 -= Time.deltaTime;
        if (countdown1 <= 0)
        {
            Spawn("Coin");
            countdown1 = 0.3f;
        }
        if (countdown2 <= 0)
        {
            int choose = Random.Range(0, toys.Length);
            Spawn(toys[choose]);
            countdown2 = 1.6f;
        }
        if (countdown1 <= 0)
        {
            Spawn("Basket");
            countdown1 = 2.5f;
        }
    }
    public void SpawnAt(string item, Vector3 pos)
    {
        GameObject newCoin = (GameObject)objectPooler.SpawnFromPool(item, pos, Quaternion.identity);
        newCoin.transform.parent = transform;
    }
    public void Spawn(string item)
    {
        int randomX = Random.Range(-7, 7);
        int randomY = Random.Range(10, 12);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        GameObject newCoin = (GameObject)objectPooler.SpawnFromPool(item, spawnPosition, Quaternion.Euler(0, 0, 90));
        newCoin.GetComponent<Rigidbody>().velocity = Vector3.zero;
        newCoin.transform.parent = transform;
    }
    public void SoundAndEffect(int num)
    {
        AudioSource.PlayClipAtPoint(sounds[num], transform.position);
        SpawnAt(collectEffects[num], transform.position); 
    }
    public void Sound(int num)
    {
        AudioSource.PlayClipAtPoint(sounds[num], transform.position);
    }
}
