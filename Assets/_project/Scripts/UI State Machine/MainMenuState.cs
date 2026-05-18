using UnityEngine;

public class MainMenuState : State
{
    private Canvas _mainMenuCanvas;
    private ButtonClickHandler _playGameButton;
    private InputHandler _inputHandler;


    public MainMenuState(StateMachine stateMachine, Canvas mainMenuCanvas, ButtonClickHandler playGameButton, InputHandler inputHandler) : base(stateMachine)
    {
        _mainMenuCanvas = mainMenuCanvas;   
        _playGameButton = playGameButton;
        _inputHandler = inputHandler;
    }

    public override void Enter()
    {
        _inputHandler.EnablePause();
        Time.timeScale = MinTimeScaleValue;
        _playGameButton.ButtonClicked += StartGame;
        _mainMenuCanvas.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        _playGameButton.ButtonClicked -= StartGame;
        Time.timeScale = MaxTimeScaleValue;
        _mainMenuCanvas.gameObject.SetActive(false);
        _inputHandler.DisablePause();
    }

    private void StartGame()
    {
        StateMachine.SetState<GameState>();
    }
}
