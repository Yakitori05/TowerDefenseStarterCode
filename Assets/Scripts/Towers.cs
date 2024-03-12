using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{

    public float attackRange = 1f; // Range within which the tower can detect and attack enemies 
    public float attackRate = 1f; // How often the tower attacks (attacks per second) 
    public int attackDamage = 1; // How much damage each attack does 
    public float attackSize = 1f; // How big the bullet looks 
    public float ProjectileSpeed = 10f;
    public GameObject bulletPrefab; // The bullet prefab the tower will shoot 
    public TowerType type; // the type of this tower 
    
    // Draw the attack range in the editor for easier debugging 
    private float NextAttackTime = 0f;

    void Update()
    {
        // Check if it's time to attack
        if (Time.time >= NextAttackTime)
        {
            ScanForEnemiesAndShoot();
            NextAttackTime = Time.time +1f /attackRate;

            // Find enemies within range
            
            
        }
        void ScanForEnemiesAndShoot()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
            foreach (Collider2D col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Shoot at the enemy
                    ShootAtEnemy(col.gameObject);
                    break; // Only shoot at one enemy per update
                }
            }
        }
    }

    void ShootAtEnemy(GameObject enemy)
    {
        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.localScale = new Vector3(attackSize, attackSize, 1f);
        Projectile projectile = bullet.GetComponent<Projectile>();


        if (projectile != null)
        {
            // Set the bullet's damage, target, and scale
            projectile.damage = attackDamage;
            projectile.target = enemy.transform;
            projectile.speed = ProjectileSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
