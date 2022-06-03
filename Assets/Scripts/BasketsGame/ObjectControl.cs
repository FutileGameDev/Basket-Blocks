using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;
    private float Rotation = 90f;
    private float bottomBound = -10;
    private float backZ = -0.05f;
    private float frontZ = 0.05f;
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Base"))
        {
            switch (gameObject.tag)
            {
                case "Coin":
                    Manager.instance.SoundAndEffect(0, collision.transform.position);
                    break;
                case "Bear":
                    Manager.instance.SoundAndEffect(1, collision.transform.position);
                    break;
                case "Monkey":
                    Manager.instance.SoundAndEffect(2, collision.transform.position);
                    break;
                case "Penguin":
                    Manager.instance.SoundAndEffect(3, collision.transform.position);
                    break;
                case "Pig":
                    Manager.instance.SoundAndEffect(4, collision.transform.position);
                    break;
                case "Rabbit":
                    Manager.instance.SoundAndEffect(5, collision.transform.position);
                    break;
                case "Sheep":
                    Manager.instance.SoundAndEffect(6, collision.transform.position);
                    break;
                case "Basket":
                    Manager.instance.SoundAndEffect(7, collision.transform.position, Random.Range(0, 3));
                    break;
            }    
            PlayerLevel.instance.IncrementScore();
            Invoke("DespawnObject", 0.1f);
        }
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        Manager.instance.Sound(Random.Range(10, 15));
        PlayerLevel.instance.IncrementScore();
        Invoke("DespawnObject", 1f);
    }
    
    protected virtual void OnObjectSpawn()
    {        
        transform.rotation = Quaternion.AngleAxis(Rotation = Random.Range(0, 360), Vector3.forward);
    }
    public void DespawnObject()
    {
        gameObject.SetActive(false);
    }
    protected virtual void Update()
    {
        Debug.Log("ObjectControl Update called");
        transform.Rotate(0, Rotation * Time.deltaTime, 0);
        OutOfBounds();
        if(transform.position.z < backZ || transform.position.z > frontZ)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, 0f), step);
        }
    }
    protected virtual void OutOfBounds()
    {
        if(transform.position.y < bottomBound)
        {
            CancelInvoke("DespawnObject");
            gameObject.SetActive(false);
        }
    }
}
