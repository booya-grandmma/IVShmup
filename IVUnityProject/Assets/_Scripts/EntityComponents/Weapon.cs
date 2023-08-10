using UnityEngine;

public class Weapon : MonoBehaviour {

    public Pool m_BulletPool;

    public Transform m_SpawnLocation;

    /// <summary>
    /// Weapon fires automatically WITHOUT Button press
    /// </summary>
    public bool m_AutoFire;

    /// <summary>
    /// Bullets Per Second
    /// </summary>
    public float m_Frequency = 3;
    private float _frequencyTimer;

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, .2f);

        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }

    public void Update() {
        _frequencyTimer -= Time.deltaTime;

        if (m_AutoFire) {
            Fire();
        }
    }

    public void FireRequest() {
        if (m_AutoFire) { return; }
        Fire();
    }

    private void Fire() {
        if(_frequencyTimer <= 0) {
            _frequencyTimer = 1 / m_Frequency;
            SpawnBullet();
        }
    }

    private void SpawnBullet() {
        GameObject newBullet = m_BulletPool.GetNext();
        if (newBullet == null) { return; }
        newBullet.transform.position = m_SpawnLocation.position;
        newBullet.transform.rotation = m_SpawnLocation.rotation;
        newBullet.SetActive(true);
    }
}