using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public GameObject explosion;
    public GameObject bulletPrefab;
    public GameObject turret;
    public float aiHP = 100;

    public GameObject GetPlayer() 
    {
        return player;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
        DoDeath();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null) 
        {
            aiHP -= 10;
        }
    }

    void Fire() 
    {
        GameObject b = Instantiate(bulletPrefab, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
        anim.SetFloat("health", aiHP);
    }

    public void StopFiring() 
    {
        CancelInvoke("Fire");
    }

    public void StartFiring() 
    {
        InvokeRepeating("Fire", 2f, 2f);
    }

    public float GetHeatlh() 
    {
        return aiHP;
    }

    void DoDeath() 
    {
        if (aiHP <= 0)
        {
            GameObject explo = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(explo, 1.5f);
            Destroy(this.gameObject);
        }
        else 
        {
            return;
        }
    }
}
