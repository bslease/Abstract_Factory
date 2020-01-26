using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements requirements);
}

public class CycleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.NumberOfWheels == 1) return new Unicycle();
                return new Bicycle();
            default:
                return new Bicycle();
        }
    }
}

public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                return new Motorbike();
            default:
                return new Truck();
        }
    }
}

public abstract class AbstractVehicleFactory
{
    //public abstract IVehicleFactory CycleFactory();
    //public abstract IVehicleFactory MotorVehicleFactory();

    public abstract IVehicle Create();
}



public class VehicleFactory : AbstractVehicleFactory
{
    //public override IVehicleFactory CycleFactory()
    //{
    //    return new CycleFactory();
    //}

    //public override IVehicleFactory MotorVehicleFactory()
    //{
    //    return new MotorVehicleFactory();
    //}

    private readonly IVehicleFactory _factory;
    private readonly VehicleRequirements _requirements;

    public VehicleFactory(VehicleRequirements requirements)
    {
        _factory = requirements.Engine ? (IVehicleFactory) new MotorVehicleFactory() : new CycleFactory();
        _requirements = requirements;
    }

    public override IVehicle Create()
    {
        return _factory.Create(_requirements);
    }
}


