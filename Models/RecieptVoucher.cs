using AmazonTours.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.Enums;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Domain
{
    public class RecieptVoucher : IEntity
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey(nameof(Employee))]
        public string EmployeeId { get; set; }
        public IdentityUser Employee { get; set; }

        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountRatio { get; set; }
        public decimal DiscountAmount { get; set; }
        public string TripNotes { get; set; }
        [EnumDataType(typeof(TripType))]
        public TripType TripType { get; set; }
        [EnumDataType(typeof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; set; }
        [EnumDataType(typeof(Branch))]
        public Branch Branch { get; set; }
        public int NumberOfPassengers { get; set; }
        public string RecieptAttachmentImage { get; set; }
        [EnumDataType(typeof(TransportationType))]
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
