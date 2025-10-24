using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
   private Rigidbody _rb;
    [SerializeField] private float _destroytimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _speed = 15;
        _destroytimer = 0.5f;
        _rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.isKinematic)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }

        if (!_rb.isKinematic)
        {
            _rb.linearVelocity = transform.forward * _speed;
        }
        _destroytimer -= 1*Time.deltaTime;
        if (_destroytimer <= 0) {Destroy(gameObject);}
        
        
        
    }

    void OnCollisionEnter(Collision hit)
    {
        _rb.isKinematic = false;
        Destroy(gameObject, 0.1f);
        
    }
}
