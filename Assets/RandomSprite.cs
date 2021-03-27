using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite[] sprites;

    private void Start()
    {
        sprite.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
