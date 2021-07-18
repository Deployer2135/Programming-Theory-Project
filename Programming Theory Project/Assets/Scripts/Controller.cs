using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    List<AbstractionPillar> pillarsOfOOP = new List<AbstractionPillar>(4);
    int pillarPointer = 0;

    public Text CodeStructure;
    public Text ShowInfoText;
    public GameObject Rotator;

    bool enableClick = true;

    enum Rotation
    {
        Left, Right
    }

    private void Start()
    {
        pillarsOfOOP.Add(new AbstractionPillar() { Length = 100 });
        pillarsOfOOP.Add(new PolymorphismPillar() { Length = 100 });
        pillarsOfOOP.Add(new EncapsulationPillar() { Length = 100 });
        pillarsOfOOP.Add(new InheritancePillar() { Length = 100 });
    }

    void Update()
    {
        if (enableClick)
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit[] raycastHits = Physics.RaycastAll(ray);

                if (raycastHits.Length > 0)
                {
                    GameObject rotationDirection = raycastHits[0].collider.gameObject;

                    switch (rotationDirection.name)
                    {
                        case "Left":
                            {
                                RotatePillars(Rotation.Left);
                                break;
                            }
                        case "Right":
                            {
                                RotatePillars(Rotation.Right);
                                break;
                            }
                    }
                }
            }
    }

    string GetPillarInfo(AbstractionPillar pillar)
    {
        return pillar.ShowInfo();
    }

    void RotatePillars(Rotation direction)
    {
        Vector3 rotationAxis = Vector3.zero;

        switch (direction)
        {
            case Rotation.Left:
                {
                    if (--pillarPointer < 0)
                        pillarPointer = 3;

                    rotationAxis = Vector3.up;
                    break;
                }
            case Rotation.Right:
                {
                    if (++pillarPointer > 3)
                        pillarPointer = 0;

                    rotationAxis = Vector3.down;
                    break;
                }
        }

        StartCoroutine(Rotate(rotationAxis));
    }

    IEnumerator Rotate(Vector3 quaternion)
    {
        enableClick = false;

        int timer = 90;

        while (timer-- != 0)
        {
            Rotator.transform.rotation *= Quaternion.Euler(quaternion);
            yield return new WaitForSeconds(0.01f);
        }

        ChangeMainText();

        enableClick = true;
    }

    void ChangeMainText()
    {
        switch (pillarsOfOOP[pillarPointer].PillarType)
        {
            case "Abstraction":
                {
                    CodeStructure.text =
@"class AbstractionPillar
{
    protected int length;
    public string PillarType { get; set; }
    public virtual int Length
    { get => length; set => length = value; }

    public AbstractionPillar() { PillarType = ""Abstraction""; }

    public virtual string ShowInfo()
    {
        return ""Pillar:"" + PillarType;
    }
}";
                    break;
                }
            case "Inheritance":
                {
                    CodeStructure.text =
@"class InheritancePillar : AbstractionPillar
{
    public InheritancePillar() { PillarType = ""Inheritance""; }

    public override string ShowInfo()
    {
        return base.ShowInfo() + ""; Parent: "" + ShowParentClass();
    }

    public string ShowParentClass()
    {
        return this.GetType().BaseType.ToString();
    }
}";
                    break;
                }
            case "Polymorphism":
                {
                    CodeStructure.text =
@"class PolymorphismPillar : AbstractionPillar
{
    public override int Length { get => length + 100; set => length = value; }

    public PolymorphismPillar() { PillarType = ""Polymorphism""; }

    public override string ShowInfo()
    {
        return base.ShowInfo() + ""; Length: "" + Length;
    }
}";
                    break;
                }
            case "Encapsulation":
                {
                    CodeStructure.text =
@"class EncapsulationPillar : AbstractionPillar
{
    public new int Length
    {
        get => length;
        set { length = value < 0 ? 0 : value; }
    }

    public EncapsulationPillar() { PillarType = ""Encapsulation""; }

    public override string ShowInfo()
    {
        string info = ShowType() + ""; "" + ShowLength();
        return info;
    }

    private string ShowType() { return ""Pillar: "" + PillarType; }
    private string ShowLength() { return ""Length: "" + Length.ToString(); }
}";
                    break;
                }
        }
    }

    public void ShowPillarInfo()
    {
        string pillarInfo = pillarsOfOOP[pillarPointer].ShowInfo();
        ShowInfoText.text = pillarInfo;
    }
}
