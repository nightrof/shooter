using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

    public event System.Action<Player> OnLocalPlayerJoined;
    private GameObject gameObject;
    private static GameManager m_Instance;
    public static GameManager Instance {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameManager();
                m_Instance.gameObject = new GameObject("_gameManager"); 
                m_Instance.gameObject.AddComponent<InputController>();
            } else { /* nothing to do */}

            return m_Instance;
        }
    }

    private InputController m_InputController;
    public InputController InputController {
        get {
            if (m_InputController == null)
            {
                m_InputController = gameObject.GetComponent<InputController>();
            } else { /* nothing to do */}

            return m_InputController;
        }
    }

    private Player m_localPlayer;
    public Player LocalPlayer {
        get {
            return m_localPlayer;
        }
        set {
            m_localPlayer = value;
            if (OnLocalPlayerJoined != null)
            {
                OnLocalPlayerJoined(m_localPlayer);
            } else { /* nothing to do */}
        }
    }
}
