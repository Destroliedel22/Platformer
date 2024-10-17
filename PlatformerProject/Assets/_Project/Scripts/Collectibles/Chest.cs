using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject Lid;

    private Key key;

    private void Awake()
    {
        key = GetComponentInChildren<Key>();
    }

    //if near chest with key the chest opens
    private void OnTriggerStay(Collider other)
    {
        if (InteractInput.Instance.click == 1 && other.CompareTag("Player"))
        {
            if (key.KeyPickedUp)
            {
                Lid.transform.rotation = Quaternion.Euler(-90, 0, 0);
                if(InteractInput.Instance.click == 1)
                {
                    //get gold
                }
            }
            else
            {
                Debug.Log("Need Key");
            }
        }
    }
}
