using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllahFight : MonoBehaviour
{
    [SerializeField] private AudioSource boomSound, minigunSound, diorSound;
    [SerializeField] private GameObject effenBullet, effen, minigunBullet, bArab, pigBullet;
    [SerializeField] private Slider effenSlider, bArabSlider;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator backgroundAnim, cantAttack;
    [SerializeField] private AnimationClip pigThrowClip;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Sprite allahKilled;
    public static int AllahHP = 50;
    public float minigunDelay = 10, bombDelay = 7;
    public float speed;
    public float syncTime, pigSpeed;
    public int lastHp;
    private int pigCount;
    private bool isRight, isLeft, isUp, isDown;
    public static bool Dogovoril = false;

    void Start()
    {
        lastHp = PlayerData.HP;

        StartCoroutine(PigAttackLoop());
        StartCoroutine(BArabMusicSync());

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
            AllahHP = 600;
            Dogovoril = false;

            SceneManager.LoadScene(ScenesName.RealLose);
        }

        if (AllahHP <= 0 && !PlayerData.ArabKilled)
        {
            PlayerData.ArabKilled = true;

            bArab.SetActive(true);
            particles.Stop();
            minigunSound.Stop();
            bArab.GetComponent<Animator>().SetBool("IsPig", false);
            Destroy(bArab.GetComponent<Animator>());
            bArab.GetComponent<SpriteRenderer>().sprite = allahKilled;
            bArab.GetComponent<Rigidbody2D>().MovePosition(new Vector2(8.5f, 0f));

            PlayerData.SaveData();

            StopAllCoroutines();
        }

        GameObject[] pigs = GameObject.FindGameObjectsWithTag("Pig");
        foreach(GameObject pig in pigs)
        {
            Vector3 vector = new Vector2(rb.position.x, rb.position.y);
            pig.transform.position = Vector3.MoveTowards(pig.transform.position, vector, pigSpeed * Time.fixedDeltaTime);
        }
    }

    public void Attack()
    {
        /*if (PlayerData.EatPorkchop)
        {*/
            cantAttack.Play("HaramDetected", 0, 0);
        /*} else
        {
            Instantiate(effenBullet, effen.transform.position, Quaternion.Euler(0, 0, 0));
        //}*/
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
            yield return new WaitForSeconds(12);

            StartCoroutine(PigGo());
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

    public IEnumerator PigGo()
    {
        while (pigCount < 4)
        {
            yield return new WaitForSeconds(0.8f);

            Animator bArabAnim = bArab.GetComponent<Animator>();
            bArabAnim.Play("AllahThrowPig", 1, 0);

            yield return new WaitForSeconds(pigThrowClip.length);

            GameObject pig = Instantiate(pigBullet, bArab.transform.position, Quaternion.Euler(0, 0, 0));
            pigCount++;
        }

        pigCount = 0;
    }
}
