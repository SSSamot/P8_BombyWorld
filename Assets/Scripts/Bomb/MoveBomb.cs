using UnityEngine;
using UnityEngine.AI;

public class MoveBomb : MonoBehaviour
{
    //public Transform target;

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

        //MoveTo();
    }

    void Update()
    {
        if (!behavior.explosion && !GameManager.instance.player.GetComponent<PlayerController>().isDie)
        {
            agent.SetDestination(GameManager.instance.player.transform.position);

            player = GameManager.instance.player.transform.position;
            bomb = transform.position;

            if (Vector3.Distance(player, bomb) < 2f)
            {
                agent.speed = 0f;
                behavior.Explosion();
            }
            else
            {
                agent.speed = 4f;
                anim.WalkBomb();
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
