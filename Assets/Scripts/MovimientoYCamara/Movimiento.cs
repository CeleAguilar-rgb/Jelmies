using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadRotacion = 10f;
    public Transform camara;

    private ControlJugador controls;
    private Vector2 inputMovimiento;

    private void Awake()
    {
        controls = new ControlJugador();
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

        Vector3 forward = camara.forward;
        Vector3 right = camara.right;

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