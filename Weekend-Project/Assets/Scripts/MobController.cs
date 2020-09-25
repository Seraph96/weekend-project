using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public int HP;
    public int MP;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // If GameObject get hit, it will become damage.
    void GetDamage(int damage)
    {
        if (HP > 0)
        {
            HP = HP - damage;
            if (HP <= 0)
            {
                Debug.Log("BIN TOD!");
                animator.SetTrigger("death");
                Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length + 1f);
            }
        }
    }
}
