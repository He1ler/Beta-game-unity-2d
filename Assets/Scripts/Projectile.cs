using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 EnemyPos;
    public void Starting(Vector3 EnemyPos)
    {
        this.EnemyPos = EnemyPos;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, EnemyPos, 250f * Time.deltaTime);
        if(transform.position == EnemyPos)
        {
            Destroy(this.gameObject);
        }
    }
}
