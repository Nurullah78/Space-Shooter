using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{    
    [SerializeField] private float tiltVertical, fireRate;
    [SerializeField] private int speed, tiltHorizontal;
    
    public Boundary boundary;
    public GameObject shot, shotSpawn;

    Rigidbody _physic;
    AudioSource _audioPlayer;

    private float _nextFire;

    void Start()
    {
        _physic = GetComponent<Rigidbody>();
        _audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey("space") && Time.time > _nextFire)
        {
            _nextFire = Time.time + fireRate;
            
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            _audioPlayer.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        _physic.velocity = movement * speed;
        
        Vector3 position = new Vector3(
            Mathf.Clamp(_physic.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(_physic.position.z, boundary.zMin, boundary.zMax));        
        
        _physic.position = position;

        _physic.rotation = Quaternion.Euler(
            _physic.velocity.z * tiltVertical,
            0,
            _physic.velocity.x * -tiltHorizontal);
    }
}
