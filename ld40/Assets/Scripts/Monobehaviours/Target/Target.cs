using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    [SerializeField] GameData data;
    [SerializeField] ColorTypes colorType;

    void OnMouseDown()
    {
        if(data.selectedBox == null) {
            return;
        }

        if (data.selectedBox.colorType == colorType)
        {
            Destroy(data.selectedBox.gameObject);
            data.selectedBox = null;
        } else {
            data.selectedBox.body.isKinematic = false;
            data.selectedBox.col.enabled = true;
            data.selectedBox = null;
        }
    }

    void OnMouseUp()
    {
        if (data.selectedBox == null)
        {
            return;
        }

        if (data.selectedBox.colorType == colorType)
        {
            Destroy(data.selectedBox.gameObject);
            data.selectedBox = null;
        }
        else
        {
            data.selectedBox.body.isKinematic = false;
            data.selectedBox.col.enabled = true;
            data.selectedBox = null;
        }
    }
}
