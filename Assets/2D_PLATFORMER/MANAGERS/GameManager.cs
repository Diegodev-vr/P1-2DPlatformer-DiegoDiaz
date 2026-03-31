using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ///// singleton pattern for easy access from other scripts, like the UI scripts
    ///// could be access from other scripts like this: GameManager.Instance.TakeDamage(10f);
    ///// subscribe and unsubcribe tho the events like this:
    ///// GameManager.Instance.OnHealthChanged += UpdateHealthBar; and GameManager.Instance.OnHealthChanged -= UpdateHealthBar;
    public static GameManager Instance { get; private set; }

    ///// variables to track the player's health and points
    [SerializeField] private float maxHealth = 100f;

    private float m_CurrentHealth;
    private int m_PointsCount;

    ///// events to notify the UI when the health or points change, using Action from System namespace
    ///// the float parameter for OnHealthChanged is the normalized health value
    ///// (current health divided by max health) so that the UI can easily update the health bar slider
    public event Action<float> OnHealthChanged;
    public event Action<int> OnPointsChanged;

    private void Awake()
    {
        ///// implement the singleton pattern, make sure there is only one instance of the GameManager in the scene
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        ///// initialize the player's health and points at the start of the game
        m_CurrentHealth = maxHealth;
    }
    ///// function to apply damage to the player, this will be called by the enemy scripts when they hit the player
    public void TakeDamage(float amount) 
    {
        if (amount == 0) return;
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth - amount, 0f, maxHealth);
        OnHealthChanged?.Invoke(m_CurrentHealth / maxHealth);
    }
    ///// function to heal the player, this will be called by the healing item scripts
    public void Heal(float amount) 
    {
        if (amount == 0) return;
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth + amount, 0f, maxHealth);
        OnHealthChanged?.Invoke(m_CurrentHealth / maxHealth);
    }
    // TODO: increment m_PointsCount, fire OnPointsChanged, Debug.Log
    public void AddPoint(int amount) 
    {
        if (amount == 0) return;
        m_PointsCount += amount;
        OnPointsChanged?.Invoke(m_PointsCount);
        Debug.Log($"Points count: {m_PointsCount}");
    }
    ///// these context menu functions are for testing purposes,
    ///// they will appear in the inspector when you right click on the component, so you can easily test the TakeDamage,
    ///// Heal and AddPoint functions without having to set up the enemy or healing item scripts
    ///// this could be called from other script like this:
    ///// GameManager.Instance.TestTakeDamage(); but it's more convenient to call it from the inspector for quick testing

    [ContextMenu("Test: Take 10 Damage")]
    public void TestTakeDamage() => TakeDamage(10f);

    [ContextMenu("Test: Heal 20")]
    public void TestHeal() => Heal(20f);

    [ContextMenu("Test: Add Point")]
    public void TestAddPoint() => AddPoint(1);
}