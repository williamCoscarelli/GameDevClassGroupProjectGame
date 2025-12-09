using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGun : MonoBehaviour
{
    public GameObject Bullet;
    private string EquipedGun = "pistol";
    private Vector2 currentDirection;
    private bool Canfire = true;

    public void Reset()
    {
        ChangeGun("pistol");
    }
    public void ChangeGun(string newgun)
    {
        EquipedGun = newgun;
    }

    public void SetDirectionOfBullets(Vector2 direction)
    {
          currentDirection = direction;
    }

    public Vector2 ReturnDirrectionOfBullet()
    {
        return currentDirection;
    }

    public void Shootbullet(Vector2 BulletPath)
    {
        if (Canfire)
        {
            if (EquipedGun == "Minigun")
            {

                {
                    Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
                    SetDirectionOfBullets(BulletPath);
                    Canfire = false;
                }
                StartCoroutine(MinigunFireRate());
            }

            if (EquipedGun == "pistol")
            {

                {
                    Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
                    SetDirectionOfBullets(BulletPath);
                    Canfire = false;
                }
                StartCoroutine(PistolFireRate());
            }
            if (EquipedGun == "Shotgun")
            {

                {
                    Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
                    SetDirectionOfBullets(BulletPath);
                    StartCoroutine(ShotGunSpread(BulletPath));
                    StartCoroutine(ShotGunSpread(BulletPath));
                    Canfire = false;
                }
                StartCoroutine(ShotGunFireRate());
            }
        }
    }
    
    IEnumerator PistolFireRate()
    {
        yield return new WaitForSeconds(1f);
        Canfire = true;
    }
    
    IEnumerator MinigunFireRate()
    {
        yield return new WaitForSeconds(0.2f);
        Canfire = true;
    }
    
    IEnumerator ShotGunFireRate()
    {
        yield return new WaitForSeconds(0.5f);
        Canfire = true;
    }

    IEnumerator ShotGunSpread(Vector2 BulletPath)
    {
        if (BulletPath == new Vector2 (0, 20))
        {
            yield return new WaitForSeconds(0f);
            Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
            SetDirectionOfBullets(BulletPath + (new Vector2 (2,0)));
            yield return new WaitForSeconds(0f);
            Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
            SetDirectionOfBullets(BulletPath + (new Vector2 (-2,0)));
        }

        if (BulletPath == new Vector2(0, -20))
        {
            yield return new WaitForSeconds(0f);
            Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
            SetDirectionOfBullets(BulletPath + (new Vector2 (2,0)));
            yield return new WaitForSeconds(0f);
            Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
            SetDirectionOfBullets(BulletPath + (new Vector2 (-2,0)));
        }

        if (BulletPath == new Vector2(20, 0))
        {
            yield return new WaitForSeconds(0f);
            Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
            SetDirectionOfBullets(BulletPath + (new Vector2 (0,-2)));
            yield return new WaitForSeconds(0f);
            Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
            SetDirectionOfBullets(BulletPath + (new Vector2 (0,2)));
        }

        if (BulletPath == new Vector2(-20, 0))
        {
            yield return new WaitForSeconds(0f);
            Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
            SetDirectionOfBullets(BulletPath + (new Vector2 (0,-2)));
            yield return new WaitForSeconds(0f);
            Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
            SetDirectionOfBullets(BulletPath + (new Vector2 (0,2)));
        }
        
        
    }
}