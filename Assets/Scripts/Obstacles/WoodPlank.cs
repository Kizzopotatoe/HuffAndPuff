using UnityEngine;

public class WoodPlank : MonoBehaviour
{
    //If the player collides with this object it will be destroyed
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
