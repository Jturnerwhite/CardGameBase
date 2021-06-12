using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Resources;
using Characters;
using Characters.Classes;
using Characters.Enemies;
using Cards;
using UI;

public class Actor : MonoBehaviour
{
	public CharacterClass CharacterClass;
	public EnemyType EnemyType;

	public ResourceUI HealthUIprefab;
	public ResourceUI ResourceUIPrefab;

	public Canvas Canvas;

	public Character characterStats { get; set; }
	public List<ResourceUI> ourResources { get; set; }

	public void Initialize(Character stats) {
		if(stats == null) {
			if(CharacterClass == CharacterClass.None) {
				characterStats = CharacterFactory.Get(EnemyType);
			} else {
				characterStats = CharacterFactory.Get(CharacterClass);
			}
		} else {
			characterStats = stats;
			CharacterClass = stats.characterClass;
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
		float offset = 2f; //1.5 orignally
		int count = 0;

		MakeHealthUI(characterStats.HP, offset);
		count++;

		List<Resource> resources = characterStats.GetAllResources();
		foreach(var resource in resources) {
			// skip HP, we already did it
			if(resource.Type == (int)ResourceType.Health) {
				continue;
			}
			//0.36f for bars originally
			MakeResourceUI(resource, (offset - (0.55f * count)));
			count++;
		}
	}

	private void MakeHealthUI(Resource resource, float offset) {
		var newResourceUI = Instantiate(HealthUIprefab) as ResourceUI;
		newResourceUI.Init(resource, transform, new Vector2((transform.localPosition.x), (transform.localPosition.y + offset)));
		ourResources.Add(newResourceUI);
	}

	private void MakeResourceUI (Resource resource, float offset) {
		var newResourceUI = Instantiate(ResourceUIPrefab) as ResourceUI;
		newResourceUI.Init(resource, transform, new Vector2((transform.localPosition.x), (transform.localPosition.y + offset)));
		ourResources.Add(newResourceUI);
	}

	public void Click() {
		var EventManager = Camera.main.GetComponent<EventManager>();
		if(EventManager != null) {
			EventManager.ActorClicked(this);
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
