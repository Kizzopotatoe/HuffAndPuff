using UnityEngine;

public class Collection : MonoBehaviour
{
    public int collectibles = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            collectibles++;
            Destroy(other.gameObject);
        }
    }
}
