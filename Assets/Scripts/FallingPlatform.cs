using UnityEngine;
using Unity.AI.Navigation;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private bool _destroyOnGround = true;
    // Esto le pongo yo true o falase dependiendo de mi plataforma
    // True = se rompe y False = se queda como escalera
    [SerializeField] private bool _rebakeNavMeshOnLand = false; // Esto lo marco true para mi FallingStaircases
    [SerializeField] NavMeshSurface navSurface;
    [SerializeField] NavMeshSurface navSurfaceBoss;



    private Rigidbody _rb;
    private bool _isFalling = false;
    private bool _hasDamagedPlayer = false;
    bool hasActivated = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        _rb.isKinematic = true; // Congelamos las físicas del objeto
    }

    public void Activate()
    {
        if (!hasActivated)
        {
            hasActivated = true;
            _isFalling = true;
            _rb.isKinematic = false; // Volvemos a activar las físicas
            _rb.useGravity = true;
        } 

        
    }

    void OnCollisionEnter(Collision other)
    {
        if (_isFalling)
        {
            // Si toca al jugador y no le han quitado vida ya
            if (other.gameObject.CompareTag("Player") && !_hasDamagedPlayer)
            {
                _hasDamagedPlayer = true;
                PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth) playerHealth.TakeDamage();
            }

            // Cuando toca el suelo 
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                if (_destroyOnGround) // Si es el SnowRoof
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    // Se usa como escalera
                    _isFalling = false;
                    _rb.isKinematic = true;
                    _rb.useGravity = false;
                    

                    if (_rebakeNavMeshOnLand)
                    {
                        if (navSurface) navSurface.BuildNavMesh();
                        if (navSurfaceBoss) navSurfaceBoss.BuildNavMesh();
                    }
                }
            }
        }

        
    }
}