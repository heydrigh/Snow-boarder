using UnityEngine;

public class PlayerController : MonoBehaviour
{

  Rigidbody2D rb2d;
  SurfaceEffector2D surfaceEffector2D;

  [SerializeField] float torqueAmount = 30;
  [SerializeField] float boostSpeed = 30;
  [SerializeField] float baseSpeed = 20;

  bool canMove = true;

  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
    surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
  }

  void Update()
  {
    if (canMove)
    {
      RotatePlayer();
      RespondToBoost();
    }

  }

  public void DisableControls()
  {
    canMove = false;
  }

  void RespondToBoost()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      surfaceEffector2D.speed = boostSpeed;
    }
    else
    {
      surfaceEffector2D.speed = baseSpeed;
    }
  }

  void RotatePlayer()
  {
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      rb2d.AddTorque(torqueAmount);
    }

    else if (Input.GetKey(KeyCode.RightArrow))
    {
      rb2d.AddTorque(-torqueAmount);
    }
  }
}
