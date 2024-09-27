using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Player : MonoBehaviour
{
    public float playerHealth;

    public RectTransform Health;
    public TextMeshProUGUI HPText;

    public GameObject playerCanvas;
    public GameObject deathCanvas;

    bool isDead;

    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        Health.sizeDelta = new Vector2(playerHealth, Health.rect.height);
        HPText.text = "HP:" + playerHealth;

        if(playerHealth > 200)
        {
            playerHealth = 200;
        }

        if(playerHealth <= 0 && isDead == false)
        {
            isDead = true;
            anim.SetTrigger("Dead");
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
