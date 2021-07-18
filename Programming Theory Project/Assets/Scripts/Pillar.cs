using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractionPillar
{
    protected int length;
    public string PillarType { get; set; }
    public virtual int Length
    { get => length; set => length = value; }

    public AbstractionPillar() { PillarType = "Abstraction"; }

    public virtual string ShowInfo()
    {
        return "Pillar:" + PillarType;
    }
}

public class InheritancePillar : AbstractionPillar
{
    public InheritancePillar() { PillarType = "Inheritance"; }

    public override string ShowInfo()
    {
        return base.ShowInfo() + "; Parent: " + ShowParentClass();
    }

    public string ShowParentClass()
    {
        return this.GetType().BaseType.ToString();
    }
}

public class PolymorphismPillar : AbstractionPillar
{
    public override int Length { get => length + 100; set => length = value; }

    public PolymorphismPillar() { PillarType = "Polymorphism"; }

    public override string ShowInfo()
    {
        return base.ShowInfo() + "; Length: " + Length;
    }
}

public class EncapsulationPillar : AbstractionPillar
{
    public new int Length
    {
        get => length;
        set { length = value < 0 ? 0 : value; }
    }

    public EncapsulationPillar() { PillarType = "Encapsulation"; }

    public override string ShowInfo()
    {
        string info = ShowType() + "; " + ShowLength();
        return info;
    }

    private string ShowType() { return "Pillar: " + PillarType; }
    private string ShowLength() { return "Length: " + Length.ToString(); }
}
