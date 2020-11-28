using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDissapear : MonoBehaviour
{
    public GameObject platform;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player)
        {
            StartCoroutine(PlatformDestroy());

        }
    }

    IEnumerator PlatformDestroy()
    {


        yield return new WaitForSeconds(0.9f);
        Destroy(platform);

    }
}
