using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public GameObject[] m_WeaponGroups;

    public int m_CurrentWeapon;

    private void Awake() {
        if (m_WeaponGroups.Length < 1) { return; }
        foreach (GameObject obj in m_WeaponGroups) {
            obj.SetActive(false);
        }
    }

    public void Reset() {
        if (m_WeaponGroups.Length < 1) { return; }
        foreach (GameObject obj in m_WeaponGroups) {
            obj.SetActive(false);
        }
        m_WeaponGroups[0].SetActive(true);
    }

    public void UpdateWeapon(int amt) {
        m_CurrentWeapon += amt;
        m_CurrentWeapon = Mathf.Clamp(m_CurrentWeapon, 0, m_WeaponGroups.Length - 1);
        for (int x = 0; x < m_WeaponGroups.Length; x++) {
            m_WeaponGroups[x].SetActive(x == m_CurrentWeapon);
        }
    }
}