using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
  private SpriteRenderer sprite;
  private CircleCollider2D circle;

  public GameObject collected;
  public int Score;
  // Start is called before the first frame update
  void Start()
  {
    sprite = GetComponent<SpriteRenderer>();
    circle = GetComponent<CircleCollider2D>();
  }
  void onTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.tag == "Player")
    {
      sprite.enabled = false;
      circle.enabled = false;
      collected.SetActive(true);

      GameController.instance.totalScore += Score;
      GameController.instance.UpdateScoreText();

      Destroy(gameObject, 0.3f);
    }
  }
}
