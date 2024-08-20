using UnityEngine;

public class BubblePop : MonoBehaviour
{
    public Pufferfish pufferfish;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pufferfish = other.gameObject.GetComponent<Pufferfish>();

            if(pufferfish.bigMode == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
