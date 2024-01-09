using UnityEngine.SceneManagement;

public class ResetButton : AbstractButton
{
    public override void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}