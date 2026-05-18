using UnityEngine;

public class PauseState : State
{
    private ButtonClickHandler _continueGameButton;
    private InputHandler _inputHandler;
    private Canvas _pauseCanvas;

    public PauseState(StateMachine stateMachine, InputHandler inputHandler, Canvas pauseCanvas, ButtonClickHandler continueGameButton) : base(stateMachine)
    {
        _inputHandler = inputHandler;
        _pauseCanvas = pauseCanvas;
        _continueGameButton = continueGameButton;
    }

    public override void Enter()
    {
        _inputHandler.EnablePause();
        _pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = MinTimeScaleValue;
        _inputHandler.Paused += ContinueGame;
        _continueGameButton.ButtonClicked += ContinueGame;
    }

    public override void Exit()
    {
        _pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = MaxTimeScaleValue;
        _inputHandler.Paused -= ContinueGame;
        _inputHandler.DisablePause();
        _continueGameButton.ButtonClicked -= ContinueGame;
    }

    private void ContinueGame()
    {
        StateMachine.SetState<GameState>();
    }
}
