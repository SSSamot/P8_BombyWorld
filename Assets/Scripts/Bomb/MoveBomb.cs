using UnityEngine;
using UnityEngine.AI;

public class MoveBomb : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent agent;
    private AnimBomb anim;
    private BehaviorBomb behavior;

    private Vector3 player;
    private Vector3 bomb;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<AnimBomb>();
        behavior = GetComponent<BehaviorBomb>();
    }
    void Update()
    {
        if (!behavior.explosion)
        {
            agent.SetDestination(target.position);

            player = target.position;
            bomb = transform.position;

            if (Vector3.Distance(player, bomb) < 3f)
            {
                agent.speed = 0f;
                anim.IdleBomb();
            }
            else
            {
                agent.speed = 3.5f;
                anim.WalkBomb();
            }
        }
    }
}
