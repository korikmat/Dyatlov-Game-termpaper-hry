using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;
    // -- Objects --
    [SerializeField] private GameObject[] stones;
    [SerializeField] private AudioClip stoneHitSound;
    [Range (0f, 1f)]
    public float stoneHitVolume;
    [SerializeField] private GameObject bigfoot;
    private int stoneNumber;
    private float speedStoneAnimation;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        stoneNumber = 0;
        speedStoneAnimation = 1;
    }

    void Start()
    {
        foreach(GameObject invisibleWall in GameObject.FindGameObjectsWithTag("InvisibleWall"))
        {
            if (invisibleWall.GetComponent<MeshRenderer>())
            {
                invisibleWall.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    // Plays stones animations: first call - first stone, second call - second stone, third call - third call.
    public void startStoneAnimation()
    {
        if(stoneNumber < stones.Length)
        {
            if (stoneNumber > 0)
            {
                AudioManager.instance.PlayAudioClip(stoneHitSound, stones[stoneNumber].transform, stoneHitVolume);
            }
            stones[stoneNumber].GetComponent<Animator>().SetFloat("Speed", speedStoneAnimation);
            stones[stoneNumber++].GetComponent<Animator>().SetTrigger("Fall");
            speedStoneAnimation-=0.3f;
        }
        else
        {
            AudioManager.instance.PlayAudioClip(stoneHitSound, stones[2].transform, stoneHitVolume);
        }

    }

    // Plays bigfoot connected animation.
    public void startBigfootAttackAnimation()
    {
        if(bigfoot != null)
        {
            bigfoot.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
}