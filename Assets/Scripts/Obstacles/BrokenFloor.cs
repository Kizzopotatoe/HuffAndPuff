using System.Collections;
using UnityEngine;

public class BrokenFloor : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public GameObject crumblingEffect;
    public GameObject explosionEffect;

    //If the player collides with this object, and they are over a specific size, it will be destroyed
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            var pufferfish = other.gameObject.GetComponent<Pufferfish>();
            crumblingEffect.SetActive(true);

            if (pufferfish.power >= 12f)
            {
                source.PlayOneShot(clip);

                GameObject explosionEffectPrefab = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(explosionEffectPrefab, 2f);

                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var pufferfish = collision.gameObject.GetComponent<Pufferfish>();

            if (pufferfish.power <= 12f)
            {
                crumblingEffect.SetActive(false);
            }
        }
    }

}
