using UnityEngine;

public class MovementController : MonoBehaviour {

    // to disable Player Input.
    public bool m_InputActive = true;

    private Transform m_PlayerTrans;

    [SerializeField] private float m_Speed = 5f;
    private float _speed;

    private Vector3 _startPosition;

    private void Awake() {
        m_PlayerTrans = transform;
        _speed = m_Speed;
        _startPosition = transform.position;
    }

    void Update() {

        // on a larger scoped project this would come from a base input manager class.
        if (!m_InputActive) { return; }

        Vector2 moveVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(moveVec);
    }

    public void Reset() {
        m_InputActive = true;
        _speed = m_Speed;
        transform.position = _startPosition;
    }

    private void Move(Vector2 move) {
        Vector3 pos = m_PlayerTrans.position;
        pos += (Vector3)move * _speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -8, 40);
        pos.y = Mathf.Clamp(pos.y, -13, 13);
        m_PlayerTrans.position = pos;
    }
}