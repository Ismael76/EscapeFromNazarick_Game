using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameText : MonoBehaviour
{
    public GameObject gameText;

    void Start()
    {
        StartCoroutine(GameDialogue());
    }

    IEnumerator GameDialogue()
    {

        yield return new WaitForSeconds(8.5f);
        gameText.SetActive(false);
    }

}
