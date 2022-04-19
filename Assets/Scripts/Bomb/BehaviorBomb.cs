using System.Collections;
using UnityEngine;

public class BehaviorBomb : MonoBehaviour
{
    public int timer;
    public bool explosion = false;

    private AnimBomb anim;

    public GameObject player;

    void Start()
    {
        anim = GetComponent<AnimBomb>();

        timer = 5;
        StartCoroutine(Timer());
    }

    // timer after explosed bomb
    IEnumerator Timer()
    {
        int timerbis = timer;
        for (int i = 0; i< timerbis; i++)
        {
            yield return new WaitForSeconds(1.0f);
            timer -= 1;
        }
        Explosion();
    }

    // anim explosion + block movement + call DestroyBomb()
    void Explosion()
    {
        anim.ExplosionBomb();
        explosion = true;
        StartCoroutine(DestroyBomb());
        //KillPlayer();
    }

    // destroy bomb after 2sec
    IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(1.0f);
        KillPlayer();
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Detected");
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }

    void KillPlayer()
    {
        if(player != null)
        {
            Destroy(player);
        }
    }
}
