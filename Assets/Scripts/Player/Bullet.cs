using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health hp = other.GetComponent<Health>();
            if (hp != null) hp.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
