using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    private const int MinCountPoints = 0;

    [SerializeField] private Medkit _prefab;
    [SerializeField] private int _count = 3;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        List<Transform> allPoints = new List<Transform>(_spawnPoints);

        int count = Mathf.Min(_count, allPoints.Count);

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(MinCountPoints, allPoints.Count);

            Instantiate(_prefab, allPoints[index].position, Quaternion.identity);
            allPoints.RemoveAt(index);
        }
    }
}