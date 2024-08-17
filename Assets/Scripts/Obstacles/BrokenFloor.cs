using UnityEngine;

public class BrokenFloor : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    //If the player collides with this object, and they are over a specific size, it will be destroyed
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            var pufferfish = other.gameObject.GetComponent<Pufferfish>();

            if(pufferfish.power >= 12f)
            {
                source.PlayOneShot(clip);

                Destroy(this.gameObject);
            }
        }
    }
}
