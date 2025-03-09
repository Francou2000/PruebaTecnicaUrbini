using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    private Transform player;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p) player = p.transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }
}
