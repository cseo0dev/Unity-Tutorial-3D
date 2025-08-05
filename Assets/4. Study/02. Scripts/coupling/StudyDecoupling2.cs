using UnityEngine;

// Ŀ�ø�(������) �ذ��� ���� Interface Ȱ��
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