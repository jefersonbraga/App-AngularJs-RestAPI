using System.Collections.Generic;

namespace  Cursos.ViewModel
{
	
      public partial class AcoesViewModel
      {
        public AcoesViewModel()
        {
            Menu = new List<MenuViewModel>();
        }
        public IEnumerable<MenuViewModel> Menu { get; set; }
    }
}
