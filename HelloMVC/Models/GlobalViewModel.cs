using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    public class GlobalViewModel
    {
        public CustomerViewModel customer;
        public List<GenderViewModel> genders = new List<GenderViewModel>();
        public List<LanguageViewModel> languages = new List<LanguageViewModel>();
    }
}