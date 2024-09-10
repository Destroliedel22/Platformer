using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Player instance;

    public Player Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(Player)) as Player;
            }
            return instance;
        }
    }

    public int crownAmount = 0;
    public int coinAmount = 0;

    public Animator anim;

    public control ctr;

    private void Update()
    {
        anim.SetFloat("Speed", ctr.speed);
    }
}
