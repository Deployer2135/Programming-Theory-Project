using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    Pillar abstractionPillar = new Pillar();
    InheritancePillar inheritancePillar = new InheritancePillar();
    PolymorphismPillar polymorphismPillar = new PolymorphismPillar();
    EncapsulationPillar encapsulationPillar = new EncapsulationPillar();

    public Text CodeStructure;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] raycastHits = Physics.RaycastAll(ray);

            if (raycastHits.Length > 0)
            {
                Debug.Log(raycastHits[0].collider.gameObject.name);
            }
        }
    }

    string GetPillarInfo(Pillar pillar)
    {
        return pillar.ShowInfo();
    }
}
