using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    private  GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Tuhoaa pallon kun se osuu neliöön ja antaa pisteen
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Kirje")
            Destroy(collision.gameObject);
            gameManager.UpdateScore(1);
            Debug.Log("33733101 Tampere 10");
    }
}
