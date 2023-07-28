using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public TMP_Text playerDeath;
    public GameObject turret;
    public GameObject explosion;
    public float playerHP = 100;
    public TMP_Text playerHPUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null) 
        {
            playerHP -= 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerHPUI.text = "Player HP: " + playerHP.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        DoDeath();
    }

    void Shoot() 
    {
        GameObject b = Instantiate(bulletPrefab, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    void DoDeath() 
    {
        if (playerHP <= 0) 
        {
            GameObject explo = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(explo, 1.5f);
            playerDeath.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Z))
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
        }
    }
}
