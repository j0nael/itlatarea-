﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Invoice
{
    [Key]
    public int Id { get; set; }

    public Customer Customer { get; set; }       // Cliente
    public Seller Seller { get; set; }           // Vendedor

    public DateTime Date { get; set; }           // Fecha

    public List<Sale> SaleDetails { get; set; }  // DetallesVenta

    public double Total
    {
        get
        {
            double total = 0;
            foreach (var sale in SaleDetails)
            {
                total += sale.Total;
            }
            return total;
        }
    }

    public Invoice()
    {
        SaleDetails = new List<Sale>();
        Date = DateTime.Now;
    }

    public Invoice(int id, Customer customer, Seller seller)
    {
        this.Id = id;
        this.Customer = customer;
        this.Seller = seller;
        this.Date = DateTime.Now;
        this.SaleDetails = new List<Sale>();
    }

    public void AddSale(Sale sale)
    {
        SaleDetails.Add(sale);
    }

    public string ShowInvoice()
    {
        string details = $"--- INVOICE #{Id} ---\n" +
                         $"Date: {Date}\n" +
                         $"Customer: {Customer.FirstName}\n" +
                         $"Seller: {Seller.FirstName}\n\n" +
                         $"DETAILS:\n";

        foreach (var sale in SaleDetails)
        {
            details += $"- {sale.Quantity} x {sale.SparePart.Name} @ {sale.SparePart.UnitPrice:C} = {sale.Total:C}\n";
        }

        details += $"\nTOTAL: {Total:C}";

        return details;
    }
}
