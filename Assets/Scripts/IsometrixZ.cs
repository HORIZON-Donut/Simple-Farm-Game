using UnityEngine;

public class IsometrixZ : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y/100);
    }
}
