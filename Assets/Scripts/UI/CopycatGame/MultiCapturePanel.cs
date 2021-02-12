using PhysRehab.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MultiCapturePanel : DialogPanelBase
{
    [SerializeField]
    private InputField _capturingName_infld;
    [SerializeField]
    private InputField _capturingInterval_infld;
    [SerializeField]
    private InputField _capturingCount_infld;

    public string CapturingName { get; private set; } = "";
    public float CapturingInterval { get; private set; } = float.NaN;
    public int CapturingCount { get; private set; } = 0;

    public event UnityAction<string, int, float> DataAquiredEvent;

    private void AcquireData()
    {
        if (string.IsNullOrEmpty(_capturingName_infld.text))
            return;
        CapturingName = _capturingName_infld.text;

        if (string.IsNullOrEmpty(_capturingInterval_infld.text) || !float.TryParse(_capturingInterval_infld.text, out float parsedInterval)
            || float.IsNaN(parsedInterval)
            || parsedInterval <= 0 || parsedInterval >= 1000)
            return;
        CapturingInterval = parsedInterval;

        if (string.IsNullOrEmpty(_capturingCount_infld.text) || !int.TryParse(_capturingCount_infld.text, out int parsedCount)
            || parsedCount <= 0)
            return;
        CapturingCount = parsedCount;

        DataAquiredEvent?.Invoke(CapturingName, CapturingCount, CapturingInterval);
    }

    public void _Btn_StartCaption_Click()
    {
        Hide();
        AcquireData();
    }

    public void _Btn_CancelCaption_Click()
    {
        Hide();
    }

    protected override void UpdateVisibility()
    {
        base.UpdateVisibility();
    }
}
