
using UnityEngine;

public class PnjDialogue : Dialogues
{

    [SerializeField]
    private TextManager textManager;

    [SerializeField] 
    private GameObject player;

    private int nbInteraction = 0;
    private int ancianInteraction = 0;
    private float range = 2f;

    private void Awake()
    {
        init();

        textManager = GameObject.Find("TextGestion").GetComponent<TextManager>();
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(codex.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (!textManager.getIsActive())
        {
            if (Vector2.Distance(player.transform.position, transform.position) <= range)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    textManager.activation(nom, codex[nbInteraction]);
                    ancianInteraction = nbInteraction;
                    if (nbInteraction < codex.Count - 1)
                    {
                        nbInteraction++;
                    }
                }
            }
        }
        else if (Vector2.Distance(player.transform.position, transform.position) >= range * 2)
        {
            textManager.desactivation();
            nbInteraction = ancianInteraction;
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range*2f);
    }

}
