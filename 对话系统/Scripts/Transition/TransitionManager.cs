public float fadeDuration;
private bool isFade;
private bool canTransition;

private void OnEnable()
{
    EventHandler.GameStateChangeEvent += OnGameStateChangeEvent;
}

private void OnDisable()
{
    EventHandler.GameStateChangeEvent -= OnGameStateChangeEvent;
}

private void Start()
{
    canTransition= true;
    StartCoroutine(TransitionToScene(string.Empty, startScene));
}

private void OnGameStateChangeEvent(GameState gameState)
{
    canTransition = gameState == GameState.GamePlay;
}

public void Transition(string from, string to)
{
    if (!isFade && canTransition)
    {
        StartCoroutine(TransitionToScene(from, to));
    }
}

private IEnumerator TransitionToScene(string from, string to)
{
    yield return Fade(1);
    if (from != string.Empty)
    {
        EventHandler.CallBeforeSceneUnloadEvent();
        yield return SceneManager.UnloadSceneAsync(from);
    }
}
