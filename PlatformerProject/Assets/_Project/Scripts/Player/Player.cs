using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;

    public control ctr;

    private void Update()
    {
        anim.SetFloat("Speed", ctr.speed);
    }
}
