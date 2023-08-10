using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "Pickups/Health")]
public class PickupHealth : PickupType {

    public int m_HealthAmount = 5;

    public override void ExecutePickup(PlayerEntity playerEntity) {
        base.ExecutePickup(playerEntity);

        playerEntity.AddHealth(m_HealthAmount);
    }

}