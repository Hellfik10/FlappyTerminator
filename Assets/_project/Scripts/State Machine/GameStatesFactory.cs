using TMPro;
using UnityEngine;

public class GameStatesFactory : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PointCollector _pointCollector;
    [SerializeField] private PointCollectorView _pointCollectorView;
    [Header("MainMenu")]
    [SerializeField] private Canvas _mainMenu;
    [SerializeField] private ButtonClickHandler _playGameButton;
    [Header("PauseMenu")]
    [SerializeField] private Canvas _pauseMenu;
    [SerializeField] private ButtonClickHandler _continueGameButton;
    [Header("EndGameMenu")]
    [SerializeField] private Canvas _gameOverMenu;
    [SerializeField] private ButtonClickHandler _restartButton;
    [SerializeField] private TMP_Text _scoreTextArea;

    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _stateMachine.AddState(new MainMenuState(_stateMachine, _mainMenu, _playGameButton, _inputHandler));
        _stateMachine.AddState(new GameState(_stateMachine, _inputHandler, _player, _pointCollectorView));
        _stateMachine.AddState(new PauseState(_stateMachine, _inputHandler, _pauseMenu, _continueGameButton));
        _stateMachine.AddState(new EndGameState(_stateMachine, _gameOverMenu, _restartButton, _inputHandler, _pointCollector, _scoreTextArea));
        _stateMachine.AddState(new SceneLoadingState(_stateMachine));
        _stateMachine.SetState<MainMenuState>();
    }
}
