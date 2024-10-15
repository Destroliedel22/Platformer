using System.Collections;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] Transform ladderTop;
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator anim;

    public float speed;

    private bool cooldown = false;
    private bool onLadder = false;
    private Rigidbody rb;

    private void OnTriggerStay(Collider other)
    {
        rb = other.gameObject.GetComponent<Rigidbody>();

        if (cooldown == false)
        {
            if(InteractInput.Instance.click == 1 && other.CompareTag("Player"))
            {
                StartCoroutine(InteractCooldown());
                if(onLadder)
                {
                    onLadder = false;
                }
                else if(onLadder == false)
                {
                    onLadder = true;
                }
            }
        }

        if (onLadder)
        {
            other.gameObject.GetComponent<PlayerJump>().enabled = false;
            other.gameObject.GetComponent<PlayerControl>().enabled = false;
            rb.useGravity = false;
            if (LadderInput.Instance.direction > 0)
            {
                rb.velocity = new Vector3(0, LadderInput.Instance.direction * speed, 0) + gameObject.transform.up;
            }

            if (LadderInput.Instance.downDirection > 0)
            {
                rb.velocity = new Vector3(0, LadderInput.Instance.downDirection * -speed, 0) - gameObject.transform.up;
            }
        }
        else
        {
            other.gameObject.GetComponent<PlayerControl>().enabled = true;
            other.gameObject.GetComponent<PlayerJump>().enabled = true;
        }
    }

    IEnumerator InteractCooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(0.3f);
        cooldown = false;
    }
}
