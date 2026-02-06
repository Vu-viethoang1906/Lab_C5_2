using UnityEngine;

public class TriggerCollisionDemo : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION với: " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER với: " + other.gameObject.name);
    }
}
