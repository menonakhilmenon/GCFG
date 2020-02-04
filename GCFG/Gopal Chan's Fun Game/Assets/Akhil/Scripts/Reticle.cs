using System.Collections;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    [SerializeField]
    private float reticleHitDuration = 0.3f;
    [SerializeField]
    private GameObject reticleObject = null;


    private Coroutine reticleCoroutine = null;
    private WaitForSeconds delay;

    private void Awake()
    {
        delay = new WaitForSeconds(reticleHitDuration);
    }
    public void OnPlayerHit() 
    {
        if(reticleCoroutine != null) 
        {
            StopCoroutine(reticleCoroutine);
        }
        reticleCoroutine = StartCoroutine(ReticleCoroutine());
    }
    private IEnumerator ReticleCoroutine() 
    {
        reticleObject.SetActive(true);
        yield return delay;
        reticleObject.SetActive(false);
    }
}
