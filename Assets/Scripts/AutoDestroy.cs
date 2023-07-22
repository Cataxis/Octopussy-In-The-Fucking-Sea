using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float timeToDestroy;

    void Start()
    {
        StartCoroutine(AutoDestroyCoroutine());
    }

    IEnumerator AutoDestroyCoroutine()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
