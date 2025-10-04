using UnityEngine;

public class MoveBacground : MonoBehaviour
{
    Transform BGTransform;
    Vector3 BGPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BGTransform = transform;
        BGPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime;
    }
}
