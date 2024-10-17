using UnityEngine;
using UnityEngine.AI;

public class KipNavMesh : NPC
{
    public Player player;
    public float destinationReachedThreshold = 1.0f;

    private Vector3 RandomDestination;

    private void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    //sets destination
    private void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance <= destinationReachedThreshold)
        {
            RandomDestination = new Vector3(transform.position.x + Random.Range(-100, 100), 0, transform.position.z + Random.Range(-100, 100));
            agent.SetDestination(RandomDestination);
        }
    }
}
