using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public GameObject playerCanvas;
    [SerializeField] public GameObject deathCanvas;

    public float playerHealth;
    public RectTransform Health;
    public TextMeshProUGUI HPText;

    private bool isDead;

    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        UpdateHealth();
    }

    //updates the health bar to what hp the player has and if hp = 0 player dies
    public void UpdateHealth()
    {
        Health.sizeDelta = new Vector2(playerHealth, Health.rect.height);
        HPText.text = "HP:" + playerHealth;

        if (playerHealth > 200)
        {
            playerHealth = 200;
        }

        if (playerHealth <= 0 && isDead == false)
        {
            isDead = true;
            anim.SetTrigger("Dead");
            playerCanvas.SetActive(false);
            deathCanvas.SetActive(true);
            this.gameObject.GetComponent<PlayerControl>().enabled = false;
            this.gameObject.GetComponent<PlayerJump>().enabled = false;
        }
    }

    //picks up collectibles when in trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            other.GetComponent<PickUp>().Activate();
        }
    }
}
