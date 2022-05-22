using UnityEngine;

public class Boundary : MonoBehaviour
{
    private float bottomBound = -10;
    void Update()
    {
        if(transform.position.y < bottomBound)
        {
            gameObject.SetActive(false);
        }
    }
}
