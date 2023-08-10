using UnityEngine;

public class Bullet : Damaging {

    public float m_Speed = 20;

    public float m_MaxDistanceToOrigin = 100;

    protected void Update() {
        Vector3 dir = transform.forward;
        transform.position += dir * Time.deltaTime * m_Speed;

        // just in case a bullet misses the destruction collider
        if (transform.position.x >= m_MaxDistanceToOrigin || transform.position.x <= -m_MaxDistanceToOrigin || transform.position.y >= m_MaxDistanceToOrigin || transform.position.y <= -m_MaxDistanceToOrigin) {
            gameObject.SetActive(false);
        }
    }   
}