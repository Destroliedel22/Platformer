using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCStats",
                 menuName = "NPC Stats", order = 0)]

public class NPCStats : ScriptableObject
{
    public float Stamina;
    public float health;
}
