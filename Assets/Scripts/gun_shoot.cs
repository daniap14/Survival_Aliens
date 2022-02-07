using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gun_shoot : MonoBehaviour
{
    private Animator playerAnimator;

    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera Player;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;

    Camera cam;

    public TextMeshProUGUI text;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();

        cam = Camera.main;

        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //Text
        text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

      
       

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
           

            bulletsShot = bulletsPerTap;
            
            Shoot();
        }
        else if (!shooting)
        {
            playerAnimator.SetBool("shoot", false);
        }
       
    }
    private void Shoot()
    {
        readyToShoot = false;

        playerAnimator.SetBool("shoot", true);

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = Player.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(Player.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

        }



       

        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
           
    }

    

    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        playerAnimator.SetBool("shoot", false);
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

  
}
