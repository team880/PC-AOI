using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public float shootSpeed = 0.1f; //time between projectiles
    private PlayerInput _input;

    void Start()
    {
        GetComponents();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot(_input.shootButton);
    }
    private void GetComponents()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Shoot(string shootBtn)
    {
        if(Input.GetButtonDown(shootBtn))
        {
            StartCoroutine("ShootRepeating",  projectile);
        }
        if(Input.GetButtonUp(shootBtn))
        {
            StopCoroutine("ShootRepeating");
        }
    }

    private IEnumerator ShootRepeating (GameObject projectile)
    {
        while(true)
        {
            var proj = Instantiate(projectile, transform.position, Quaternion.identity);
            proj.transform.up = _input.GetAimDirection(transform.position, _input.GetCursorPosition());
            yield return new WaitForSeconds(shootSpeed);
        }
    }
}
