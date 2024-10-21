using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgImg : MonoBehaviour
{
    [SerializeField] float fadeInSpeed;
    [SerializeField] float fadeOutSpeed;

    public Player player;

    //fades in the hit canvas when getting hit
    public IEnumerator FadeIn(Image image)
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
            StartCoroutine(FadeOut(image));
        }
    }

    //fades out the canvas after time
    IEnumerator FadeOut(Image image)
    {
        for (float i = 1; i <= 0; i += Time.deltaTime)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
