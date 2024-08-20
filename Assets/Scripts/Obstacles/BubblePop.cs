using UnityEngine;

public class BubblePop : MonoBehaviour
{
    public Pufferfish pufferfish;

    public GameObject bubblePopEffect;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pufferfish = other.gameObject.GetComponent<Pufferfish>();

            if(pufferfish.bigMode == true)
            {
                GameObject bubblePopPrefab = Instantiate(bubblePopEffect, transform.position, Quaternion.identity);
                Destroy(bubblePopPrefab, 2f);

                Destroy(this.gameObject);
            }
        }
    }
}
