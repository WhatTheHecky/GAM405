using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _normalspeed;
    [SerializeField] private Vector2 _sensitivity;
    private float _pitch;
    public GameObject _bullet;
    [SerializeField] private Transform playerCamera;
    private bool hasjumped;
    private float jumptimer;
    private bool _canshoot;
    private float _shoottimer;
    private int bulletCount = 40;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _normalspeed = 6f;
        hasjumped = false;
        jumptimer = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _canshoot = true;
        _shoottimer = 1f;
    }

    void Update()
    {
        Jump();
        
        if (hasjumped) jumptimer -= Time.deltaTime;

        if (jumptimer <= 0) hasjumped = false;

        if (hasjumped == false) jumptimer = 1.5f;
      
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * _normalspeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * _normalspeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            transform.position -= transform.right * _normalspeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * _normalspeed * Time.deltaTime;

        
        _shoottimer -= Time.deltaTime;
        if (_shoottimer <= 0)
            _canshoot = true;

       
        if (Input.GetKey(KeyCode.Mouse0) && _canshoot)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                float spreadX = Random.Range(-25f, 25f);
                float spreadY = Random.Range(-25f, 25f);

                Instantiate(
                    _bullet,
                    playerCamera.position + playerCamera.forward * 0.15f,
                    playerCamera.rotation * Quaternion.Euler(spreadX, spreadY, 0f)
                );
            }

            _canshoot = false;
            _shoottimer = 1f; // cooldown before next shot
        }

    }
    
    

    void LateUpdate()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity.y * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        _pitch -= mouseY;
        _pitch = Mathf.Clamp(_pitch, -45f, 45f);
        playerCamera.localEulerAngles = new Vector3(_pitch, 0f, 0f);
    }
    
    void Jump()
    {
        //write jmp code in here then call Jump(); in the update
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hasjumped == false)
            _rb.AddForce(0, 6, 0, ForceMode.Impulse); 
            hasjumped = true;
            
            Debug.Log("Jump");
        }
    }
}