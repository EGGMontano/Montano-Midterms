using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Transform bulletSpawner; //Bullet spawner
    public GameObject bulletPrefab, muzzle; //Bullet and muzzle
    public Material[] playerColor;
    private int currentMaterialIndex = 0; //Color checker
    public float bulletSpeed, fireRate; //Bullet speed and fire rate 
    private float BaseFireRate;

    // Start is called before the first frame update
    void Start()
    {
        BaseFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        fireRate-=Time.deltaTime; //Firerate
        if (fireRate<=0)
        {
            GameObject Bullet=Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            Rigidbody BulletRB=Bullet.GetComponent<Rigidbody>();

            BulletRB.AddForce(bulletSpawner.forward*bulletSpeed, ForceMode.Impulse);
            fireRate = BaseFireRate;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentMaterialIndex=(currentMaterialIndex + 1)%playerColor.Length;

            GetComponent<Renderer>().material=playerColor[currentMaterialIndex];

            Material PlayerMaterial=GetComponent<Renderer>().material;

            Renderer BulletColor=bulletPrefab.GetComponent<Renderer>();

            Renderer NozzleColor=muzzle.GetComponent<Renderer>();

            BulletColor.material=PlayerMaterial;
            NozzleColor.material=PlayerMaterial;
        }
    }
}
