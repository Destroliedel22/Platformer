using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int Dmg;
    [SerializeField] float angle;
    [SerializeField] AnimationClip clip;

    public Alien alien;

    private bool attacking;
    private Vector3 alienDirection;

    //on click activates attack and get the angle from playerforward to the target
    private void FixedUpdate()
    {
        if (AttackInput.Instance.AttackClick == 1 && attacking == false)
        {
            attacking = true;
            this.gameObject.GetComponentInChildren<Animator>().SetTrigger("Attacking");
            StartCoroutine(WaitWithAttack());
        }
        if(alien != null)
        {
            alienDirection = alien.gameObject.transform.position - this.gameObject.transform.position;
            angle = Vector3.Angle(this.gameObject.transform.forward, alienDirection);
        }
    }

    //deals dmg when looking at the target and if player is close to target
    public void Attack()
    {
        if(alien.Distance < 1 && angle < 45 && alien != null)
        {
            alien.health -= Dmg;
            alien.gameObject.GetComponent<Animator>().SetTrigger("TakenDmg");
        }
    }

    //waits for animation before attacking again
    IEnumerator WaitWithAttack()
    {
        yield return new WaitForSeconds(clip.length);
        attacking = false;
    }
}
