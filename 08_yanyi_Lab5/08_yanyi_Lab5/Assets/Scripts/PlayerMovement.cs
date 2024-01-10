using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody playerRigidbody;
    public GameObject coin;
    public Text CoinCollected;
    public int coincount;

    // Start is called before the first frame update
    void Start()
    {
        CoinCollected.text = "Coins Collected = " + coincount;
    }

    // Update is called once per frame
    void Update()
    {
        CoinCollected.text = "Coins Collected = " + coincount;
        if(coincount>=4)
        {
            SceneManager.LoadScene("GamePlay_Level2");
        }
    }
    private void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(MoveHorizontal, 0, MoveVertical);
        transform.Translate(movement * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
            coincount++;
        }
        if (other.tag == "hazard")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
