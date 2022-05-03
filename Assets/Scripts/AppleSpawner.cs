using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    Vector3 pos = new Vector3();
    private void RandomPosition()
    {
        pos.x = Mathf.Round(Random.Range(-15, 15));
        pos.y = Mathf.Round(Random.Range(-7, 7));
        pos.z = 0.00f;
        this.transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RandomPosition();
        }
    }
    private void Start()
    {
        RandomPosition();
    }
}
