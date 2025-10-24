    using UnityEngine;

    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private Vector2 _sensitivity;
        private Vector2 _rotation;
        private float maxVerticalAngle;


        private Vector2 GetInput()
        {
            Vector2 input = new Vector2(
                Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y")
            );

            return input;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Vector2 velocity = GetInput() * _sensitivity;
            _rotation += velocity * Time.deltaTime;
            _rotation.y = Mathf.Clamp(_rotation.y, -45f, 45f);
            transform.localEulerAngles = new Vector3(_rotation.y, _rotation.x, 0);
        }
    }
