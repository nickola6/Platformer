using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private float _healValue = 25f;

    public float HealValue => _healValue;
}