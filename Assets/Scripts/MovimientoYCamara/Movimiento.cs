using UnityEngine;
using Unity.Cinemachine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadRotacion = 10f;

    private ControlJugador controls;
    private Vector2 inputMovimiento;

    public CinemachineCamera camera1;
    public CinemachineCamera camera2;
    private bool usandoCamara1 = true;
    public Camera mainCamera;


    private void Awake()
    {
        controls = new ControlJugador();
    }

    private void CambiarCamara()
{
    usandoCamara1 = !usandoCamara1;

    if (usandoCamara1)
    {
        camera1.Priority = 10;
        camera2.Priority = 0;
    }
    else
    {
        camera1.Priority = 0;
        camera2.Priority = 10;
    }
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
        inputMovimiento = controls.Jugador.Mover.ReadValue<Vector2>();

        if (controls.Jugador.CambiarCamara.WasPressedThisFrame())
        {
            CambiarCamara();
        }


        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 direccion =
            forward * inputMovimiento.y +
            right * inputMovimiento.x;

        transform.position +=
            direccion.normalized *
            velocidad *
            Time.deltaTime;

        if (direccion != Vector3.zero)
        {
            Quaternion objetivo =
                Quaternion.LookRotation(direccion);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                objetivo,
                velocidadRotacion * Time.deltaTime
            );
        }
    }
}