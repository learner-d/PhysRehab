using PhysRehab.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public bool DataAcquired { get; private set; } = false;


    private bool AcquireData()
    {
        
        return false;
    }

    public void _Btn_StartCaption_Click()
    {
        Hide();
        DataAcquired = AcquireData();
    }

    public void _Btn_CancelCaption_Click()
    {
        Hide();
    }

}
