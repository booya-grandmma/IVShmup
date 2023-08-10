using UnityEngine;

public class BarUI : MonoBehaviour {

    public RectTransform m_Bar;

    private void Start() {
        if (m_Bar == null) {
            m_Bar = GetComponent<RectTransform>();
        }
    }

    public void SetBar(float alpha) {
        m_Bar.localScale = new Vector3(alpha, m_Bar.transform.localScale.y, m_Bar.transform.localScale.z);
    }

}