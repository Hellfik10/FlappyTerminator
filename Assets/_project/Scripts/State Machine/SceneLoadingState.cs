using UnityEngine.SceneManagement;

public class SceneLoadingState : State
{
    public SceneLoadingState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
