using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHealth;

    public RectTransform Health;
    public TextMeshProUGUI HPText;

    private void FixedUpdate()
    {
        Health.sizeDelta = new Vector2(playerHealth, Health.rect.height);
        HPText.text = "HP:" + playerHealth;

        if(playerHealth > 200)
        {
            playerHealth = 200;
        }

        if(playerHealth <= 0)
        {
            Debug.Log("You Died");
        }
    }
}
