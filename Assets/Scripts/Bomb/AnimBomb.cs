using UnityEngine;

public class AnimBomb : MonoBehaviour
{
    public Animator anim;

    public void IdleBomb()
    {
        anim.SetBool("walk", false);
    }

    public void WalkBomb()
    {
        anim.SetBool("walk", true);
    }

    public void ExplosionBomb()
    {
        anim.SetTrigger("attack01");
    }
}
