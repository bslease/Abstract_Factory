using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;

    // Start is called before the first frame update
    void Start()
    {
        // validate our data
        NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        Passengers = Mathf.Max(Passengers, 1);
        Engine = Cargo;

        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfWheels = NumberOfWheels;
        requirements.Engine = Engine;
        requirements.Passengers = Passengers;

        //IVehicle v = new Unicycle();
        IVehicle v = GetVehicle(requirements);
        Debug.Log(v);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        // based on requirements.Engine
        // choose a motorvehicle factory or a cycle factory
        // call create on the factory to get an appropriate vehicle
        // and return it

        VehicleFactory factory = new VehicleFactory();

        if (requirements.Engine)
        {
            return factory.MotorVehicleFactory().Create(requirements);
        }

        return factory.CycleFactory().Create(requirements);
    }
}
