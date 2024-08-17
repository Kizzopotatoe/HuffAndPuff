using UnityEngine;

public class Collection : MonoBehaviour
{
    public int collectibles = 0;
    public AudioSource source;
    public AudioClip clip;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            collectibles++;
            source.PlayOneShot(clip);
            Destroy(other.gameObject);
        }
    }
}
