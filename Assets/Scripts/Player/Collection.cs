using UnityEngine;

public class Collection : MonoBehaviour
{
    public int collectibles = 0;        //Number of colledtibles the player has

    public AudioSource source;
    public AudioClip clip;

    public ScoreManager scoreManager;       //Reference to the score manager script

    public GameObject collectableExplosionEffect;       

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

            GameObject collectableExplosionPrefab = Instantiate(collectableExplosionEffect, other.transform.position, Quaternion.identity);
            Destroy(collectableExplosionPrefab, 1f);

            Destroy(other.gameObject);
        }
    }
}
