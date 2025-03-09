using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1.5f;

    private float nextFireTime = 0f;
    private Transform player;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p) player = p.transform;
    }

    void Update()
    {
        if (player && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            dir.y = 0f;
            rb.linearVelocity = dir * 10f;
        }
    }
}
