
public class GameState : State
{
    private PointCollectorView _pointCollectorView;
    private InputHandler _inputHandler;
    private Character _player;

    public GameState(StateMachine stateMachine, InputHandler inputHandler, Character player, PointCollectorView pointCollectorView) : base(stateMachine)
    {
        _inputHandler = inputHandler;
        _player = player;
        _pointCollectorView = pointCollectorView;
    }

    public override void Enter()
    {
        _pointCollectorView.gameObject.SetActive(true);
        _inputHandler.Paused += StartPause;
        _player.Destroyed += EndGame;
    }

    public override void Exit()
    {
        _pointCollectorView.gameObject.SetActive(false);
        _inputHandler.Paused -= StartPause;
        _player.Destroyed -= EndGame;
    }

    private void EndGame(Character character)
    {
        StateMachine.SetState<EndGameState>();
    }

    private void StartPause()
    {
        StateMachine.SetState<PauseState>();
    }
}
    

