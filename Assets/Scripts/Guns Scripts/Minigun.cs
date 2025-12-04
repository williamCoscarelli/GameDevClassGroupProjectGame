using UnityEngine;

public class Minigun : BoxUpgrades
{

    public override  void EquipGun()
    {
        CurrentGun.ChangeGun("Minigun");
        base.EquipGun();
    }

}
