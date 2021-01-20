using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] postiPrefabs;

    // kuinka pitkään pitää odotella että torvesta alkaa tursuamaan
    public float startDelay = 2;

    //Kuinka pitkä aika on kahden tursauksen välillä, tällä hetkellä se on 5 sekunttia
    public float spawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPosti", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Turauttaa torvesta tulemaan jonkun kolmesta posti typpistä (kirjeen, kortin tai paketin)
    void SpawnRandomPosti()
    {
        int postiIndex = Random.Range(0, postiPrefabs.Length);
        Instantiate(postiPrefabs[postiIndex], new Vector3(0, 4, 0), postiPrefabs[postiIndex].transform.rotation);
    }
}
