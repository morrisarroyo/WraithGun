using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    
    PlayerCharacter _character;
    Rigidbody rigidbody;

    Vector3 _startingPosition;
    Vector3 _forwardMovement;
    Vector3 _horizontalMovement;
    bool _onFloor;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        _startingPosition = transform.position;
        _onFloor = true;
        _character = GameManager.instance.GetPlayerCharacter();
        _forwardMovement = _horizontalMovement = Vector3.zero;
        InputManager.OnInputHorizontal += SetHorizontalMovement;
        InputManager.OnInputVertical += SetForwardMovement;
        InputManager.OnInputSpace += Jump;
        InputManager.OnInputF += Respawn;
        InputManager.OnInputMouseXAxis += RotateCharacterHorizontally;
        InputManager.OnInputMouseYAxis += RotateCameraVertically;
    }

    private void OnDisable()
    {
        InputManager.OnInputHorizontal -= SetHorizontalMovement;
        InputManager.OnInputVertical -= SetForwardMovement;
        InputManager.OnInputSpace -= Jump;
        InputManager.OnInputF -= Respawn;
        InputManager.OnInputMouseXAxis -= RotateCharacterHorizontally;
        InputManager.OnInputMouseYAxis -= RotateCameraVertically;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 verticalVelocity = rigidbody.velocity.y * Vector3.up;
        rigidbody.velocity = (_horizontalMovement + _forwardMovement).normalized * _character.movementSpeed
                             + verticalVelocity;
    }
    
    void SetHorizontalMovement(float horizontal) {
        _horizontalMovement = horizontal * transform.right;
    }
    
    void SetForwardMovement(float forward) {
        _forwardMovement = forward * transform.forward;
    }

    void Jump()
    {
        if (_onFloor)
            rigidbody.AddForce( Vector3.up * _character.jumpFactor, ForceMode.Impulse);
    }

    void Respawn()
    {
        //Debug.Log("Respawn");
        Transform tr = transform;
        tr.position = _startingPosition;
        tr.rotation = Quaternion.identity;
        cam.transform.rotation = Quaternion.identity;
    }

    void RotateCharacterHorizontally(float rotation)
    {
        Transform tr = transform;
        tr.RotateAround(tr.position, tr.up, rotation * _character.rotationSpeed);
    }
    
    void RotateCameraVertically(float rotation)
    {
        Transform tr = transform;
        cam.transform.RotateAround(tr.position, tr.right, rotation * _character.rotationSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            //Debug.Log("On Floor");
            _onFloor = true;
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            //Debug.Log("Off Floor");
            _onFloor = false;
        }
    }
}
