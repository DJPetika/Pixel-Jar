using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    private Dictionary<string, UnityEvent> eventDictionary;

    public GameState state;

    public static event Action<GameState> OnGameStateChange; //break into before and after?
    public event Action day, night;

    //user info
    public int coinCount;
    public int curHealth;
    public int maxHealth = 5*3; // 5 stars, 3 parts
    public float time;
    public float dayLength = 12.0f;
    public float nightLength = 12.0f;

    //inventory?

    public GameObject FrontDesk;

    void Awake() {
        MakeSingleton();
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    void Start() {
        curHealth = maxHealth;
        coinCount = 500;
        UpdateGameState(GameState.Night);
    }

    void Update(){
        //update coin count display
        //update health count display + check for loss
        //update timer
        time += Time.deltaTime;

        if(state == GameState.Day && time >= dayLength)
        {
            time = 0;
            UpdateGameState(GameState.Night);
        }
        else if(state == GameState.Night && time >= nightLength)
        {
            time = 0;
            UpdateGameState(GameState.Day);
        }
    }

    void MakeSingleton(){
        if (instance == null) {
            instance = this;
            this.Init();
            DontDestroyOnLoad(this);
        } else {
            Destroy(this);
        }
    }

    public void UpdateGameState(GameState newState){

        switch(newState){
            case GameState.Starting:
                HandleStart();
                break;
            case GameState.Pause:
                HandlePause();
                break;
            case GameState.Play:
                HandlePlay();
                break;
            case GameState.Day:
                HandleDay();
                break;
            case GameState.Night:
                HandleNight();
                break;
            case GameState.Shop:
                HandleShop();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        state = newState;
        OnGameStateChange?.Invoke(newState);

    }

    private void HandleStart()
    {
    }

    private void HandlePause(){

    }

    private void HandlePlay()
    {
    }

    private void HandleDay(){
        //spawn heros
        state = GameState.Day;
        TriggerEvent("Day");
    }

    private void HandleNight(){
        //spawn monsters (guests)
        state = GameState.Night;
        TriggerEvent("Night");
    }

    private void HandleShop(){
        //pull up shop ui
    }

    private void HandleLose(){
        //stop spawning of heros, 
    }

    public void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public void StopListening(string eventName, UnityAction listener)
    {
        if (instance == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        Debug.Log("EVENT TRIGGERED: " + eventName);
        try
        {
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
        catch
        {
            Debug.Log("Event Doesn't Exist.");
        }
    }

    public bool SpendMoney(int amount)
    {
        if(amount <= this.coinCount)
        {
            this.coinCount -= amount;
            this.TriggerEvent("Purchase");

            return true;
        }
        else
        {
            this.TriggerEvent("DeniedPurchase");

            return false;
        }
    }
}

public enum GameState {
    Starting,
    Pause,
    Play,
    Day,
    Night,
    Shop,
    Lose
}