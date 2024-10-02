using UnityEngine;
using UnityEngine.InputSystem;

public class StartLevel : MonoBehaviour
{
    public bool CrownPickedUp = false;

    public GameObject coinsAndCrown;

    public InteractInput interact;

    private void OnTriggerStay(Collider other)
    {
        if(interact.click == 1)
        {
            begin();
        }
    }

    public void begin()
    {
        coinsAndCrown.SetActive(true);
        if (CrownPickedUp)
        {
            coinsAndCrown.SetActive(false);
        }
    }
}
