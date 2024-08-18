using System.Collections;
using UnityEngine;

public class PufferfishEffects : MonoBehaviour
{
    public GameObject waterExhaleEffect;

    public void ExhaleEffect()
    {
        StartCoroutine(Exhale());
    }

    IEnumerator Exhale()
    {
        waterExhaleEffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        waterExhaleEffect.SetActive(false);
    }
}
