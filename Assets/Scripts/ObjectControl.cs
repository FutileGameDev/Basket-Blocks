using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    public float speed = 15f;
    Vector3 spawnPosition;
    private float Rotation = 90f;
    private float bottomBound = -10;
    private float backZ = -0.05f;
    private float frontZ = 0.05f;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Base"))
        {
            switch (gameObject.tag)
            {
                case "Coin":
                    Manager.instance.SoundAndEffect(0);
                    break;
                case "Bear":
                    Manager.instance.SoundAndEffect(1);
                    break;
                case "Monkey":
                    Manager.instance.SoundAndEffect(2);
                    break;
                case "Penguin":
                    Manager.instance.SoundAndEffect(3);
                    break;
                case "Pig":
                    Manager.instance.SoundAndEffect(4);
                    break;
                case "Rabbit":
                    Manager.instance.SoundAndEffect(5);
                    break;
                case "Sheep":
                    Manager.instance.SoundAndEffect(6);
                    break;
                case "Basket":
                    Manager.instance.Sound(Random.Range(7, 10));
                    break;
            }    
            PlayerLevel.instance.IncrementScore();
            Invoke("DespawnObject", 0.1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Basket"))
        {
            Manager.instance.Sound(Random.Range(10, 15));
        }
        PlayerLevel.instance.IncrementScore();
        Invoke("DespawnObject", 0.1f);
    }
    
    public void OnObjectSpawn()
    {        
        transform.rotation = Quaternion.AngleAxis(Rotation = Random.Range(0, 360), Vector3.forward);
    }
    public void DespawnObject()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        transform.Rotate(0, Rotation * Time.deltaTime, 0);
        if(transform.position.y < bottomBound)
        {
            CancelInvoke("DespawnObject");
            gameObject.SetActive(false);
        }
        if(transform.position.z < backZ || transform.position.z > frontZ)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, 0f), step);
        }
    }
}
