// Script for projectiles (Wizward)
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 EnemyPos;
    public void Starting(Vector3 EnemyPos)//Starting function for saving enemy position as end point
    {
        this.EnemyPos = EnemyPos;
    }
    private void Update()//moving projectile with animation
    {
        transform.position = Vector2.MoveTowards(transform.position, EnemyPos, 250f * Time.deltaTime);
        if(transform.position == EnemyPos)
        {
            Destroy(this.gameObject);
        }
    }
}
