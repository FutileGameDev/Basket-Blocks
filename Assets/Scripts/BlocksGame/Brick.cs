using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : ObjectControl
{
    protected override void Update()
    {
        
    }
    protected override void OnObjectSpawn()
    {
        
    }
    protected override void OutOfBounds()
    {
        
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Base"))
        {
            switch (gameObject.tag)
            {
                case "Coin":
                    SubManager.sub.Sound(0);
                    break;
                case "Bear":
                    SubManager.sub.Sound(1);
                    break;
                case "Monkey":
                    SubManager.sub.Sound(2);
                    break;
                case "Penguin":
                    SubManager.sub.Sound(3);
                    break;
                case "Pig":
                    SubManager.sub.Sound(4);
                    break;
                case "Rabbit":
                    SubManager.sub.Sound(5);
                    break;
                case "Sheep":
                    SubManager.sub.Sound(6);
                    break;
                case "Basket":
                    SubManager.sub.Sound(7);
                    break;
            }    
            PlayerLevel.instance.IncrementScore();
            SubManager.sub.UpdateTotal();
            Invoke("DespawnObject", 0.1f);
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {

    }
}
