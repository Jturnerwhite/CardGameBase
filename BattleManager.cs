using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//D:\UnityGithub\WhiteOpal\CardGame\Assets\Scripts\Combat\ConcreteClasses\Cards
public class BattleManager : MonoBehaviour
{
    [SerializeField]
    public Actor PlayerBase;

    [SerializeField]
    public Actor EnemyBase;

    private TurnManager turnManager;
    private Actor player;
    private Actor enemy;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize() {
        player = Instantiate(PlayerBase, new Vector3(-6, 0), Quaternion.identity) as Actor;
        enemy = Instantiate(EnemyBase, new Vector3(6, 0), Quaternion.identity) as Actor;

        turnManager = new TurnManager(true);
    }
}
