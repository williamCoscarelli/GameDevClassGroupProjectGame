using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D BulletRigidBody;
    public CurrentGun CurrentGun;
    

    public void ShootBulletInDirection(Vector2 Direction)
    {
        BulletRigidBody.AddForce(Direction,ForceMode2D.Impulse);
    }
    //
    
    void Start()
    {
        void Awake()
        {
            CurrentGun = FindAnyObjectByType<CurrentGun>();
        }
        BulletRigidBody.AddForce(CurrentGun.ReturnDirrectionOfBullet(),ForceMode2D.Impulse);
    }
    
}
