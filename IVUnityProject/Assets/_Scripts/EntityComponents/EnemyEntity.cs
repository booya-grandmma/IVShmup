using UnityEngine;

public class EnemyEntity : MonoBehaviour {

    // Assign in Editor
    public Damageable m_Damageable;
    public EnemyAI m_EnemyAI;

    public delegate void OnEnemyDead();
    public static event OnEnemyDead onEnemyDead;

    // In more complex situations I would create a scriptable object class which holds loot loadout information
    // to easily apply to multiple enemy entities, or even other objects entirely.
    public GameObject[] m_Loot;

    [Range(0,1)]
    public float m_LootDropChance = .2f;

    public void Reset() {
        m_Damageable.Reset();
        m_EnemyAI.Reset();
    }

    private void OnEnable() {
        m_Damageable.m_OnDeath += OnDeath;
        GameManager.onGameStateChange += OnGameStateChange;
    }

    private void OnDisable() {
        m_Damageable.m_OnDeath -= OnDeath;
        GameManager.onGameStateChange -= OnGameStateChange;
    }

    private void OnGameStateChange(GameState gameState) {
        if (gameState == GameState.Win) {
            gameObject.SetActive(false);
        }
    }

    private void OnDeath() {
        if (Random.value < m_LootDropChance) {
            Instantiate(m_Loot[Random.Range(0, m_Loot.Length)], transform.position, Quaternion.identity);
        }

        if (onEnemyDead != null) {
            onEnemyDead.Invoke();
        }

        gameObject.SetActive(false);
    }
}