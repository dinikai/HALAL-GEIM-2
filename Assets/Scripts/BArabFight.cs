using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BArabFight : MonoBehaviour
{
    [SerializeField] private AudioSource boomSound, shotSound;
    [SerializeField] private GameObject porkBomb;
    [SerializeField] private Slider effenSlider, bArabSlider;
    [SerializeField] private Rigidbody2D rb;
    public float speed;
    private int bulletsCount = 0;
    private bool isRight, isLeft, isUp, isDown;
    public static bool Dogovoril = false;

    void Start()
    {
        StartCoroutine(AttackLoop());

    }

    public void PorkBombRain()
    {
        StartCoroutine(SpawnRain());
    }

    void FixedUpdate()
    {
        effenSlider.value = PlayerData.HP;

        if(isRight)
        {
            rb.MovePosition(rb.position + new Vector2(speed, 0));
        }
        if (isLeft)
        {
            rb.MovePosition(rb.position + new Vector2(-speed, 0));
        }
        if (isUp)
        {
            rb.MovePosition(rb.position + new Vector2(0, speed));
        }
        if (isDown)
        {
            rb.MovePosition(rb.position + new Vector2(0, -speed));
        }
    }

    public void Attack()
    {

    }

    public void Block()
    {

    }

    public void Right()
    {
        isRight = true;
    }

    public void Left()
    {
        isLeft = true;
    }

    public void Up()
    {
        isUp = true;
    }

    public void Down()
    {
        isDown = true;
    }

    public void NoMove()
    {
        isRight = false;
        isLeft = false;
        isUp = false;
        isDown = false;
    }

    IEnumerator SpawnRain()
    {
        while(bulletsCount < 20)
        {
            yield return new WaitForSeconds(0.1f);

            bulletsCount++;

            boomSound.Play();
            Instantiate(porkBomb, new Vector3(Random.Range(-6, 6), 6), Quaternion.Euler(0, 0, 0));
        }
    }

    IEnumerator AttackLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(10);

            if(Dogovoril)
            {
                bulletsCount = 0;
                StartCoroutine(SpawnRain());
            }
        }
    }
}
