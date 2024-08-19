using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public Pufferfish pufferfish;

    public GameObject explosionEffect;

    //If the player collides with this object it will be destroyed
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pufferfish = other.gameObject.GetComponent<Pufferfish>();

            if(pufferfish.bigMode == false) return;

            source.PlayOneShot(clip);
            GameObject explosionEffectPrefab = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionEffectPrefab, 2f);

            Destroy(this.gameObject);
        }
    }
}
