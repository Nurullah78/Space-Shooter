using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody _physic;

    [SerializeField] float speed;
    
    void Start()
    {
        _physic = GetComponent<Rigidbody>();

        _physic.velocity = transform.forward * speed;
    }
}
