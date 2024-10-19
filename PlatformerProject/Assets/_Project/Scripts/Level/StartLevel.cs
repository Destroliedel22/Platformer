using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    [SerializeField] Image InteractButton;

    public bool CrownPickedUp = false;
    public GameObject coinsAndCrown;

    private void OnTriggerStay(Collider other)
    {
        if(InteractInput.Instance.click == 1)
        {
            begin();
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
}
