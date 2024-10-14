using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public float maxTime;
    private float time;

    public float maxHeight;
    public float minHeight;

    public GameObject spikePrefab;
    GameObject spike;

    private void Start()
    {
        time = 1;
    }

    private void Update()
    {
        if (time > maxTime)
        {
            spike = Instantiate(spikePrefab);
            spike.transform.position = transform.position + new Vector3(0, Random.Range(minHeight, maxHeight), 0);
            time = 0;
        }
        time += Time.deltaTime;
        Destroy(spike, 8f);
    }
}
