using UnityEngine;

public class ControladorInputJugador : MonoBehaviour
{
    public InformacionDePersonaje informacionDePersonaje;

    private ControlJugador controls;

    private Movimiento movimiento;
    private Dash dash;
    private Health health;

    private Camera mainCamera;
    private Energia energia;

    private void Awake()
    {
        controls = new ControlJugador();

        movimiento = GetComponent<Movimiento>();
        dash = GetComponent<Dash>();
        health = GetComponent<Health>();
        energia = GetComponent<Energia>();

        movimiento.Initialize(informacionDePersonaje);
        dash.Initialize(informacionDePersonaje);
        health.Initialize(informacionDePersonaje);
        energia.Initialize(informacionDePersonaje);

        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        Vector2 moveInput =
            controls.Jugador.Mover.ReadValue<Vector2>();

        movimiento.Move(moveInput, mainCamera);

        if (controls.Jugador.Dash.WasPressedThisFrame())
        {
            dash.Dashh();
        }
    }
}