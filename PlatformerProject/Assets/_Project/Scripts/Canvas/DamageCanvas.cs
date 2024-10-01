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
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeInSpeed && player.playerHealth != 0)
        {
            yield return
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeInSpeed);
            image.color = c;
        }
    }
}
