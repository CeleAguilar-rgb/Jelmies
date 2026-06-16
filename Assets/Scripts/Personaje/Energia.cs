using UnityEngine;

public class Energia : MonoBehaviour
{
    private InformacionDePersonaje data;
    private float lastEnergyShown;

    public float CurrentEnergy { get; private set; }

    public void Initialize(InformacionDePersonaje informacion)
    {
        data = informacion;
        CurrentEnergy = data.maxEnergy;
    }

    private void Update()
    {
        if (CurrentEnergy < data.maxEnergy)
        {
            CurrentEnergy += data.energyRegen * Time.deltaTime;
            CurrentEnergy = Mathf.Min(CurrentEnergy, data.maxEnergy);
            if (Mathf.Abs(CurrentEnergy - lastEnergyShown) >= 1f)
            {
                Debug.Log($"Energía: {CurrentEnergy:F0}/{data.maxEnergy}");
                lastEnergyShown = CurrentEnergy;
            }
        }
    }

    public bool SpendEnergy(float amount)
    {
        if (CurrentEnergy < amount){
            return false;
            }

        CurrentEnergy -= amount;
        Debug.Log($"Energía restante: {CurrentEnergy}");
        return true;
    }
}