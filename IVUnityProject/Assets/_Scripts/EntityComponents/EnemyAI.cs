using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public enum EnemyState { Moving, Waiting, }

    public EnemyState m_EnemyState;

    public float m_Speed;
    public float m_Amplitude = 0;
    public float m_Frequency = 5;

    public float m_WaitTime = 5;
    private float _waitTime;
    public float m_WaitWhenXReached = -10;
    bool m_Waited = false;

    private float m_StartYPos;
    private float m_StartTime;

    private void Awake() {
        _waitTime = m_WaitTime;
    }

    public void Reset() {
        _waitTime = m_WaitTime;
        m_StartYPos = transform.position.y;
    }

    private void OnEnable() {
        // cache start frame height for sin wave movement
        m_StartTime = Time.time;
        m_StartYPos = transform.position.y;
    }

    public void Update() {
        switch (m_EnemyState) {
            case EnemyState.Moving:
            Moving();
            break;

            case EnemyState.Waiting:
            Waiting();
            break;
        }
    }

    public void Moving() {
        Vector3 currentPosition = transform.position;
        currentPosition += Vector3.left * Time.deltaTime * m_Speed;
        currentPosition.y = m_StartYPos + Mathf.Sin((Time.time + m_StartTime) * m_Frequency) * m_Amplitude;
        transform.position = currentPosition;

        if (currentPosition.x <= m_WaitWhenXReached && !m_Waited) {
            m_EnemyState = EnemyState.Waiting;
        }
    }

    public void Waiting() {
        _waitTime -= Time.deltaTime;
        if (_waitTime <= 0) { m_EnemyState = EnemyState.Moving; }
    }
}