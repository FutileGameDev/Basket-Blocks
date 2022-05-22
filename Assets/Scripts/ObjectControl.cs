using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    public float speed = 15f;
    Vector3 spawnPosition;
    private float Rotation = 90f;
    private float bottomBound = -10;
    private float backZ = -0.05f;
    private float frontZ = 0.05f;
    public AudioClip collectSound;
    public ParticleSystem collectEffect;
    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Base"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);        
            PlayerLevel.instance.IncrementScore();
            collectEffect.Play();
            Invoke("DespawnObject", 0.1f);
        }
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
