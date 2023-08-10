using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Pool[] m_EnemyPools;
    public Transform[] m_SpawnPositions;

    private float m_SpawnFrequence = 2f;
    private float m_Timer;

    private int m_TotalSpawned = 0;

    private bool m_Active = false;

    private void OnEnable() {
        GameManager.onGameStateChange += GameStateChange;
    }

    private void OnDisable() {
        GameManager.onGameStateChange -= GameStateChange;
    }

    private void GameStateChange(GameState gameState) {
        m_Active = gameState == GameState.GameActive;
        m_TotalSpawned = 0;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;

        if (m_SpawnPositions.Length > 0) {
            foreach (Transform pos in m_SpawnPositions) {
                Gizmos.DrawWireSphere(pos.position, 1f);
            }
        }
    }

    private void Update() {
        if (!m_Active) { return; }
        m_Timer += Time.deltaTime;
        if (m_Timer > m_SpawnFrequence) {
            m_Timer = 0;
            SpawnEnemy();
        }

    }

    private void SpawnEnemy() {
        m_TotalSpawned++;
        GameObject enemy = m_EnemyPools[Random.Range(0, m_EnemyPools.Length)].GetNext();
        enemy.transform.position = GetRandomPosition();

        if (enemy.TryGetComponent(out EnemyEntity enemyEntity)) {
            enemyEntity.Reset();
        }

        enemy.SetActive(true);
    }

    private Vector3 GetRandomPosition() {
        return m_SpawnPositions[Random.Range(0, m_SpawnPositions.Length)].position;
    }
}
