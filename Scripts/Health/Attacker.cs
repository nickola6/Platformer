using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;

    public void Attack(Health target)
    {
        target.TakeDamage(_damage);
    }
}