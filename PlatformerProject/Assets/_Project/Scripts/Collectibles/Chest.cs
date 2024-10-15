using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject Lid;

    Key key;

    private void Awake()
    {
        key = GetComponentInChildren<Key>();
    }

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
