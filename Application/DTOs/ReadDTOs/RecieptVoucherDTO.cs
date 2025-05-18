using AmazonTours.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.DTOs.ReadDTOs
{
    public class RecieptVoucherDTO
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string EmployeeName { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountRatio { get; set; }
        public decimal DiscountAmount { get; set; }
        public string TripNotes { get; set; }
        public int NumberOfPassengers { get; set; }
        public string RecieptAttachmentImage { get; set; }

        public TripType TripType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Branch Branch { get; set; }
        public TransportationType TransportationType { get; set; }
        public DateTime TripStartDate { get; set; }
        public DateTime TripEndDate { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        [DefaultValue(true)]
        public bool IsInner { get; set; }
    }
}
