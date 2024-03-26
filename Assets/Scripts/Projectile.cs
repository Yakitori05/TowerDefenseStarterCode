using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int damage;

    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            DamageTarget();
            Destroy(gameObject);
        }
    }
    void DamageTarget()
    {
        if (target != null && target.CompareTag("Enemy"))
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}

