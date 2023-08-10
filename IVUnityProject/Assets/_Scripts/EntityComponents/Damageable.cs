using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public enum DamageFaction {
    Player,
    PlayerBullet,
    EnemyShip,
    EnemyBullet,
    KillZone,
}

/// <summary>
/// Anything with this script can have health and receive damage
/// </summary>
public class Damageable : MonoBehaviour {

    public DamageFaction m_Faction = DamageFaction.EnemyShip;

    // Assign In Editor
    public Renderer m_Mesh;
    private Color m_StartColor;

    public float m_MaxHealth = 20;
    private float m_CurrentHealth = 20;

    public UnityAction m_OnDeath;

    public UnityEventFloat m_OnHealthChange;

    private bool m_Dead;

    private void Awake() {
        m_CurrentHealth = m_MaxHealth;
        if (m_Mesh == null) {
            m_Mesh = GetComponent<Renderer>();
        }
        if (m_Mesh != null) {
            m_StartColor = m_Mesh.material.color;
        }
    }

    private void Start() {
        m_OnHealthChange.Invoke(m_CurrentHealth / m_MaxHealth);
    }

    public void AddHealth(int amt) {
        if (m_Dead) { return; }
        ChangeHealth(amt);
    }

    public void Damage(int amt) {
        // ignore if we're dead
        if (m_Dead) { return; }
        // reduce health
        ChangeHealth(-amt);

        if (m_CurrentHealth == 0) {
            Death();
        } else if (gameObject.activeInHierarchy) {
            StartCoroutine(DamageIndicatorSequence());
        }
    }

    public void ChangeHealth(int amt) {
        m_CurrentHealth += amt;
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 0, m_MaxHealth);
        m_OnHealthChange.Invoke(m_CurrentHealth / m_MaxHealth);
    }

    IEnumerator DamageIndicatorSequence() {
        if (m_Mesh == null) { yield break; }
        m_Mesh.material.color = Color.red;
        yield return new WaitForSeconds(.05f);
        m_Mesh.material.color = m_StartColor;
    }


    private void Death() {
        m_Dead = true;
        // let subscribers know
        if (m_OnDeath != null) {
            m_OnDeath.Invoke();
        }
    }

    // for pooling purposes
    public void Reset() {
        m_Dead = false;
        m_CurrentHealth = m_MaxHealth;
        m_Mesh.material.color = m_StartColor;
    }
}