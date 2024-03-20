using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    Rigidbody _physic;

    public int speed;
    
    void Start()
    {
        _physic = GetComponent<Rigidbody>();

        _physic.angularVelocity = Random.insideUnitSphere * speed;
    }
}
