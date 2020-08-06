public class LabelToggler : AbstractOnClickButtonBehaviour
{
    private LabelManager labelManager;

    protected override void Awake()
    {
        base.Awake();
        labelManager = LabelManager.Instance;
    }

    protected override void OnClickButton()
    {
        labelManager.ToggleAllLabels();
    }
}
