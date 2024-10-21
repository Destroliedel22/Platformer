using UnityEngine;

public interface IInteractable
{
    abstract void OnTriggerStay(Collider other);

    abstract void InTrigger();
}
