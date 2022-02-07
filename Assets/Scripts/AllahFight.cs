using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllahFight : MonoBehaviour
{
    [SerializeField] private AudioSource boomSound, sirenSound, pigSound, diorSound, deathSound;
    [SerializeField] private GameObject effenBullet, effen, minigunBullet, bArab, pigBullet;
    [SerializeField] private Slider effenSlider, bArabSlider;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator backgroundAnim, cantAttack, hitZoneRight, hitZoneLeft;
    [SerializeField] private AnimationClip pigThrowClip, hitZoneWarnClip;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Sprite allahKilled;
    [SerializeField] private float decrementPig, decrementLoop, pigLoopMaxDecrement, pigMaxDecrement;
    public static int AllahHP = 2;
    public float minigunDelay = 10, bombDelay = 7;
    public float speed, loopTimeDecrement, pigTimeDecrement;
    public float syncTime, pigSpeed;
    public int lastHp;
    private int pigCount;
    private bool isRight, isLeft, isUp, isDown, fireFlag;
    public static bool Dogovoril = false;

    void Start()
    {
        lastHp = PlayerData.HP;

        StartCoroutine(PigAttackLoop());
        StartCoroutine(BArabMusicSync());
        StartCoroutine(KulakAttackLoop());

        particles.Stop();
    }

    void FixedUpdate()
    {
        effenSlider.value = PlayerData.HP;
        bArabSlider.value = AllahHP;

        if (isRight)
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

        if (PlayerData.HP <= 0)
        {
            PlayerData.HP = lastHp;
            AllahHP = 400;
            Dogovoril = false;

            SceneManager.LoadScene(ScenesName.AllahLose);
        }

        if (AllahHP <= 200 && !fireFlag)
        {
            Animator bArabAnim = bArab.GetComponent<Animator>();
            bArabAnim.Play("AllahFire", 1, 0);
            bArabAnim.SetBool("IsFire", true);

            fireFlag = true;
        }

        if (AllahHP <= 0 && !PlayerData.AllahKilled)
        {
            PlayerData.AllahKilled = true;

            bArab.SetActive(true);
            particles.Stop();
            pigSound.Stop();
            Destroy(bArab.GetComponent<Animator>());
            bArab.GetComponent<Rigidbody2D>().MovePosition(new Vector2(8.5f, 0f));
            Destroy(backgroundAnim);
            GetComponent<AudioSource>().Stop();
            StopAllCoroutines();
            StartCoroutine(AllahKill());

            PlayerData.SaveData();
        }

        GameObject[] pigs = GameObject.FindGameObjectsWithTag("Pig");
        foreach(GameObject pig in pigs)
        {
            Vector3 vector = new Vector2(rb.position.x, rb.position.y);
            pig.transform.position = Vector3.MoveTowards(pig.transform.position, vector, pigSpeed * Time.fixedDeltaTime);
        }
    }

    private IEnumerator AllahKill()
    {
        yield return new WaitForSeconds(2);
        bArab.SetActive(false);
        deathSound.Play();

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(ScenesName.Game1);
    }

    public void Attack()
    {
        if (PlayerData.EatPorkchop)
        {
            cantAttack.Play("HaramDetected", 0, 0);
        } else
        {
            Instantiate(effenBullet, effen.transform.position, Quaternion.Euler(0, 0, 0));
        }
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

    public void NoRight()
    {
        isRight = false;
    }

    public void NoLeft()
    {
        isLeft = false;
    }

    public void NoUp()
    {
        isUp = false;
    }

    public void NoDown()
    {
        isDown = false;
    }

    private IEnumerator PigAttackLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(12 - loopTimeDecrement);
            if(loopTimeDecrement < pigLoopMaxDecrement)
            {
                loopTimeDecrement += decrementLoop;
            }

            StartCoroutine(PigGo());
        }
    }

    private IEnumerator KulakAttackLoop()
    {
        while (true)
        {
            if (fireFlag)
            {
                yield return new WaitForSeconds(10 - loopTimeDecrement);
                if (loopTimeDecrement < pigLoopMaxDecrement)
                {
                    loopTimeDecrement += decrementLoop;
                }

                StartCoroutine(KulakGo());
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator BArabMusicSync()
    {
        yield return new WaitForSeconds(syncTime);

        Animator bArabAnim = bArab.GetComponent<Animator>();
        bArabAnim.StopPlayback();
        bArabAnim.Play("AllahIdle2", 0, 0);

        backgroundAnim.Play("IntegrateAMove", 0, 0);

        particles.Play();
    }

    private IEnumerator PigGo()
    {
        while (pigCount < 4)
        {
            yield return new WaitForSeconds(0.8f - pigTimeDecrement);
            if (pigTimeDecrement < pigMaxDecrement)
            {
                pigTimeDecrement += decrementPig;
            }

            Animator bArabAnim = bArab.GetComponent<Animator>();
            bArabAnim.Play("AllahThrowPig", 1, 0);

            yield return new WaitForSeconds(pigThrowClip.length);

            GameObject pig = Instantiate(pigBullet, bArab.transform.position, Quaternion.Euler(0, 0, 0));
            pigSound.Play();
            pigCount++;
        }

        pigCount = 0;
    }

    public IEnumerator KulakGo()
    {
        int zoneNum = Random.Range(0, 2);
        if(zoneNum == 0)
        {
            hitZoneLeft.Play("HitZoneWarn");
        } else
        {
            hitZoneRight.Play("HitZoneWarn");
        }
        sirenSound.Play();
        yield return new WaitForSeconds(hitZoneWarnClip.length + 0.5f);

        if (zoneNum == 0)
        {
            hitZoneLeft.Play("HitZoneDamage");
            HitZone zone = hitZoneLeft.GetComponent<HitZone>();
            if(zone.inZone)
            {
                effen.GetComponent<Animator>().Play("EffewbergHurt", 0, 0);
                PlayerData.HP -= 6;
                effenSlider.value = PlayerData.HP;
            }
        }
        else
        {
            hitZoneRight.Play("HitZoneDamage");
            HitZone zone = hitZoneRight.GetComponent<HitZone>();
            if (zone.inZone)
            {
                effen.GetComponent<Animator>().Play("EffewbergHurt", 0, 0);
                PlayerData.HP -= 6;
                effenSlider.value = PlayerData.HP;
            }
        }
        Animator bArabAnim = bArab.GetComponent<Animator>();
        bArabAnim.Play("FireKulak", 1, 0);
        boomSound.Play();
    }
}
