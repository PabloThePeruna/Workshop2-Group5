using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Tuhoaa póstin kun se osuu laatikkoon ja antaa pisteitä sen mukaan oliko oikea osoite
    private void OnCollisionEnter(Collision collision)
    {
        //Kirjelaatikko
        if (gameObject.tag == "KirjeLaatikko")
        {
            if ((collision.gameObject.tag == "Kirje"))
            {
                Destroy(collision.gameObject);
                gameManager.UpdateScore(1);
            }

            if ((collision.gameObject.tag == "Paketti") || (collision.gameObject.tag == "Kortti"))
            {
                gameManager.UpdateScore(-1);
                Destroy(collision.gameObject);
            }
        }

        //Korttilaatikko
        if (gameObject.tag == "KorttiLaatikko")
        {
            if ((collision.gameObject.tag == "Kortti"))
            {
                Destroy(collision.gameObject);
                gameManager.UpdateScore(1);
            }

            if ((collision.gameObject.tag == "Kirje") || (collision.gameObject.tag == "Paketti"))
            {
                gameManager.UpdateScore(-1);
                Destroy(collision.gameObject);
            }
        }

        //Pakettilaatikko
        if (gameObject.tag == "PakettiLaatikko")
        {
            if ((collision.gameObject.tag == "Paketti"))
            {
                Destroy(collision.gameObject);
                gameManager.UpdateScore(1);
            }

            if ((collision.gameObject.tag == "Kirje") || (collision.gameObject.tag == "Kortti"))
            {
                gameManager.UpdateScore(-1);
                Destroy(collision.gameObject);
            }
        }

        //Lattia. Jos putoaa lattialle, tulee miinuspiste
        if (gameObject.tag == "Lattia")
        {
            if ((collision.gameObject.tag == "Paketti") || (collision.gameObject.tag == "Kirje") || (collision.gameObject.tag == "Kortti"))
            {
                gameManager.UpdateScore(-1);
                Destroy(collision.gameObject);
            }

        }
    
        
    }
}
