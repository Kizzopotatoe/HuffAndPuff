using UnityEngine;

public class WoodPlank : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public GameObject explosionEffect;

    //If the player collides with this object it will be destroyed
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(clip);

            GameObject explosionEffectPrefab = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionEffectPrefab, 2f);

            Destroy(this.gameObject);
        }
    }
}
