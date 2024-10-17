using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    //parent for npcs

    public float Stamina;
    public float health;
    public NavMeshAgent agent;

    public virtual void Activate()
    {
        
    }
}
