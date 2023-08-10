using UnityEngine;

public class PickupReciever : MonoBehaviour {

    [SerializeField] private PlayerEntity m_PlayerEntity;

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Pickup pickup)) {
            pickup.m_PickupType.ExecutePickup(m_PlayerEntity);
            Destroy(other.gameObject);
        }
    }
}
