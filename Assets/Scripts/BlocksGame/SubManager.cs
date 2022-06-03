using System.Collections;
using TMPro;
using UnityEngine;

public class SubManager : Manager
{
    public TextMeshProUGUI gameOver;
    public int square = 6;
    private int total;
    private int strike;
    public static SubManager sub;
    private void Awake()
    {
        sub = this;
    }
    protected override void Start()
    {
        objectPooler = ObjectPooler.Instance;
        StartCoroutine("DelayedStart");
        total = square * square;
    }
    private IEnumerator DelayedStart()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < square; ++i)
        {
            for (int x = 0; x < square; ++x)
            {
                Vector3 position = new Vector3(-1.8f + 0.72f * x, 2f + 0.45f * i, 0);
                string item = toys[Random.Range(0, toys.Length)];
                Spawn(item, position);
            }
        }
    }
    public void UpdateTotal()
    {
        --total;
        if(total <= 0)
        {
            Menu.instance.GameOver();
        }
    }
    public void UpdateStrike()
    {
        ++strike;
        if(strike > 3)
        {
            gameOver.enabled = true;
            Invoke("Menu.instance.GameOver", 2f);
        }
    }
    protected override void Spawn(string item, Vector3 pos)
    {
        GameObject itemToSpawn = (GameObject)objectPooler?.SpawnFromPool(item, pos, Quaternion.Euler(0, 180, 0));
        itemToSpawn.GetComponent<Rigidbody>().velocity = Vector3.zero;
        itemToSpawn.transform.parent = transform;
    }

    protected override void Update()
    {
        
    }
}
