using UnityEngine;
using TMPro;

public class EndGameState : State
{
    private ButtonClickHandler _restartGameButton;
    private PointCollector _pointCollector;
    private InputHandler _inputHandler;
    private Canvas _endGameCanvas;
    private TMP_Text _scoreTextArea;

    public EndGameState(StateMachine stateMachine, Canvas endGameCanvas, ButtonClickHandler restartGameButton, InputHandler inputHandler, PointCollector pointCollector, TMP_Text scoreTextArea) : base(stateMachine)
    {
        _endGameCanvas = endGameCanvas;
        _restartGameButton = restartGameButton;
        _inputHandler = inputHandler;
        _pointCollector = pointCollector;
        _scoreTextArea = scoreTextArea;
    }

    public override void Enter()
    {
        _scoreTextArea.text = _pointCollector.Count.ToString();
        _inputHandler.EnablePause();
        _endGameCanvas.gameObject.SetActive(true);
        Time.timeScale = MinTimeScaleValue;
        _restartGameButton.ButtonClicked += StartNewGame;
    }

    public override void Exit()
    {
        _inputHandler.DisablePause();
        _restartGameButton.ButtonClicked -= StartNewGame;
        _endGameCanvas.gameObject.SetActive(false);
    }

    private void StartNewGame()
    {
        StateMachine.SetState<NewGameState>();
    }
}
