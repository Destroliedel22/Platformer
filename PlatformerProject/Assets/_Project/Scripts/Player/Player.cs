using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public GameObject playerCanvas;

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
            SceneManager.LoadScene(2);
        }
    }

    //picks up collectibles when in trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            other.GetComponent<PickUp>().Activate();
            other = other.GetComponent<PickUp>().other;
        }
    }
}
