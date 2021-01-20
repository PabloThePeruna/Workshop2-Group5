using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] postiPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            int postiIndex = Random.Range(0, postiPrefabs.Length);
            Instantiate(postiPrefabs[postiIndex], new Vector3(0, 4, 0), postiPrefabs[postiIndex].transform.rotation);
        }
    }
}
