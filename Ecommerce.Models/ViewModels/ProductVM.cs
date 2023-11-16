using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; } 
        //Category List is null and it will cause exception when we use it in drop down so write this DataAnnotation
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
