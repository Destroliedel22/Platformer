using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int Dmg;
    [SerializeField] float angle;
    [SerializeField] AnimationClip clip;

    public Alien alien;

    private bool attacking;
    private Vector3 alienDirection;

    private void FixedUpdate()
    {
        if (AttackInput.Instance.AttackClick == 1 && attacking == false)
        {
            attacking = true;
            this.gameObject.GetComponentInChildren<Animator>().SetTrigger("Attacking");
            StartCoroutine(WaitWithAttack());
        }
        alienDirection = alien.gameObject.transform.position - this.gameObject.transform.position;
        angle = Vector3.Angle(this.gameObject.transform.forward, alienDirection);
    }

    public void Attack()
    {
        if(alien.distance < 1 && angle < 45)
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
