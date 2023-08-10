using UnityEngine;

public class Pickup : MonoBehaviour {

    public PickupType m_PickupType;

    private void Update() {
        transform.Rotate(Vector3.up, 360 * Time.deltaTime);
    }

}