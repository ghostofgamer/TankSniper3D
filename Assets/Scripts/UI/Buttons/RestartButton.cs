using UnityEngine.SceneManagement;

public class RestartButton : AbstractButton
{
    public override void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}