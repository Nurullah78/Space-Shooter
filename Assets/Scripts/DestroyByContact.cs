using UnityEngine;

public class DestroyByContact : MonoBehaviour
{    
    public GameObject explosion, playerExplosion;

    private GameController _gameController;

    private void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
       
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            _gameController.GameOver();
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
        _gameController.UpdateScore();
    }
}
