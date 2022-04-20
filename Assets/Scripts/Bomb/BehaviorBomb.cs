using System.Collections;
using UnityEngine;

public class BehaviorBomb : MonoBehaviour
{
    public int timer;
    public bool explosion = false;

    private float blinkSpeed = 3;

    private AnimBomb anim;
    private Renderer bombRenderer;

    private GameObject player;
    public GameObject shaderObject;

    void Start()
    {
        anim = GetComponent<AnimBomb>();
        bombRenderer = shaderObject.GetComponent<Renderer>();

        StartCoroutine(Timer());
    }

    private void Update()
    {
        //player = GameManager.instance.player;
    }

    // timer after explosed bomb
    IEnumerator Timer()
    {
        bombRenderer.sharedMaterial.SetFloat("_Blink_Speed", blinkSpeed);

        int nbTimer = timer;
        for (int i = 0; i< nbTimer; i++)
        {
            yield return new WaitForSeconds(1.0f);
            timer -= 1;
            blinkSpeed += 1;
            bombRenderer.sharedMaterial.SetFloat("_Blink_Speed", blinkSpeed);
        }
        Explosion();
    }

    // anim explosion + block movement + call DestroyBomb()
    void Explosion()
    {
        anim.ExplosionBomb();
        explosion = true;
        StartCoroutine(DestroyBomb());
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
