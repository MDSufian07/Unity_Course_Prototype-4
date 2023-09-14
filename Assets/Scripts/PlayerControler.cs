using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 5.1f;
    private float powerUpStrength=15.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool powerup=false;

    public GameObject powerupIndector;
    // Start is called before the first frame update
    void Start()
    {
       
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward *forwardInput * speed);

        powerupIndector.transform.position = transform.position + new Vector3(0, -0.28f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerUp"))
        {
            powerup = true;
            powerupIndector.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdwonRoutine());
        }
    }
    IEnumerator PowerupCountdwonRoutine()
    {
        yield return new WaitForSeconds(7);
        powerup = false;
        powerupIndector.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")&& powerup)
        { 
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromPlayer = collision.gameObject.transform.position - playerRb.transform.position;
            enemyRb.AddForce(awayfromPlayer*powerUpStrength,ForceMode.Impulse);
        Debug.Log("Collide With: "+collision.gameObject.name+"With powerup set to "+ powerup);
        }
    }
}
