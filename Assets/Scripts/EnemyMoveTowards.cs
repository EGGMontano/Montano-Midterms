using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMoveTowards : MonoBehaviour
{
    public Material[] enemyColor;
    public float enemySpeed;
    public Transform enemyMob;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer=GetComponent<Renderer>();

        int randomMaterialIndex=Random.Range(0,enemyColor.Length);
        renderer.material=enemyColor[randomMaterialIndex];
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player=GameObject.FindWithTag("Player Tag");

        Transform MainPlayer=Player.transform;

        transform.position=Vector3.MoveTowards(transform.position,MainPlayer.transform.position,enemySpeed);

        EnemyRotate();
    }
    
    public void EnemyRotate()
    {
        Vector3 Direction=enemyMob.position-transform.position;
        Quaternion Rotation=Quaternion.LookRotation(Direction);
        transform.rotation=Quaternion.Lerp(transform.rotation,Rotation,1f*Time.deltaTime);
    }
}