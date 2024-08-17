using UnityEngine;

public class Collection : MonoBehaviour
{
    public int collectibles = 0;
    public AudioSource source;
    public AudioClip clip;

    public ScoreManager scoreManager;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            collectibles++;
            if(scoreManager != null)
            {
                scoreManager.Collectables(collectibles);
            }

            source.PlayOneShot(clip);
            Destroy(other.gameObject);
        }
    }
}
