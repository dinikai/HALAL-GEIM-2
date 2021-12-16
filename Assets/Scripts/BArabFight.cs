using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BArabFight : MonoBehaviour
{
    [SerializeField] private AudioSource boomSound, minigunSound, diorSound;
    [SerializeField] private GameObject porkBomb, effenBullet, effen, minigunBullet, bArab;
    [SerializeField] private Slider effenSlider, bArabSlider;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator backgroundAnim;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private BArabText arabText;
    [SerializeField] private Sprite arabKilled;
    public static int ArabHP = 50;
    public float minigunDelay = 10, bombDelay = 7;
    public float speed;
    private int bulletsCount = 0, minigunBulletsCount = 0;
    private bool isRight, isLeft, isUp, isDown;
    public static bool Dogovoril = false;
    public bool Killed = false;

    void Start()
    {
        effen = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(AttackLoop());
        StartCoroutine(MinigunAttackLoop());

        particles.Stop();
    }

    public void PorkBombRain()
    {
        StartCoroutine(SpawnRain());
    }

    void FixedUpdate()
    {
        effenSlider.value = PlayerData.HP;
        bArabSlider.value = ArabHP;

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

        if(PlayerData.HP <= 0)
        {
            PlayerData.HP = 100;
            ArabHP = 600;
            Dogovoril = false;

            SceneManager.LoadScene(ScenesName.RealLose);
        }

        if(ArabHP <= 0 && !Killed)
        {
            Killed = true;
            Dogovoril = false;

            arabText.PrintToText("*wwwhhhaaat. you killed me. its very fcking.. i think you very weak. but you... ...you SO STUPID. AHAHAHAHAHAHAHAHAHAHHAHAHAHAHA");
            arabText.SetEnable(false);
            bArab.SetActive(true);
            arabText.doomSource.Stop();
            particles.Stop();
            minigunSound.Stop();
            bArab.GetComponent<Animator>().SetBool("IsMinigun", false);
            Destroy(bArab.GetComponent<Animator>());
            bArab.GetComponent<SpriteRenderer>().sprite = arabKilled;

            bArab.GetComponent<Rigidbody2D>().MovePosition(new Vector2(8.5f, 0f));

            StopAllCoroutines();
        }
    }

    public void Attack()
    {
        Instantiate(effenBullet, effen.transform.position, Quaternion.Euler(0, 0, 0));
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
            yield return new WaitForSeconds(0.05f);

            bulletsCount++;

            boomSound.Play();
            Instantiate(porkBomb, new Vector3(Random.Range(-6, 6), 6), Quaternion.Euler(0, 0, 0));
        }
    }

    IEnumerator AttackLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(bombDelay);

            if(Dogovoril)
            {
                bulletsCount = 0;
                if(bombDelay > 4)
                    bombDelay -= 0.5f;

                StartCoroutine(SpawnRain());
            }
        }
    }

    IEnumerator MinigunAttack()
    {
        minigunSound.Play();
        bArab.GetComponent<Animator>().SetBool("IsMinigun", true);

        minigunBulletsCount = 0;

        while (minigunBulletsCount < 10)
        {
            Instantiate(minigunBullet, new Vector3(minigunBullet.transform.position.x, effen.transform.position.y + 0.5f, 0f), Quaternion.Euler(0f, 0f, 0f));
            minigunBulletsCount++;

            yield return new WaitForSeconds(0.3f);
        }

        minigunSound.Stop();
        bArab.GetComponent<Animator>().SetBool("IsMinigun", false);
    }

    IEnumerator MinigunAttackLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(minigunDelay);

            if(Dogovoril)
            {
                if(minigunDelay > 4)
                    minigunDelay -= 0.5f;

                StartCoroutine(MinigunAttack());
            }
        }
    }

    public IEnumerator BArabMusicSync()
    {
        yield return new WaitForSeconds(30.35f);

        Animator bArabAnim = bArab.GetComponent<Animator>();

        bArabAnim.StopPlayback();
        bArabAnim.Play("BArabIdle2", 0, 0);

        backgroundAnim.Play("IntegrateAMove", 0, 0);

        particles.Play();
    }
}
