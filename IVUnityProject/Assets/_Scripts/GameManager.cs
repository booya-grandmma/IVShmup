using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState {
    MainMenu = 0,
    GameActive = 1,
    GameOver = 2,
    Win = 3,
}

public class GameManager : MonoBehaviour {

    public delegate void OnGameStateChange(GameState gameState);
    public static event OnGameStateChange onGameStateChange;

    public GameState m_GameState;
    private bool m_EnteredState = false;

    private int m_EnemiesDefeated;

    private void Update() {
        switch (m_GameState) {
            case GameState.MainMenu:
            MainMenu();
            break;

            case GameState.GameActive:
            GameActive();
            break;

            case GameState.GameOver:
            GameOver();
            break;

            case GameState.Win:
            GameOver();
            break;
        }
    }

    public void MainMenu() {
        if (!m_EnteredState) {
            m_EnteredState = true;
            GameStateEntered();
        }
    }

    public void GameActive() {
        if (!m_EnteredState) {
            m_EnteredState = true;
            GameStateEntered();
        }
    }

    public void GameOver() {
        if (!m_EnteredState) {
            m_EnteredState = true;
            GameStateEntered();
        }
    }

    private void ChangeState(GameState newState) {
        m_EnteredState = false;
        m_GameState = newState;
        
    }

    private void GameStateEntered() {
        if (onGameStateChange != null) {
            onGameStateChange.Invoke(m_GameState);
        }
    }

    private void OnPlayerDeath() {
        ChangeState(GameState.GameOver);
    }

    private void OnStartGameButtonPress() {
        ChangeState(GameState.GameActive);
    }

    private void OnEnemyKilled() {
        m_EnemiesDefeated++;
        if (m_EnemiesDefeated >= 20) {
            ChangeState(GameState.Win);
        }
    }

    private void OnEnable() {
        PlayerEntity.onPlayerDeath += OnPlayerDeath;
        ButtonActions.onStartGameButtonPress += OnStartGameButtonPress;
        EnemyEntity.onEnemyDead += OnEnemyKilled;
    }

    private void OnDisable() {
        PlayerEntity.onPlayerDeath -= OnPlayerDeath;
        ButtonActions.onStartGameButtonPress -= OnStartGameButtonPress;
        EnemyEntity.onEnemyDead -= OnEnemyKilled;
    }
}
