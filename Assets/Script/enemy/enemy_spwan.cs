using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spwan : MonoBehaviour
{
    public GameObject prefab;
    public float radius;
    public int number;
    public Transform c;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            GameObject enemy = Instantiate(prefab, c);
            float x = radius * Mathf.Sin(Random.Range(0, 100) / Mathf.PI);
            float z = radius * Mathf.Cos(Random.Range(0, 100) / Mathf.PI);
            enemy.transform.position = new Vector3(53+x, 5, 70+z);
        
        }
    }

}
