using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel : MonoBehaviour
{
    public Transform Modificators;
    public Text SetText;
    public DetailElement Element;

    public void Setup()
    {
        Helper.ClearTransform(Modificators);

        var data = LocalizationManager.DataForSetId(ItemSetManager.CurrentSet.id);

        SetText.text = data.name;

        ItemSetManager.CurrentSet.Modificators.ForEach(mod =>
        {
            mod.values.ForEach(val =>
            {
                var el = Instantiate(Element, Modificators);
                el.SetupForModificatorValue(mod, val);
            });

        });
    }
}
