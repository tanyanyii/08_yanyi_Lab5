using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : MonoBehaviour
{
    public float speed;
    public Rigidbody playerRigidbody;
    public GameObject cookie;
    public Text CookieCollected;
    public int cookiecount;

    // Start is called before the first frame update
    void Start()
    {
        CookieCollected.text = "Cookies Collected = " + cookiecount;
    }

    // Update is called once per frame
    void Update()
    {
        CookieCollected.text = "Cookie Collected = " + cookiecount;
        if (cookiecount >= 4)
        {
            SceneManager.LoadScene("GameWin");
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
        if (other.gameObject.tag == "cookie")
        {
            Destroy(other.gameObject);
            cookiecount++;
        }
        if (other.tag == "hazard")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
