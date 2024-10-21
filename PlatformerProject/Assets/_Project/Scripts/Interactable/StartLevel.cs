using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour, IInteractable
{
    [SerializeField] Image InteractButton;

    public bool CrownPickedUp = false;
    public GameObject coinsAndCrown;

    private Canvas interactCanvas;

    private void Awake()
    {
        interactCanvas = GetComponentInChildren<Canvas>();
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (InteractInput.Instance.click == 1)
            {
                begin();
            }
            InTrigger();
        }
    }

    //activates all coins, crowns and stars on that level
    public void begin()
    {
        coinsAndCrown.SetActive(true);
        if (CrownPickedUp)
        {
            coinsAndCrown.SetActive(false);
        }
    }

    public void InTrigger()
    {
        if(InteractButton != null)
        {
            InteractButton.gameObject.SetActive(true);
        }
        else
        {
            interactCanvas.enabled = true;
        }
    }
}
