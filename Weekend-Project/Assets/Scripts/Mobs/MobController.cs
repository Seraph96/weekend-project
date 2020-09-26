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
    private MobLifeBar mobLifeBar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        mobLifeBar = gameObject.GetComponentInChildren<MobLifeBar>();
    }

    // If GameObject get hit, it will become damage.
    void GetDamage(int damage)
    {
        if (HP > 0)
        {
            HP = HP - damage;
            mobLifeBar.lifebar.value = HP;

            if (HP <= 0)
            {
                Debug.Log("BIN TOD!");
                animator.SetTrigger("death");
                StartCoroutine(WaitForDrop(animator.GetCurrentAnimatorStateInfo(0).length - 0.1f));
                Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }

    void Drop(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 position = new Vector3(transform.position.x + Random.Range(-2f, 2f),transform.position.y, transform.position.z + Random.Range(-2f, 2));
            Instantiate(drop, position, transform.rotation);
        }
    }
    IEnumerator WaitForDrop(float time)
    {
        yield return new WaitForSeconds(time);
        Drop(numberOfDrops);
    }
}
