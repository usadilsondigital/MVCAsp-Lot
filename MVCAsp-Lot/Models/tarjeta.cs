//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCAsp_Lot.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    
    public partial class tarjeta
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Evento is required")]
        [Display(Name = "Evento")]
        public int evento_id { get; set; }

        [Display(Name = "User ID")]
        public Nullable<int> user_id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string body { get; set; }

        [Required(ErrorMessage = "Estado is required")]
        [Display(Name = "Estado")]
        [StringLength(1)]
        public string estado { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual evento evento { get; set; }
    }
}
