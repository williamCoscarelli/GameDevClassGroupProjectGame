using UnityEngine;

public class CurrentGun : MonoBehaviour
{
    public GameObject Bullet;
    private string EquipedGun = "pistol";
    private Vector2 currentDirection;
    
    public void ChangeGun(string newgun)
    {
        EquipedGun = newgun;
    }

    public void SetDirectionOfBullets(Vector2 direction)
    {
         Vector2 currentDirection = direction;
    }

    public Vector2 ReturnDirrectionOfBullet()
    {
        return currentDirection;
    }

    public void Shootbullet(Vector2 BulletPath)
    {
        if (EquipedGun == "Minigun")
        {
            Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
            SetDirectionOfBullets(BulletPath);
            
        }
    }
}