﻿using System;
using System.Linq;
using workshop_manager_v2.dbcontext;

public class RepairService
{
    public static void Add()
    {
        Console.Write("Vehicle license plate: ");
        string licensePlate = Console.ReadLine();
        Console.Write("Mechanic ID: ");
        int mechanicId = int.Parse(Console.ReadLine());
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Cost: ");
        double cost = double.Parse(Console.ReadLine());
        DateTime date = DateTime.Now;

        var repair = new Repair(0, licensePlate, mechanicId, description, cost, date);

        using var db = new Connection();
        db.Repairs.Add(repair);
        db.SaveChanges();

        Console.WriteLine("Repair added.");
    }

    public static void View()
    {
        using var db = new Connection();
        var list = db.Repairs.ToList();

        foreach (var r in list)
        {
            Console.WriteLine($"ID: {r.Id}, License Plate: {r.VehicleLicensePlate}, Mechanic ID: {r.MechanicId}, Description: {r.Description}, Cost: {r.Cost}, Date: {r.Date.ToShortDateString()}");
        }
    }

    public static void FilterByDate()
    {
        Console.Write("Start date (yyyy-MM-dd): ");
        var startDateInput = Console.ReadLine();
        Console.Write("End date (yyyy-MM-dd): ");
        var endDateInput = Console.ReadLine();

        if (!DateTime.TryParse(startDateInput, out DateTime startDate) ||
            !DateTime.TryParse(endDateInput, out DateTime endDate))
        {
            Console.WriteLine("One or both dates are invalid.");
            return;
        }

        using var db = new Connection();
        var repairs = db.Repairs
            .Where(r => r.Date.Date >= startDate.Date && r.Date.Date <= endDate.Date)
            .ToList();

        if (repairs.Count == 0)
        {
            Console.WriteLine("No repairs found in that date range.");
            return;
        }

        Console.WriteLine("=== Repairs found ===");
        foreach (var r in repairs)
        {
            Console.WriteLine($"ID: {r.Id}, License Plate: {r.VehicleLicensePlate}, Mechanic ID: {r.MechanicId}, Description: {r.Description}, Cost: {r.Cost}, Date: {r.Date:yyyy-MM-dd}");
        }
    }

    public static void Update()
    {
        Console.Write("ID of the repair to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        using var db = new Connection();
        var r = db.Repairs.Find(id);

        if (r == null)
        {
            Console.WriteLine("Repair not found.");
            return;
        }

        Console.Write($"Current description: {r.Description}. New description: ");
        string description = Console.ReadLine();
        r.Description = string.IsNullOrEmpty(description) ? r.Description : description;

        Console.Write($"Current cost: {r.Cost}. New cost: ");
        string costInput = Console.ReadLine();
        r.Cost = double.TryParse(costInput, out double newCost) ? newCost : r.Cost;

        Console.Write($"Current date: {r.Date:yyyy-MM-dd}. New date (yyyy-MM-dd): ");
        string dateInput = Console.ReadLine();
        r.Date = DateTime.TryParse(dateInput, out DateTime newDate) ? newDate : r.Date;

        db.SaveChanges();
        Console.WriteLine("Repair updated.");
    }

    public static void Delete()
    {
        Console.Write("ID of the repair to delete: ");
        int id = int.Parse(Console.ReadLine());

        using var db = new Connection();
        var r = db.Repairs.Find(id);

        if (r == null)
        {
            Console.WriteLine("Not found.");
            return;
        }

        db.Repairs.Remove(r);
        db.SaveChanges();
        Console.WriteLine("Repair deleted.");
    }
}
