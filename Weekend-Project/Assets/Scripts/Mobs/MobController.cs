using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public int HP;
    public int MP;
    public int damage;
    public int numberOfDrops;
    public GameObject drop;

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
                StartCoroutine(wait(animator.GetCurrentAnimatorStateInfo(0).length/1.5f));
                Destroy(gameObject, 3);
            }
        }
    }

    void Drop(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 position = new Vector3(transform.position.x + Random.Range(0f, 0.1f),transform.position.y, transform.position.z + Random.Range(0f, 0.1f));
            Instantiate(drop, position, transform.rotation);
        }
    }
    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        Drop(numberOfDrops);
    }
}
