using System.Collections.Generic;
using VlsmDBContext;

namespace VlsmCalculatorMVC.Models
{
    public class HomeIndexViewModel
    {
        public IList<Vlsmresult> vlsmresults { get; set; }
    }
}
