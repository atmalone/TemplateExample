﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Text.RegularExpressions;

namespace BayviewHouse.Models
{
    public class Booking_Model
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Room Name")]
        [Required(ErrorMessage ="Room Selection Required")]
        public string RoomName { get; set; }

        [Display(Name = "Arrival Date")]
        [DataType(DataType.Date)]
        public DateTime? ArrivalDate { get; set; }

        [Display(Name = "Departure Date")]
        [DataType(DataType.Date)]
        public DateTime? DepartureDate { get; set; }

        [Display(Name = "Card Holder Name")]
        [Required(ErrorMessage ="Card Holder Name Required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Invalid Card Holder Name")]
        public string CardHolderName { get; set; }

        [Display(Name = "Card Type")]
        [Required(ErrorMessage ="Card Type Required")]
        public string CardType { get; set; }

        [Display(Name = "Card Number")]
        [Required(ErrorMessage ="Card Number Required")]
        [RegularExpression("^[0-9]{16}+$", ErrorMessage = "Invalid Card Number")]
        public string CreditCardNumber { get; set; }

        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        [Display(Name = "CVV")]
        [Required(ErrorMessage ="CVV Security Number Required")]
        [RegularExpression("^[0-9]{3}+$", ErrorMessage ="Invalid CVV Security Number")]
        public int SecurityNumber { get; set; }    

        public Booking_Model() { }
        public Booking_Model(string email, string roomName, DateTime arrivalDate , DateTime departureDate, string cardHolderName, string cardType, string creditCardNumber, DateTime expiryDate ,int securityNumber)
        {            
            Email = email;
            RoomName = roomName;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
            CardHolderName = cardHolderName;
            CardType = cardType;
            CreditCardNumber = creditCardNumber;
            ExpiryDate = expiryDate;
            SecurityNumber = securityNumber;
        }        
    }
}