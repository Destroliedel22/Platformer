using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHealth;

    public RectTransform Health;
    public TextMeshProUGUI HPText;

    public GameObject playerCanvas;
    public GameObject deathCanvas;

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
            Time.timeScale = 0;
            playerCanvas.SetActive(false);
            deathCanvas.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            other.GetComponent<PickUp>().Activate();
        }
    }
}
