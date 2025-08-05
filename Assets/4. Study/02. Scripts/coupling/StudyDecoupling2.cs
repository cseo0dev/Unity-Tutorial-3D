using UnityEngine;

// 커플링(의존도) 해결을 위해 Interface 활용
public interface IDamageable
{
    void TakeDamage(float damage);
}

public class StudyDecoupling2 : MonoBehaviour
{
    public class Player
    {
        public void AttackEnemy(IDamageable target, float damage)
        {
            target.TakeDamage(damage);
        }
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        public float health = 10f;

        public void TakeDamage(float damage)
        {
            health -= damage;
        }
    }
}