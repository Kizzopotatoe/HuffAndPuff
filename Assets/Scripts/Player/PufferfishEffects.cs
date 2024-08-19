using System.Collections;
using UnityEngine;

public class PufferfishEffects : MonoBehaviour
{
    [Header("Splash Effect")]
    public GameObject waterSplashEffect;
    public GameObject superWaterSplashEffect;

    [Header("Ripple Effect")]
    public GameObject rippleEffect;

    [Header("Explosion")]
    public GameObject explosionEffect;

    public void SplashWaterEffect()
    {
        StartCoroutine(SplashWater());

    }

    public void SplashSuperWaterEffect()
    {
        StartCoroutine(SplashSuperWater());
    }

    IEnumerator SplashWater()
    {
        waterSplashEffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        waterSplashEffect.SetActive(false);
    }

    IEnumerator SplashSuperWater()
    {
        superWaterSplashEffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        superWaterSplashEffect.SetActive(false);
    }

    public void SpawnRippleEffect(Transform areaToHit)
    {
        GameObject rippleEffectPrefab = Instantiate(rippleEffect, areaToHit.position, Quaternion.identity);
        Destroy(rippleEffectPrefab, 1f);
    }

    public void SpawnExplosionEffect()
    {
        GameObject explosionEffectPrefab = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(explosionEffectPrefab, 1f);
    }
}
