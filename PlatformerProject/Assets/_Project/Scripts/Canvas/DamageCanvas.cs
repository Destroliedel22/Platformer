using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageCanvas : MonoBehaviour
{
    [SerializeField]float fadeInSpeed;
    [SerializeField] float fadeOutSpeed;

    public Player player;

    public IEnumerator FadeIn(Image image)
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
            StartCoroutine(FadeOut(image));
        }
    }
    IEnumerator FadeOut(Image image)
    {
        for (float i = 1; i <= 0; i += Time.deltaTime)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
