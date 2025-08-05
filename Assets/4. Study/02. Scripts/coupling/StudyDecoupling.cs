// 커플링 문제점이 있는 코드
using UnityEngine;

public class StudyDecoupling : MonoBehaviour
{
    public class Player
    {
        public Enemy enemy;

        public void AttackEnemy()
        {
            enemy.TakeDamage(10f);
        }
    }

    public class Enemy
    {
        public float health = 10f;

        public void TakeDamage(float damage)
        {
            health -= damage;
        }
    }
}

