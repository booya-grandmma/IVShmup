using UnityEngine;

public class PoolingSystem : MonoBehaviour {
    public Pool[] m_Pools;

    public void Awake() {
        foreach(Pool pool in m_Pools) { pool.Init(); }
    }
}