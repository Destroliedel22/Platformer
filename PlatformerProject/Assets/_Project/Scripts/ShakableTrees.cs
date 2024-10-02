using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakableTrees : MonoBehaviour
{
    protected GameObject PineApple;
    [SerializeField] protected Transform camera;

    [SerializeField] protected List<Transform> appleSpawns = new List<Transform>();
    protected Transform appleSpawn;

    [SerializeField] protected GameObject ShakeCanvas;

    protected bool shaken;
}
