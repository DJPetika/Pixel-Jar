using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChange; //break into before and after?
    public event Action day, night;

    //user info
    public int coinCount;
    public int curHealth;
    public int maxHealth = 100;
    //inventory?

    void Awake() {
        MakeSingleton();
    }

    void Start() {
        curHealth = maxHealth;
        coinCount = 500;
        UpdateGameState(GameState.Play);
    }

    void Update(){
        //update coin count display
        //update health count display + check for loss
    }

    void MakeSingleton(){
        if (instance == null) {
            instance = this;
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

    private void HandleStart(){

    }

    private void HandlePause(){

    }

    private void HandlePlay(){

    }

    private void HandleDay(){
        //spawn heros
    }

    private void HandleNight(){
        //spawn monsters (guests)
    }

    private void HandleShop(){
        //pull up shop ui
    }

    private void HandleLose(){
        //stop spawning of heros, 
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