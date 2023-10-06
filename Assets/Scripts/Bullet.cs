using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1);
    }
    public void OnCollisionEnter(Collision coll)
    {
        //"Enemy" tag hits bullet collider.
        if(coll.gameObject.CompareTag("Enemy"))
        {
            //Color Check
            Renderer enemyRenderer=coll.gameObject.GetComponent<Renderer>();
            if(enemyRenderer!=null)
            {
                Renderer bulletRenderer=GetComponent<Renderer>();

                if (enemyRenderer.material.color==bulletRenderer.material.color)
                {
                    //Match
                    Destroy(coll.gameObject);
                    Destroy(gameObject);
                }
                else
                {
                    //Not match
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
