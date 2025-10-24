using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    private float _speed;
    private float _destroytimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = 10;
        _destroytimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
        
      

    }
    
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Debug.Log(collision.gameObject.name);
    }

    void FireBullet()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        
        Destroy(gameObject, _destroytimer);
    }


 
}
