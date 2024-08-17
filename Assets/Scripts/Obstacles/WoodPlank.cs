using UnityEngine;

public class WoodPlank : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    //If the player collides with this object it will be destroyed
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(clip);

            Destroy(this.gameObject);
        }
    }
}
