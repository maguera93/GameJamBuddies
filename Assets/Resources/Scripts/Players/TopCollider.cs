using UnityEngine;
using System.Collections;

public class TopCollider : MonoBehaviour {

	public playerMovement playerMov, playerStun, grounded;
	public Rigidbody playerRB;
	public int jumpForce;
	public int downForce;
	// Use this for initialization


	void Start () {
		playerMov = transform.GetComponentInParent<playerMovement> ();
		playerRB = transform.GetComponentInParent<Rigidbody> ();
		jumpForce = 1700;
		downForce = 1000;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{


		switch (playerMov.color)
		{
		case playerMovement.PlayerColor.RED:
			if (other.tag == "BluePlayer")
			{
				other.rigidbody.AddForce(Vector3.up * jumpForce);
				playerRB.rigidbody.AddForce(Vector3.down * downForce);
				if (playerMov.grounded) playerMov.stunned = true;

			}
            if (other.tag == "Greenlayer")
            {
                other.rigidbody.AddForce(Vector3.up * jumpForce);
                playerRB.rigidbody.AddForce(Vector3.down * downForce);
                if (playerMov.grounded) playerMov.stunned = true;
            }
            if (other.tag == "YellowPlayer")
            {
                other.rigidbody.AddForce(Vector3.up * jumpForce);
                playerRB.rigidbody.AddForce(Vector3.down * downForce);
                if (playerMov.grounded) playerMov.stunned = true;
            }
			break;
			
		case playerMovement.PlayerColor.BLUE:
			if (other.tag == "RedPlayer")
			{
				other.rigidbody.AddForce(Vector3.up * jumpForce);
				playerRB.rigidbody.AddForce(Vector3.down * downForce);
				if (playerMov.grounded) playerMov.stunned = true;
			}
            if (other.tag == "GreenPlayer")
            {
                other.rigidbody.AddForce(Vector3.up * jumpForce);
                playerRB.rigidbody.AddForce(Vector3.down * downForce);
                if (playerMov.grounded) playerMov.stunned = true;
            }
            if (other.tag == "YellowPlayer")
            {
                other.rigidbody.AddForce(Vector3.up * jumpForce);
                playerRB.rigidbody.AddForce(Vector3.down * downForce);
                if (playerMov.grounded) playerMov.stunned = true;
            }
			break;
        case playerMovement.PlayerColor.GREEN:
            if (other.tag == "RedPlayer")
            {
                other.rigidbody.AddForce(Vector3.up * jumpForce);
                playerRB.rigidbody.AddForce(Vector3.down * downForce);
                if (playerMov.grounded) playerMov.stunned = true;
            }
            if (other.tag == "BluePlayer")
            {
                other.rigidbody.AddForce(Vector3.up * jumpForce);
                playerRB.rigidbody.AddForce(Vector3.down * downForce);
                if (playerMov.grounded) playerMov.stunned = true;
            }
            if (other.tag == "YellowPlayer")
            {
                other.rigidbody.AddForce(Vector3.up * jumpForce);
                playerRB.rigidbody.AddForce(Vector3.down * downForce);
                if (playerMov.grounded) playerMov.stunned = true;
            }
            break;
        case playerMovement.PlayerColor.YELLOW:
            if (other.tag == "RedPlayer")
            {
                other.rigidbody.AddForce(Vector3.up * jumpForce);
                playerRB.rigidbody.AddForce(Vector3.down * downForce);
                if (playerMov.grounded) playerMov.stunned = true;
            }
            if (other.tag == "BluePlayer")
            {
                other.rigidbody.AddForce(Vector3.up * jumpForce);
                playerRB.rigidbody.AddForce(Vector3.down * downForce);
                if (playerMov.grounded) playerMov.stunned = true;
            }
            if (other.tag == "GreenPlayer")
            {
                other.rigidbody.AddForce(Vector3.up * jumpForce);
                playerRB.rigidbody.AddForce(Vector3.down * downForce);
                if (playerMov.grounded) playerMov.stunned = true;
            }
            break;
		}

	}
}
