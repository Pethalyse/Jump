
using UnityEngine;
using UnityEngine.UI;

public class LifeGestion : MonoBehaviour
{

    //Player
    [SerializeField] private GameObject player;
    private BattleGestion bg;

    // Start is called before the first frame update
    void Awake()
    {
        bg  = player.GetComponent<BattleGestion>();
    }

    // Update is called once per frame
    void Update()
    {

        int i = 3;

        switch (bg.getCurrentHealth())
        {
            case 3:
                foreach(Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
                break;

            case 2:
                foreach(Transform child in transform)
                {
                    if(i < 2)
                    {
                        child.gameObject.SetActive(false);
                    }
                    else
                    {
                        child.gameObject.SetActive(true);
                    }
                    i--;
                }
                break;

            case 1:
                foreach (Transform child in transform)
                {
                    if (i < 3)
                    {
                        child.gameObject.SetActive(false);
                    }
                    else
                    {
                        child.gameObject.SetActive(true);
                    }
                    i--;
                }
                break;

            case 0:
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
                break;
        }
    }
}
