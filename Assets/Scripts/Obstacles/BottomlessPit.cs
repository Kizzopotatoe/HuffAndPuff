using UnityEngine;

public class BottomlessPit : MonoBehaviour
{
    public Transform checkpoint;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.position = checkpoint.position;
        }
    }
}
