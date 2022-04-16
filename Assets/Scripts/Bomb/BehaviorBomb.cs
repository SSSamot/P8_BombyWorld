using System.Collections;
using UnityEngine;

public class BehaviorBomb : MonoBehaviour
{
    public int timer; 

    private AnimBomb anim;

    void Start()
    {
        anim = GetComponent<AnimBomb>();

        timer = 10;
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        int timerbis = timer;
        for (int i = 0; i< timerbis; i++)
        {
            yield return new WaitForSeconds(1.0f);
            timer -= 1;
        }
        anim.ExplosionBomb();
    }
}
