using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int Dmg;
    [SerializeField] AnimationClip clip;

    public Alien alien;

    private bool attacking;

    private void FixedUpdate()
    {
        if (AttackInput.Instance.AttackClick == 1 && attacking == false)
        {
            attacking = true;
            this.gameObject.GetComponentInChildren<Animator>().SetTrigger("Attacking");
            StartCoroutine(WaitWithAttack());
        }
    }

    public void Attack()
    {
        if(alien.distance < 1)
        {
            alien.health -= Dmg;
            alien.gameObject.GetComponent<Animator>().SetTrigger("TakenDmg");
        }
    }

    IEnumerator WaitWithAttack()
    {
        yield return new WaitForSeconds(clip.length);
        attacking = false;
    }
}
