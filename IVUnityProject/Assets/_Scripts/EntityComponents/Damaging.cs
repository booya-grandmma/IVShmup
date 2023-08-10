using UnityEngine;

public class Damaging : MonoBehaviour {

    public DamageFaction m_Faction;

    public int m_Strength = 10;

    public bool m_DestroyOnCollide = true;

    private void OnTriggerEnter(Collider other) {

        // Damage faction matrix.
        // if this is the killzone, or the other is the killzone, set active = false;
        bool successfulHit = false;

        if (other.TryGetComponent(out Damageable damageable)) {
            if (damageable.m_Faction == m_Faction) { return; }
            if (damageable.m_Faction == DamageFaction.KillZone) { gameObject.SetActive(false); }
            switch (m_Faction) {
                case DamageFaction.EnemyShip:
                if (damageable.m_Faction == DamageFaction.Player) {
                    damageable.Damage(m_Strength);
                    successfulHit = true;
                }
                break;

                case DamageFaction.PlayerBullet:
                if (damageable.m_Faction == DamageFaction.EnemyShip) {
                    damageable.Damage(m_Strength);
                    successfulHit = true;
                }
                break;

                case DamageFaction.EnemyBullet:
                if (damageable.m_Faction == DamageFaction.Player) {
                    damageable.Damage(m_Strength);
                    successfulHit = true;
                }
                break;

                case DamageFaction.KillZone:
                    damageable.gameObject.SetActive(false);
                break;
            }
        }

        // setting active to false returns to the pool, do not destroy.
        if (successfulHit && m_DestroyOnCollide) { gameObject.SetActive(false); }
    }
}