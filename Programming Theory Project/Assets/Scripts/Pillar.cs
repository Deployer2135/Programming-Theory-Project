using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar
{
    protected int length;
    public string PillarType { get; set; }
    public virtual int Length
    { get => length; set => length = value; }

    public Pillar() { PillarType = "Abstraction"; }

    public virtual string ShowInfo()
    {
        return "Pillar:" + PillarType;
    }
}

public class InheritancePillar : Pillar
{
    public InheritancePillar() { PillarType = "Inheritance"; }

    public string ShowParentClass()
    {
        return this.GetType().BaseType.ToString();
    }
}

public class PolymorphismPillar : Pillar
{
    public override int Length { get => length + 100; set => length = value; }

    public PolymorphismPillar() { PillarType = "Polymorphism"; }

    public override string ShowInfo()
    {
        return base.ShowInfo() + "; length: " + Length;
    }
}

public class EncapsulationPillar : Pillar
{
    public new int Length
    {
        get => length;
        set
        {
            if (value < 0)
                length = 0;
            else
                length = value;
        }
    }

    public EncapsulationPillar() { PillarType = "Encapsulation"; }

    public new string ShowInfo()
    {
        string info = ShowType() + "; " + ShowLength();
        return info;
    }

    private string ShowType() { return "Pillar: " + PillarType; }
    private string ShowLength() { return "Length: " + Length.ToString(); }
}
