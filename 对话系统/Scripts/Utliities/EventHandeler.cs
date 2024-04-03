public static event Action<GameState> GameStateChangeEvent;

public static void CallGameStateChangeEvent(GameState gameState){
    GameStateChangeEvent?.Invoke(gameState);
}
