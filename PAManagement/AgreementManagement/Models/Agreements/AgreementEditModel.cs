using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgreementManagement.Models
{
    //Info: its a not a good approach to inherit it from Agreement Create Model
    public class AgreementEditModel
    {
        [Required]
        public int ProductGroupId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public DateTime EffectiveDate  { get; set; }
        [Required]
        public DateTime ExpirationDate  { get; set; }
        [Required]
        public long NewPrice  { get; set; }
        [Required]
        public bool Active { get; set; }

        public List<SelectListItem> Products { get; set; }
        public List<SelectListItem> ProductGroups { get; set; }

        public AgreementEditModel() { }

        public AgreementEditModel(List<SelectListItem> products, List<SelectListItem> productGroups)
        {
            Products = products;
            ProductGroups = productGroups;
        }
    }
}
