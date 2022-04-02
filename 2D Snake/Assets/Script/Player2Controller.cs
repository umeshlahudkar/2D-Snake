using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    Vector2 direction;
    [SerializeField] GameObject snakeBodySegment;
    [SerializeField] ParticleSystemController particleSystemController;
    [SerializeField] ScoreController scoreController;
    [SerializeField] MassBurnerFoodController massBurnerFoodController;
    BoxCollider2D snakeSegmentCollider;
    BoxCollider2D snakeHeadCollider;
    List<GameObject> bodySegments;
    public SpecialPowerDisplay specialPowerDisplay;
    public GameObject gameOverDisplay;


    static public int minBodySefmentsCount = 2;
    static public int currentBodySefmentsCount;

    int massGainerFoodConsumeCount = 0;
    int currentShieldPower = 0;
    int massGainerScore = 10;

    float scoreBoostTime = 10f;
    float shieldActiveTime = 10f;
    float initialScoreBoostTime;
    float initialShieldActiveTime;

    bool scoreBoostActive = false;
    bool shieldActive = false;
    bool xMovement;
    bool yMovement;

    private void Start()
    {
        bodySegments = new List<GameObject>();
        bodySegments.Add(gameObject);

        snakeSegmentCollider = snakeBodySegment.GetComponent<BoxCollider2D>();
        snakeHeadCollider = gameObject.GetComponent<BoxCollider2D>();

        initialScoreBoostTime = scoreBoostTime;
        initialShieldActiveTime = shieldActiveTime;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !yMovement)
        {
            yMovement = true;
            xMovement = false;
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !yMovement)
        {
            yMovement = true;
            xMovement = false;
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && !xMovement)
        {
            yMovement = false;
            xMovement = true;
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && !xMovement)
        {
            yMovement = false;
            xMovement = true;
            direction = Vector2.right;
        }

        currentBodySefmentsCount = bodySegments.Count;

        if ((massGainerFoodConsumeCount >= PlayerConstants.scoreBoostPowerActivateAt) && !scoreBoostActive)
        {
            scoreBoostActive = true;
            massGainerScore += massGainerScore;
            currentShieldPower++;

            //scoreBoostSpecialPower();
        }

        if (scoreBoostActive)
        {
            scoreBoostTime -= Time.deltaTime;
            specialPowerDisplay.ScoreBoosterPower((int)scoreBoostTime);

            if (scoreBoostTime <= 0)
            {
                scoreBoostActive = false;
                massGainerScore = massGainerScore / 2;
                scoreBoostTime = initialScoreBoostTime;
                massGainerFoodConsumeCount = 0;
                specialPowerDisplay.ScoreEmptyDisplay();
            }
        }

        if (currentShieldPower >= PlayerConstants.shieldPowerActivateAt)
        {
            shieldActive = true;
            snakeSegmentCollider.isTrigger = true;
            snakeHeadCollider.isTrigger = true;
        }

        if (shieldActive)
        {
            shieldActiveTime -= Time.deltaTime;
            specialPowerDisplay.ShieldPower(((int)shieldActiveTime));

            if (shieldActiveTime <= 0)
            {
                shieldActive = false;
                shieldActiveTime = initialShieldActiveTime;
                currentShieldPower = 0;
                snakeSegmentCollider.isTrigger = false;
                snakeHeadCollider.isTrigger = false;
                specialPowerDisplay.ShieldEmptyDisplay();
            }
        }

    }

    private void FixedUpdate()
    {
        // Snake Movement
        for (int i = bodySegments.Count - 1; i > 0; i--)
        {
            bodySegments[i].transform.position = (bodySegments[i - 1].transform.position);
        }

        //transform.Translate(direction);
        transform.position = new Vector3(Mathf.Round(transform.position.x) + direction.x,
                                            Mathf.Round(transform.position.y) + direction.y,
                                            Mathf.Round(transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MassGainerFood"))
        {
            Grow();
            scoreController.ScoreIncrement(massGainerScore, "P2");
            particleSystemController.playRedFoodParticleEffect();
            massGainerFoodConsumeCount++;
            SoundManager.Instance.PlaySFX(SoundName.redFoodConsume);
        }

        if (collision.gameObject.CompareTag("MassBurnerFood"))
        {
            if (bodySegments.Count > minBodySefmentsCount)
            {
                Shrink();
                scoreController.ScoreIncrement(PlayerConstant.massBurnerScore, "P2");
                particleSystemController.playGreenFoodParticleEffect();
                massBurnerFoodController.DestroyMassBurnerFood();
                massGainerFoodConsumeCount = 0;
                SoundManager.Instance.PlaySFX(SoundName.greenFoodConsume);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snake") && !shieldActive)
        {
            this.enabled = false;
            particleSystemController.playDeadParticleEffect();
            gameOverDisplay.SetActive(true);
            ScoreController.score = 0;
            SoundManager.Instance.PlaySFX(SoundName.Death);
        }
    }


    // Snake size Increasing - Instantiate , assigning possition and added in List of GameObjects 
    void Grow()
    {
        GameObject segment = Instantiate(snakeBodySegment);
        segment.transform.position = bodySegments[bodySegments.Count - 1].transform.position; // Assigning Position
        bodySegments.Add(segment);
    }

    //Snake size Reduce - Destroying and Removing object from the list
    void Shrink()
    {
        Destroy(bodySegments[bodySegments.Count - 1].gameObject);
        bodySegments.RemoveAt(bodySegments.Count - 1);
    }
}

class PlayerConstants
{
    public const int scoreBoostPowerActivateAt = 6;
    public const int shieldPowerActivateAt = 2;
    public const int massBurnerScore = -5;
}

