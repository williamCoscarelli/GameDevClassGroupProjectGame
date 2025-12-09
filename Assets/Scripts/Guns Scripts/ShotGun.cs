using UnityEngine;

public class ShotGun : BoxUpgrades
{
    public override  void EquipGun()
    {
        CurrentGun.ChangeGun("Shotgun");
        base.EquipGun();
    }
}
