using UnityEngine;

public class PlayerEntity : MonoBehaviour {

    public delegate void OnPlayerDeath();
    public static event OnPlayerDeath onPlayerDeath;

    public MovementController m_MovementController;
    public Damageable m_Damageable;
    public WeaponManager m_WeaponManager;

    private void GameStateChange(GameState gameState) {
        switch (gameState) {
            case GameState.MainMenu:
            m_MovementController.m_InputActive = false;
            break;

            case GameState.GameActive:
            m_MovementController.Reset();
            m_WeaponManager.Reset();
            m_Damageable.Reset();
            gameObject.SetActive(true);
            break;

            case GameState.GameOver:
            m_MovementController.m_InputActive = false;
            break;
        }
    }

    public void Reset() {
        m_Damageable.Reset();
        m_MovementController.Reset();
    }

    public void UpdateWeapon(int amt) {
        m_WeaponManager.UpdateWeapon(amt);
    }

    public void AddHealth(int amt) {
        m_Damageable.AddHealth(amt);
    }

    private void OnEnable() {
        m_Damageable.m_OnDeath += OnDeath;
        GameManager.onGameStateChange += GameStateChange;
    }

    private void OnDisable() {
        m_Damageable.m_OnDeath -= OnDeath;
        GameManager.onGameStateChange -= GameStateChange;
    }

    private void OnDeath() {
        if (onPlayerDeath != null) {
            onPlayerDeath.Invoke();
        }
        gameObject.SetActive(false);
    }
}
