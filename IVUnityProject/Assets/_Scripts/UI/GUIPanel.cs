using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIPanel : MonoBehaviour
{
    public CanvasGroup m_CanvasGroup;

    public GameState m_GameState;

    private void OnEnable() {
        GameManager.onGameStateChange += GameStateChange;
    }

    private void OnDisable() {
        GameManager.onGameStateChange -= GameStateChange;
    }

    private void GameStateChange(GameState gameState) {
        // enable or disable if this is the gamestate we have set
        bool active = gameState == m_GameState;
        m_CanvasGroup.alpha = active ? 1 : 0;
        m_CanvasGroup.blocksRaycasts = active;
        m_CanvasGroup.interactable = active;

        if (active) {
            // Select first located selectable
            foreach (Selectable selectable in GetComponentsInChildren<Selectable>()) {
                EventSystem.current.SetSelectedGameObject(selectable.gameObject);
                return;
            }
        }

    }
}
