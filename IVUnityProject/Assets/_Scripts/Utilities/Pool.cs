using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// Bare minimum pooled object script
/// </summary>

[CreateAssetMenu(fileName = "Object Pool", menuName = "Pooling/Pool")]
public class Pool : ScriptableObject {

    public GameObject m_PooledPrefab;
    public int m_StartingPoolSize;

    private List<GameObject> m_Pool;

    public enum PoolFullBehavior { Add, Block, }    
    public PoolFullBehavior m_PoolFullBehavior;

    public void Init() {
        // Fill Pool
        m_Pool = new List<GameObject>(m_StartingPoolSize);
        for (int x = 0; x < m_Pool.Count; x++) {
            m_Pool[x] = Instantiate(m_PooledPrefab);
        }
    }

    /// <summary>
    /// Always check for null and set active in script requesting pooled object
    /// </summary>
    public GameObject GetNext() {
        // Get next inactive
        for (int x = 0; x < m_Pool.Count; x++) {
            if (!m_Pool[x].activeSelf) {
                return m_Pool[x];
            }
        }

        // None available, add to pool or block request
        switch (m_PoolFullBehavior) {
            case PoolFullBehavior.Add:
            GameObject newObj = Instantiate(m_PooledPrefab);
            m_Pool.Add(newObj);
            return newObj;

            case PoolFullBehavior.Block:
            return null;
        }

        Debug.LogWarning("Should be unreachable");
        return null;
    }   
}