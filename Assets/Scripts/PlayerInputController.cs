using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

    [SerializeField] [Range(0f, 15f)] float speed = 8f;
    private Vector2 move;
    private float directionX;
    private float directionZ;

    [SerializeField] bool jump;
    [SerializeField] float ThrustForce = 25000f;
    Rigidbody rb;

    // Lo que me hace falta para disparar //

    [SerializeField] GameObject _rocketPrefab;
    [SerializeField] Transform _fireStartPos;
    [SerializeField] LayerMask _clickableLayers;

    private bool _isAttack;
    private Vector2 _mousePos;
    private RaycastHit _hitMouse;
    private Vector3 _lookAtPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (jump)
        {
            Jump();
        }

        Move();

        // Opcional: gira el personaje hacia el ratón para disparar en cualquier dirección sin atravesarse
        transform.LookAt(new Vector3(_lookAtPos.x, transform.position.y, _lookAtPos.z));

        
        if (_isAttack)
        {
            Fire();
        }
    }

    private void Move()
    {
        directionX = move.x;
        directionZ = move.y;

        // Busqué que tengo que añadir Space.World al final para que W/A/S/D siempre mueva recto aunque el personaje gire
        transform.Translate(directionX * speed * Time.deltaTime, 0, directionZ * Time.deltaTime * speed, Space.World);
    }

    private void Jump()
    {
        Debug.Log("Jumping!");
        rb.AddRelativeForce(Vector3.up * ThrustForce * Time.fixedDeltaTime);
        jump = false;
    }

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }

    
    public void OnAttack(InputValue value)
    {
        _isAttack = value.isPressed;
    }

    public void OnMouseMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        _mousePos = input;
        UpdateMousePosInWorld();
    }

    
    private void UpdateMousePosInWorld()
    {
        Ray ray = Camera.main.ScreenPointToRay(_mousePos);
        Physics.Raycast(ray, out _hitMouse, 1000, _clickableLayers);

        // Uso _fireStartPos.position.y en vez de this.transform.position.y porque mi personaje tiene el pivote en los pies y asi la bola de nieve no se inclina porque
        // le fijo a posicion del firestartpos
        _lookAtPos = new Vector3(_hitMouse.point.x, _fireStartPos.position.y, _hitMouse.point.z);
    }

    private void Fire()
    {
        RocketMover newProjectile = Instantiate(_rocketPrefab, _fireStartPos.position, this.transform.rotation).GetComponent<RocketMover>();
        newProjectile.transform.LookAt(_lookAtPos);

        // Así disparo una bola por clic en vez de un montón
        _isAttack = false;
    }

   

   // No se si me funciona el gizmo este //


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.aquamarine;
        if (_fireStartPos)
        {
            Gizmos.DrawLine(_fireStartPos.position, _lookAtPos);
        }
        Gizmos.DrawWireSphere(_lookAtPos, 0.10f);
    }
}