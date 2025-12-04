using UnityEngine;

public class BoxUpgrades : MonoBehaviour
{
    public CurrentGun CurrentGun;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FBIPlayer")
        {
            EquipGun();
            Destroy(gameObject);
        }
    }
    public  virtual void EquipGun()
    {
        print("gun not equiped");
    }
}
