using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{
    private InformacionDePersonaje data;
    private Movimiento movimiento;
    private Energia energia;

    private bool canDash = true;

    public void Initialize(InformacionDePersonaje informacion)
    {
        data = informacion;

        movimiento = GetComponent<Movimiento>();
        energia = GetComponent<Energia>();
    }

    public void Dashh()
    {
        if (!canDash)
            return;

        if (!energia.SpendEnergy(data.dashEnergyCost))
            return;

        StartCoroutine(DashRoutine());
    }

    private IEnumerator DashRoutine()
    {
        canDash = false;

        movimiento.SetSpeedMultiplier(
            data.dashSpeedMultiplier
        );

        yield return new WaitForSeconds(
            data.dashDuration
        );

        movimiento.SetSpeedMultiplier(1f);

        yield return new WaitForSeconds(
            data.dashCooldown
        );

        canDash = true;
    }
}