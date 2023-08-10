using UnityEngine;

/// <summary>
/// Base Pickup type
/// </summary>

// abstract scriptable object shouldn't be created
//[CreateAssetMenu(fileName = "Pickup", menuName = "Pickups/Pickup")]
public abstract class PickupType : ScriptableObject {

    public virtual void ExecutePickup(PlayerEntity playerEntity) { }

}