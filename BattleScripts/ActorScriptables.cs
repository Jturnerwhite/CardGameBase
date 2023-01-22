using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Resources;
using Characters;
using Characters.Classes;
using Characters.Enemies;
using Cards;
using UI;

public class ActorScriptables : MonoBehaviour
{
	public CharacterClass CharacterClass;
	public EnemyType EnemyType;

	public ResourceUI HealthUIPrefab;
	public ResourceUI ResourceUIPrefab;

	public Canvas Canvas;

	public Character characterStats { get; set; }
	public List<ResourceUI> ourResources { get; set; }

	[SerializeField]
	public List<CardData> cards { get; set; }

	public Transform resourceAnchor;

	public void Initialize(Character stats) {
		if(stats == null) {
			if(CharacterClass == CharacterClass.None) {
				characterStats = CharacterFactory.Get(EnemyType);
			} else {
				characterStats = CharacterFactory.Get(CharacterClass);
			}
		} else {
			characterStats = stats;
			CharacterClass = stats.CharacterClass;
		}

		ourResources = new List<ResourceUI>();
		MakeResourceBars();
	}

	void Start () {
		this.Canvas.worldCamera = Camera.main;
	}

	void FixedUpdate () {
		if(characterStats != null && characterStats.HP.Amount <= 0) {
			characterStats.HP.Amount = 0;
			Destroy(gameObject);
		}
	}

	private void MakeResourceBars() {
		int count = 1;

		MakeHealthUI(characterStats.HP);

		List<Resource> resources = characterStats.GetAllResources();
		foreach(var resource in resources) {
			// skip HP, we already did it
			if(resource.Type == (int)ResourceType.Health) {
				continue;
			}
			//0.36f for bars originally
			MakeResourceUI(resource, (-0.55f * count));
			count++;
		}
	}

	private void MakeHealthUI(Resource resource) {
		var newResourceUI = Instantiate(HealthUIPrefab) as ResourceUI;
		newResourceUI.Init(resource, transform, new Vector2((resourceAnchor.position.x), (resourceAnchor.position.y)));
		ourResources.Add(newResourceUI);
	}

	private void MakeResourceUI (Resource resource, float offset) {
		var newResourceUI = Instantiate(ResourceUIPrefab) as ResourceUI;
		newResourceUI.Init(resource, transform, new Vector2((resourceAnchor.position.x), (resourceAnchor.position.y + offset)));
		ourResources.Add(newResourceUI);
	}

	public void Click() {
		var EventManager = Camera.main.GetComponent<EventManager>();
		if(EventManager != null) {
			//EventManager.ActorClicked(this);
		}
	}

	public bool CanCast(Card card) {
		return characterStats.CanCastCard(card);
	}

	public void StartTurnTrigger() {
		characterStats.StartTurnTrigger();
	}

	public void EndTurnTrigger() {
		characterStats.EndTurnTrigger();
	}
}
