using UnityEngine.SceneManagement;

public class NewGameState : State
{
    public NewGameState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Exit();
    }
}
