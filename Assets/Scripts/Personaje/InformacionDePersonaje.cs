using UnityEngine;

[CreateAssetMenu(menuName = "Info de personaje")]
public class InformacionDePersonaje : ScriptableObject
{
    [Header("Stats")]
    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;

    [Header("Dash")]
    public float dashSpeedMultiplier = 3f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 0.5f;
    public float dashEnergyCost = 10f;

    [Header("Health")]
    public float maxHealth = 45f;

    [Header("Energia")]
    public float maxEnergy = 100f;
    public float energyRegen = 15f;
}