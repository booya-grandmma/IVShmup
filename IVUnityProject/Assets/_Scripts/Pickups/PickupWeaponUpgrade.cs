using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Upgrade", menuName = "Pickups/Weapon Upgrade")]
public class PickupWeaponUpgrade : PickupType {

    public int m_WeaponUpgrade = 1;

    public override void ExecutePickup(PlayerEntity playerEntity) {
        base.ExecutePickup(playerEntity);

        playerEntity.UpdateWeapon(m_WeaponUpgrade);
    }

}