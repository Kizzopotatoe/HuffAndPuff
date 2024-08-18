using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public Pufferfish pufferfish;

    //If the player collides with this object it will be destroyed
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pufferfish = other.gameObject.GetComponent<Pufferfish>();

            if(pufferfish.bigMode == false) return;

            source.PlayOneShot(clip);
            Destroy(this.gameObject);
        }
    }
}
