using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public float Countdown;
    ObjectPooler objectPooler;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;
        if (Countdown <= 0)
        {
            SpawnCoin(); //at random location within the specified range
            Countdown = 0.3f;
        }
    }
    public void SpawnCoin()
    {
        int randomX = Random.Range(-7, 7);
        int randomY = Random.Range(10, 12);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        GameObject newCoin = (GameObject)objectPooler.SpawnFromPool("Coin", spawnPosition, Quaternion.Euler(0, 0, 90));
        newCoin.GetComponent<Rigidbody>().velocity = Vector3.zero;
        newCoin.transform.parent = transform;
    }
}
